/*******************************************************************
 *
 *        Module: order_control
 *
 *        Project: Ackerchip
 *
 *        Author: Simon Graetzer <simon.graetzer@googlemail.com>
 *
 *        Dieses Modul kommuniziert über das Rx Interface des RS232 Interfaces.
 *        Es empfängt Befehle des Computers die als 3 Byte Datenpakete gesendet werden.
 *        In diesem Fall um das Ansteuern der Pumpen und Ventilen.
 *
 *******************************************************************/
 `timescale 1ns / 1ps
 
 module order_control(
  //Takt und Reset
  input	 wire	clock,
  input   wire	reset,
  
  //RS232
 	input wire rs232_Data_out_valid,// Rx data output valid
	input wire [7:0] rs232_Data_out,// Rx 8 bit data output
	
	//Peripheriesteuerung (Ventile, Pumpe)
	output reg oc_rotation_on,//Time control rotation device
	output reg [7:0] oc_distance,//Distanz, also Stärke des Auslassventils. Digitales Signal fuer die PWM
	output reg oc_power,//Pumpe On or Off
	output reg oc_action,//Wasser oder Duenger.
	
	//Messintervallkonfiguration. Messintervall maximal 2^4*5*60*10MHz.
  output reg [35:0] sampling_interval,//Datenleitung fuer einen Konfigurationswert.
  output reg [1:0] sampling_sensor,//Sensorwahl 
  output reg set_sampling_interval//Setze Intervall im adc_controller
);

//Timer Einstellungen
parameter TIMER_WIDTH = 25;//Breite des Timer Registers
parameter TIMER_START_PUMP = 25'd20_000_000;  // 2 Sekunden;
parameter TIMER_START_ROTATION = 25'd30000;//50 millisecons
parameter TIMER_ZERO = {TIMER_WIDTH{1'b0}};

reg [TIMER_WIDTH-1:0] timer_start = {TIMER_WIDTH{1'b0}};
wire timer_done;

Acker_Timer #(TIMER_WIDTH) order_timer (
.clock(clock),
.reset(reset),
.start(timer_start),
.done(timer_done)
);

//Parameter Actions
parameter WATER_OUT = 1'b0, FERTILISER_OUT = 1'b1;

//Sensoren
parameter SENSOR1 = 2'd0,
	  SENSOR2 = 2'd1,
	  SENSOR3 = 2'd2,
	  SENSOR4 = 2'd3;

//States
parameter [2:0]
     RECEIVE_BYTE0_STATE = 3'd0,
	  RECEIVE_BYTE1_STATE = 3'd1,
	  RECEIVE_BYTE2_STATE = 3'd2,
	  ROTATION_STATE = 3'd3,
	  PUMP_STATE = 3'd4;

//Interne Register
reg [2:0] state;//FSM State
reg [4:0] pump_time = 5'b0;//Zwischenspeicher fuer die Dauer des Giessvorgangs
reg [7:0] position  = 8'b0;//Zwischenspeicher fuer die Dauer des Rotationssignals
reg [7:0] last_position = 8'b0;//Speicher wo das letzte mal hingedreht wurde.
reg last_rs232_Data_out_valid;//Gebraucht um auf ein neues Byte zu testen

reg [2:0] next_state = RECEIVE_BYTE0_STATE;
reg [7:0] next_position  = 8'b0;
reg [7:0] next_last_position = 8'b0;
reg [4:0] next_pump_time = 5'b0;
reg next_last_rs232_Data_out_valid = 1'b0;

//Messintervallkonfiguration
reg [35:0] next_sampling_interval;
reg [1:0] next_sampling_sensor;
reg next_set_sampling_interval;

//Peripheriesteuerung
reg [7:0] next_oc_distance = 8'b0;
reg next_oc_action = WATER_OUT;
reg next_oc_power = 1'b0;
reg next_oc_rotation_on = 1'b0;

//Sequentieller Block   
always @ (posedge clock)
begin
  if(reset == 1'b0) // LOW ACTIVE reset !
  begin
    //Intern
    state <= RECEIVE_BYTE0_STATE; 
    last_rs232_Data_out_valid<= 1'b0;
	  pump_time <= 5'b0;
    position  <= 8'b0;
    last_position <= 8'b0;
    
    //Messintervallkonfiguration
    sampling_interval <= 35'b0;
    sampling_sensor <= SENSOR1;
    set_sampling_interval <= 1'b0;
    
    //Peripheriesteuerung
    oc_rotation_on <= 1'b0;
    oc_distance <= 8'b0;
    oc_action <= WATER_OUT;
    oc_power <= 1'b0;
  end else 
  begin
    //Intern
    state <= next_state;
    position <= next_position;
	 last_position <= next_last_position;
    last_rs232_Data_out_valid<= next_last_rs232_Data_out_valid;
	 pump_time <= next_pump_time;
	  
	  //Messintervallkonfiguration
    sampling_interval <= next_sampling_interval;
    sampling_sensor <= next_sampling_sensor;
    set_sampling_interval <= next_set_sampling_interval;
    
	 //Peripheriesteuerung
    oc_distance <= next_oc_distance;
    oc_rotation_on <= next_oc_rotation_on;
    oc_power <= next_oc_power;
    oc_action <= next_oc_action;
  end
end
 
//Kombinatorischer Block
always @ (state, rs232_Data_out_valid, rs232_Data_out, timer_done,
last_rs232_Data_out_valid, oc_distance, position, last_position, oc_action, oc_power, pump_time)
begin
  next_last_rs232_Data_out_valid = rs232_Data_out_valid;
  
  case(state)
    RECEIVE_BYTE0_STATE://Warten auf das erste Byte
		 begin
		  //Die ersten beiden Bit geben die Aktion an 00:Waessern, 01:Messintervalle setzen.
		  if(rs232_Data_out_valid && (last_rs232_Data_out_valid == 1'b0) && rs232_Data_out[7:6] == 2'b00)
		  begin//Es soll gewaessert werden. Muss noch auf weitere Bytes warten
		  /* Bit 7-5 Anweisungen. Bisher nur Bit 5 genutzt fuer Wasser oder Duenger
		  Die restlichen 5 Bits geben die Dauer die Gewaessert wird in 2 Sekunden an.*/
			next_pump_time = rs232_Data_out[4:0];//Dauer die gewaessert werden soll
			next_oc_action = rs232_Data_out[5];//Duenger oder Wasser
			next_state = RECEIVE_BYTE1_STATE;//Warten auf das naechste Byte
			
			next_sampling_interval = 35'b0;
			next_sampling_sensor = SENSOR1;
			next_set_sampling_interval = 1'b0;
		  end else if(rs232_Data_out_valid && (last_rs232_Data_out_valid == 1'b0) && rs232_Data_out[7:6] == 2'b01)
		  begin//Neues Messintervall.
			/*
			Bit 5 und 4 geben den Sensor an. Der Rest das Messintervall in der Einhet 5 Minuten 
			*/
			//Angabe folgt immer in 5 Minuten
			next_sampling_interval = 36'd3_000_000_000 * {32'b0,rs232_Data_out[3:0]};
			next_sampling_sensor = rs232_Data_out[5:4];//Sensor
			next_set_sampling_interval = 1'b1;
		
			next_pump_time = 5'b0;
			next_oc_action = WATER_OUT;
			next_state = RECEIVE_BYTE0_STATE;//Keine weitern Bytes noetig
		  end else 
		  begin
			next_sampling_interval = 35'b0;
			next_sampling_sensor = SENSOR1;
			next_set_sampling_interval = 1'b0;
		
			next_pump_time = 5'b0;
			next_oc_action = WATER_OUT;
			next_state = RECEIVE_BYTE0_STATE;//Warten auf Daten
		  end//if(rs232_Data_out_valid && (last_rs232_Data_out_valid == 1'b0) && rs232_Data_out[7:6] == 2'bxx)

			next_oc_distance = 8'b0;//Distanz wird spaeter gesetzt
			next_oc_power = 1'b0;//Pumpe wird im ensprechenden State gesetzt
			next_oc_rotation_on = 1'b0;//Rotation wird im ensprechenden State gesetzt
			
			next_position  = 8'b0;
			next_last_position = last_position;
			
			timer_start = TIMER_ZERO;
		 end//RECEIVE_BYTE0_STATE
    
    RECEIVE_BYTE1_STATE://Die Dauer die das Drehventil gedreht werden soll in 2 Sekunden
		 begin
			if(rs232_Data_out_valid && (last_rs232_Data_out_valid == 1'b0))
			begin
			  next_position = rs232_Data_out - last_position;//Positon auf die Drehventil bewegt werden soll.
			  next_last_position = rs232_Data_out;
			  next_state = RECEIVE_BYTE2_STATE;//Warten auf das naechste Byte
			end else
			begin
			  next_position  = 8'b0;
			  next_last_position = last_position;
			  next_state = RECEIVE_BYTE1_STATE;
			end
			next_oc_action = oc_action;// Die Aktion beibehalten
			next_oc_distance = 8'b0;// Distanz 0
			next_oc_power = 1'b0;// Pumpe aus
			next_oc_rotation_on = 1'b0;//Rotation aus
			
			next_sampling_interval = 35'b0;
			next_sampling_sensor = SENSOR1;
			next_set_sampling_interval = 1'b0;
			
			next_pump_time = pump_time;// pump_time beibehalten
			
			timer_start = TIMER_ZERO;//Timer aus
		 end //RECEIVE_BYTE1_STATE
    
    RECEIVE_BYTE2_STATE://Die Distanz die ans PWM Modul gegeben wird.
		 begin
			if(rs232_Data_out_valid && (last_rs232_Data_out_valid == 1'b0))
			begin
			 next_oc_distance = rs232_Data_out;//Distanz setzen
			 next_oc_rotation_on = 1'b1;//Rotation an
			 timer_start = TIMER_START_ROTATION;//Timer ein
			 next_state = ROTATION_STATE;//Rotation starten
			end else
			begin
			  next_oc_distance = 8'b0;
			  next_oc_rotation_on = 1'b0;//Rotation weiterhin aus.
			  timer_start = TIMER_ZERO;
			  next_state = RECEIVE_BYTE2_STATE;
			end
			next_position = position;//Position behalten
			next_last_position = last_position;
			next_pump_time = pump_time;//Dauer behalten
			
			next_sampling_interval = 35'b0;
			next_sampling_sensor = SENSOR1;
			next_set_sampling_interval = 1'b0;
			
			next_oc_action = oc_action;//Aktionstyp halten
			next_oc_power = 1'b0;//Pumpe aus
		 end //RECEIVE_BYTE2_STATE
		 
		ROTATION_STATE://Warten auf das Beenden der Rotation
		//Der Wert in position wird mal 2sec genommen um die Zeit fuer das oc_rotation_on Signal zu bestimmen
		begin
		  if(position == 8'b0)//Ist position bei 0 angekommen wird weitergemacht
		  begin
		    next_position = 8'b0;//Position reset
		    next_oc_rotation_on = 1'b0;//Rotation aus
		    timer_start = TIMER_START_PUMP;//Start Pumpentimer
		    next_state = PUMP_STATE;
		  end else if(timer_done)//Ist der Timer einmal durchgelaufen wird position decrementiert.
		  begin
		    next_position = position - 1;// pump_time wird subtrahiert
		    next_oc_rotation_on = 1'b1;// Rotation an lassen
		    timer_start = TIMER_START_ROTATION;//Timer weiter laufen lassen bis position 0 ist
		    next_state = ROTATION_STATE;//Weiter warten und 
		  end else//Falls der Timer nicht fertig ist, wird einfach der Zustand gehalten
		  begin
		    next_position = position;//Position beibehalten
		    next_oc_rotation_on = 1'b1;// Rotation an lassen
		    timer_start = TIMER_ZERO;
		    next_state = ROTATION_STATE;//Weiter warten und 
		  end
		  next_last_position = last_position;
		  next_pump_time = pump_time;
		  next_last_position = last_position;
		  
		  next_sampling_interval = 35'b0;
		  next_sampling_sensor = SENSOR1;
		  next_set_sampling_interval = 1'b0;
		  
		  next_oc_power = 1'b0;//Pumpe noch aus
		  next_oc_action = oc_action;
		  next_oc_distance = oc_distance;
		end // ROTATION_STATE
    
    PUMP_STATE://Der giessvorgang
    //Arbeitet wie ROTATION_STATE
		 begin
			if(pump_time == 5'b0)//Warten das pump_time == 0 ist
			begin
			  next_pump_time = 5'b0;//pump_time ist eh 0
			  next_oc_power = 1'b0;//Pumpe abschalten
			  next_oc_action = WATER_OUT;//Reset action
			  timer_start = TIMER_ZERO;//Timer auf leerlauf
			  next_state = RECEIVE_BYTE0_STATE;
			end else if(timer_done)
			begin
			  next_pump_time = pump_time - 1;//pump_time dekrementieren
			  next_oc_power = 1'b1;//Pumpe an lassen
			  next_oc_action = oc_action;//Waehrend des vorgangs sollte oc_action gleich bleiben
			  timer_start = TIMER_START_PUMP;//Timer wieder starten
			  next_state = PUMP_STATE;//Loop bis timer abgelaufen
			end else//Der Timer ist nicht abgelaufen, alles bleibt gleich
			begin
			  next_pump_time = pump_time;//pump_time bleibt gleich
			  next_oc_power = 1'b1;//Pumpe an lassen
			  next_oc_action = oc_action;//Waehrend des vorgangs sollte oc_action gleich bleiben
			  timer_start = TIMER_ZERO;//Timer ist nicht fertig also laufen lassen
			  next_state = PUMP_STATE;//Loop bis timer abgelaufen
			end
			next_last_position = last_position;
			next_position = 8'b0;
			
			next_sampling_interval = 35'b0;
			next_sampling_sensor = SENSOR1;
			next_set_sampling_interval = 1'b0;
			
			next_oc_distance = oc_distance;
			next_oc_rotation_on = 1'b0;//Rotation aus
		 end//PUMP_STATE
    
    default:
		 begin
		  //external stuff
			next_oc_distance = 8'b0;
			next_oc_rotation_on = 1'b0;
			next_oc_action = WATER_OUT;
			next_oc_power = 1'b0;
			
			//Messintervalle
			next_sampling_interval = 35'b0;
			next_sampling_sensor = SENSOR1;
			next_set_sampling_interval = 1'b0;
			
			//Internal registers
			timer_start = TIMER_ZERO;
			
			next_state = RECEIVE_BYTE0_STATE;
			next_last_rs232_Data_out_valid = 1'b0;
			next_pump_time = 5'b0;
			next_last_position = 8'b0;
			next_position  = 8'b0;
		 end// default
  endcase//(state)
  
end

endmodule //order_control
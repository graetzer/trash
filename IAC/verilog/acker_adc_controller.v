				/*******************************************************************
 *
 *        Module: adc_controller
 *
 *        Project: Ackerchip
 *
 *        Author: Simon Graetzer <simon.graetzer@googlemail.com>
 *
 *        Dieses Modul soll die Aufaben des ADC Multiplexers übernehmen.
 *        Das heisst dafür sorgen das abhängig von einer
 *
 *******************************************************************/

 `timescale 1ns / 1ps
 
 module adc_controller (
  //Takt und Reset
  input	 wire	 clock,
  input  wire		reset,
  
  //ADC
 	input  wire		    adc_Data_out_valid,//AD Wandler Daten valide
	input  wire	[13:0] adc_Data_out_ch0,//AD Channel0
	input  wire	[13:0] adc_Data_out_ch1,//AD Channel1 - Das zu Ueberwachende Signal
  
  //Data Access Module. Entspricht dem ueblichen Schema
  input 	wire        da_Ready_for_Data_in,
  output reg  [13:0] da_Data_in,
  output reg		   da_Data_in_valid,
  output reg  [1:0]  da_sensor_type,
  
  //Messintervallkonfiguration. Messintervall maximal 2^4*5*60*10MHz.
  input wire [35:0] sampling_interval,//Datenleitung fuer einen Konfigurationswert.
  input wire [1:0] sampling_sensor,//Sensorwahl 
  input wire set_sampling_interval//Setze Intervall im adc_controller
);

//Sensoren
parameter SENSOR1 = 2'd0,
	  SENSOR2 = 2'd1,
	  SENSOR3 = 2'd2,
	  SENSOR4 = 2'd3;
parameter INTRO_STATE = 3'd0,
 SENSOR1_STATE = 3'd1,
 SENSOR2_STATE = 3'd2,
 SENSOR3_STATE = 3'd3,
 SENSOR4_STATE = 3'd4;

//Timer Einstellungen jeder Sensor bekommt einen eigenen Timer
parameter TIMER_WIDTH = 36;//Breite des Timer Registers
parameter TIMER_ZERO = {TIMER_WIDTH{1'b0}};
parameter DELAY_START = 36'd5000000;

//Der delay Timer macht den Statuswechsel an den besser LEDs sichtbar.
reg [TIMER_WIDTH-1:0] delay_start = {TIMER_WIDTH{1'b0}};
wire delay_done;

Acker_Timer #(TIMER_WIDTH) ADControl_delay (
.clock(clock),
.reset(reset),
.start(delay_start),
.done(delay_done)
);

reg [TIMER_WIDTH-1:0] timer1_start = {TIMER_WIDTH{1'b0}};
wire timer1_done;

Acker_Timer #(TIMER_WIDTH) ADControl_timer1 (
.clock(clock),
.reset(reset),
.start(timer1_start),
.done(timer1_done)
);

reg [TIMER_WIDTH-1:0] timer2_start = {TIMER_WIDTH{1'b0}};
wire timer2_done;

Acker_Timer #(TIMER_WIDTH) ADControl_timer2 (
.clock(clock),
.reset(reset),
.start(timer2_start),
.done(timer2_done)
);

reg [TIMER_WIDTH-1:0] timer3_start = {TIMER_WIDTH{1'b0}};
wire timer3_done;

Acker_Timer #(TIMER_WIDTH) ADControl_timer3 (
.clock(clock),
.reset(reset),
.start(timer3_start),
.done(timer3_done)
);

reg [TIMER_WIDTH-1:0] timer4_start = {TIMER_WIDTH{1'b0}};
wire timer4_done;

Acker_Timer #(TIMER_WIDTH) ADControl_timer4 (
.clock(clock),
.reset(reset),
.start(timer4_start),
.done(timer4_done)
);

//Messintervalle
reg [35:0] sensor1_interval = 36'd20_000_000;
reg [35:0] sensor2_interval = 36'd21_000_000;
reg [35:0] sensor3_interval = 36'd22_000_000;
reg [35:0] sensor4_interval = 36'd23_000_000;

reg [35:0] next_sensor1_interval = 36'd20_000_000;
reg [35:0] next_sensor2_interval = 36'd21_000_000;
reg [35:0] next_sensor3_interval = 36'd22_000_000;
reg [35:0] next_sensor4_interval = 36'd23_000_000;

//States
reg [2:0] state = INTRO_STATE;
reg [2:0] next_state = INTRO_STATE;

reg next_da_Data_in_valid = 1'b0;
reg [13:0]  next_da_Data_in = 14'b0;
reg [1:0] next_da_sensor_type;

//Sequentielle Logik Sensorabfrage
always@(posedge clock)
begin
  if(reset == 1'b0)  // LOW ACTIVE reset !
  begin
    //State
    state <= INTRO_STATE;
    da_Data_in <= 14'b0;
    da_Data_in_valid <= 1'b0;
    da_sensor_type <= SENSOR1;
    
    sensor1_interval <= 36'd20_000_000;
    sensor2_interval <= 36'd21_000_000;
    sensor3_interval <= 36'd22_000_000;
    sensor4_interval <= 36'd23_000_000;
  end else 
  begin
    //Data Access Module
    da_sensor_type <= next_da_sensor_type;
    da_Data_in <= next_da_Data_in;
    da_Data_in_valid <= next_da_Data_in_valid;
    
    sensor1_interval <= next_sensor1_interval;
    sensor2_interval <= next_sensor2_interval;
    sensor3_interval <= next_sensor3_interval;
    sensor4_interval <= next_sensor4_interval;
    
    state <= next_state;
  end
end

always@(state,timer1_done,timer2_done,timer3_done,delay_done,timer4_done,adc_Data_out_valid,
da_Ready_for_Data_in,da_sensor_type,adc_Data_out_ch0,adc_Data_out_ch1,
sampling_sensor,sampling_interval,set_sampling_interval,
sensor1_interval, sensor2_interval, sensor3_interval, sensor4_interval)
begin
  //Messintervalle setzen
  if(set_sampling_interval == 1'b1)
      case(sampling_sensor)
			SENSOR1:
			begin
			  next_sensor1_interval = sampling_interval;
			  timer1_start = sampling_interval;
			  next_sensor2_interval = sensor2_interval;
			  next_sensor3_interval = sensor3_interval;
			  next_sensor4_interval = sensor4_interval;
			end
      
			SENSOR2:
			begin
			  next_sensor1_interval = sensor1_interval;
			  next_sensor2_interval = sampling_interval;
			  timer2_start = sampling_interval;
			  next_sensor3_interval = sensor3_interval;
			  next_sensor4_interval = sensor4_interval;
			end
			
			SENSOR3:
			begin
			  next_sensor1_interval = sensor1_interval;
			  next_sensor2_interval = sensor2_interval;
			  next_sensor3_interval = sampling_interval;
			  timer3_start = sampling_interval;
			  next_sensor4_interval = sensor4_interval;
			end
			
			SENSOR4:
			begin
			  next_sensor1_interval = sensor1_interval;
			  next_sensor2_interval = sensor2_interval;
			  next_sensor3_interval = sensor3_interval;
			  next_sensor4_interval = sampling_interval;
			  timer4_start = sampling_interval;
			end
			
			default:
			begin
				next_sensor1_interval = 36'd20_000_000;
				next_sensor2_interval = 36'd21_000_000;
				next_sensor3_interval = 36'd22_000_000;
				next_sensor4_interval = 36'd23_000_000;
			end
		endcase//(sampling_sensor)
  else
  begin
    next_sensor1_interval = sensor1_interval;
    next_sensor2_interval = sensor2_interval;
    next_sensor3_interval = sensor3_interval;
    next_sensor4_interval = sensor4_interval;
  end
  
  case(state)
    INTRO_STATE://Reset alle timer
    begin
		  next_da_Data_in = 14'b0;
		  next_da_Data_in_valid = 1'b0;
		  next_da_sensor_type = SENSOR1;
		  timer1_start = 36'd20_000_000;
  		  timer2_start = 36'd21_000_000;
		  timer3_start = 36'd22_000_000;
		  timer4_start = 36'd23_000_000;
		  delay_start = DELAY_START;
		  next_state = SENSOR1_STATE;//next
    end
    
    SENSOR1_STATE://Ersten Sensor abfragen
    begin
      if(adc_Data_out_valid && da_Ready_for_Data_in && timer1_done && delay_done)
      begin
        next_da_Data_in = adc_Data_out_ch0;//Daten versenden
        next_da_Data_in_valid = 1'b1;
		  next_da_sensor_type = SENSOR1;
        timer1_start = sensor1_interval;
		  delay_start = DELAY_START;
      end else
      begin
		  next_da_Data_in = da_Data_in;
        next_da_Data_in_valid = 1'b0;
		  next_da_sensor_type = da_sensor_type;
		  delay_start = TIMER_ZERO;
        timer1_start = TIMER_ZERO;
      end
		timer2_start = TIMER_ZERO;
		timer3_start = TIMER_ZERO;
      timer4_start = TIMER_ZERO;
		next_state = SENSOR2_STATE;//next
    end//SENSOR1
    
    SENSOR2_STATE://Zweiten Sensor abfragen
    begin
      if(adc_Data_out_valid && da_Ready_for_Data_in && timer2_done && delay_done)
      begin
        next_da_Data_in = adc_Data_out_ch1;
        next_da_Data_in_valid = 1'b1;
        next_da_sensor_type = SENSOR2;
        timer2_start = sensor2_interval;
        delay_start = DELAY_START;
	  end else
	  begin
		 next_da_Data_in = da_Data_in;
		 next_da_Data_in_valid = 1'b0;
		 next_da_sensor_type = da_sensor_type;
		 timer2_start = TIMER_ZERO;
		 delay_start = TIMER_ZERO;
	  end
	  
	  timer1_start = TIMER_ZERO;
	  timer3_start = TIMER_ZERO;
	  timer4_start = TIMER_ZERO;
	  next_state = SENSOR3_STATE;//next
	  end//SENSOR2
    
    SENSOR3_STATE://Dritten Sensor abfragen
    begin
      if(adc_Data_out_valid && da_Ready_for_Data_in && timer3_done && delay_done)
      begin
        next_da_Data_in = adc_Data_out_ch0;
        next_da_Data_in_valid = 1'b1;
        next_da_sensor_type = SENSOR3;
        timer3_start = sensor3_interval;
        delay_start = DELAY_START;
      end else
      begin
		  next_da_Data_in = da_Data_in;
        next_da_Data_in_valid = 1'b0;
        next_da_sensor_type = da_sensor_type;
        timer3_start = TIMER_ZERO;
        delay_start = TIMER_ZERO;
      end
      timer1_start = TIMER_ZERO;
      timer2_start = TIMER_ZERO;
      timer4_start = TIMER_ZERO;
      next_state = SENSOR4_STATE;//next
    end//SENSOR3
    
    SENSOR4_STATE://Vierten Sensor abfragen
    begin
      if(adc_Data_out_valid && da_Ready_for_Data_in && timer4_done && delay_done)
      begin
        next_da_Data_in = adc_Data_out_ch1;
        next_da_Data_in_valid = 1'b1;
        next_da_sensor_type = SENSOR4;
        timer4_start = sensor4_interval;
        delay_start = DELAY_START;
      end else
      begin
		  next_da_Data_in = da_Data_in;
        next_da_Data_in_valid = 1'b0;
		  next_da_sensor_type = da_sensor_type;
        timer4_start = TIMER_ZERO;
		  delay_start = TIMER_ZERO;
      end
      timer1_start = TIMER_ZERO;
      timer2_start = TIMER_ZERO;
      timer3_start = TIMER_ZERO;
      next_state = SENSOR1_STATE;//next
    end//SENSOR4
      
    default:
    begin
      next_state = INTRO_STATE;
      next_da_Data_in = 14'b0;
      next_da_Data_in_valid = 1'b0;
		next_da_sensor_type = SENSOR1;
      
      timer1_start = 36'd20_000_000;
      timer2_start = 36'd21_000_000;
      timer3_start = 36'd22_000_000;
      timer4_start = 36'd23_000_000;
		delay_start = DELAY_START;
    end//default
  endcase
end

endmodule// adc_controller
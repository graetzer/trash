/*******************************************************************
 *
 *        Module: data_access
 *
 *        Project: Ackerchip
 *
 *        Author: Simon Graetzer <simon.graetzer@googlemail.com>
 *
 *        Dieses Modul Stellt das Datenbackend dar
 *        Es kommuniziert ueber RS232 mit einem Computer und sendet Daten.
 *
 *******************************************************************/
 `timescale 1ns / 1ps
 
 module data_access(
  //Takt und Reset
  input	 wire	 clock,
  input  wire		reset,
  
   //Data Input
  output 	reg          da_Ready_for_Data_in,//Ist das Modul Sendebereit? Entspricht nicht rs232_Data_in_valid, da 3 Byte gesendet werden
  input 	 wire  [13:0]  da_Data_in,//Dateneingang 14 Bit
  input 	 wire		       da_Data_in_valid,//Sind die Daten am Eingang valide?
  input 	 wire  [1:0]  da_sensor_type,//Der zu benutzende Datentyp {00, 01, 10, 11}
  
  //RS232 Cables
  output reg rs232_Data_in_valid, // Tx data input valid
  output reg [7:0] rs232_Data_in,       // Tx 8 bit data input
  input wire rs232_Ready_for_Data_in         // RS232 interface ready for Tx
  );
  
//Timer Einstellungen.
//Wird gebraucht um den Abstand zwischen der Sendezeit des ersten und zweiten Bytes einzustellen 
parameter TIMER_WIDTH = 13;//Breite des Timer Registers
parameter TIMER_START = 13'd5000;  // 500 microseconds;
parameter TIMER_ZERO = {TIMER_WIDTH{1'b0}};

reg [TIMER_WIDTH-1:0] timer_start = {TIMER_WIDTH{1'b0}};
wire timer_done;

Acker_Timer #(TIMER_WIDTH) transmission_timer (
.clock(clock),
.reset(reset),
.start(timer_start),
.done(timer_done)
);

//States
parameter [1:0] IDLE_STATE = 2'd0,
    BYTE0_SEND_STATE = 2'd1,
	  BYTE1_SEND_STATE = 2'd2;

//Interne Register
reg [1:0] state = IDLE_STATE;
reg [1:0] next_state = IDLE_STATE;

reg next_da_Ready_for_Data_in = 1'b1;//Ist das Module sendebereit

reg [7:0] next_rs232_Data_in = 8'b0;
reg next_rs232_Data_in_valid = 1'b0;
   
always@(posedge clock)
begin
  if(reset == 1'b0)  // LOW ACTIVE reset !
  begin
    //State
    state <= IDLE_STATE;
    da_Ready_for_Data_in <= 1'b1;
    
    rs232_Data_in <= 8'b0;
    rs232_Data_in_valid <= 1'b0;
  end else 
  begin
    da_Ready_for_Data_in <= next_da_Ready_for_Data_in;
    rs232_Data_in <= next_rs232_Data_in;
    rs232_Data_in_valid <= next_rs232_Data_in_valid;
    state <= next_state;
  end
end

always@(state or rs232_Ready_for_Data_in or rs232_Data_in or da_Data_in_valid or da_Data_in or da_sensor_type or timer_done)
begin
  
  case(state)
    IDLE_STATE://Warten auf Eingabe
    begin
      if(da_Data_in_valid)
		begin
        next_da_Ready_for_Data_in = 1'b0;//Keine weiteren Daten annehmen
		  next_state = BYTE0_SEND_STATE;//Next state
		end else
		begin
		  next_da_Ready_for_Data_in = 1'b1;//Weiterhin Daten annehmen
		  next_state = IDLE_STATE;//Warten
      end
      
      next_rs232_Data_in = rs232_Data_in;
      next_rs232_Data_in_valid = 1'b0;//Nichts versenden
		timer_start = TIMER_ZERO;
    end
    
    BYTE0_SEND_STATE://Bit 8 und 7 bezeichnen den Sensor. Bit 6-0 die ober 6 Bit des ADC Channels
    begin
      if(rs232_Ready_for_Data_in == 1'b1)
      begin
        next_rs232_Data_in = {da_sensor_type, da_Data_in[13:8]};//2 Sensor bits + 6 Bit Daten
        next_rs232_Data_in_valid = 1'b1;//Daten versenden
        next_state = BYTE1_SEND_STATE;//Next state
		  timer_start = TIMER_START;
      end else
      begin
        next_rs232_Data_in = rs232_Data_in;
        next_rs232_Data_in_valid = 1'b0;//Nichts versenden
        next_state = BYTE0_SEND_STATE;//Warten
		  timer_start = TIMER_ZERO;
      end
      next_da_Ready_for_Data_in = 1'b0;//Keine weiteren Daten annehmen
    end
    
    BYTE1_SEND_STATE://Dieses Byte enthaelt die niederwertigen 8 Bit des ADC Channels
    begin
      if(timer_done && rs232_Ready_for_Data_in)
      begin
        next_rs232_Data_in = da_Data_in[7:0];//Untere 8 Bit
        next_rs232_Data_in_valid = 1'b1;//Daten versenden
		  next_da_Ready_for_Data_in = 1'b1;//Wieder Daten annehmen
        next_state = IDLE_STATE;//Wieder in den IDLE
      end else
		begin
		  next_rs232_Data_in = rs232_Data_in;//Nichts senden
		  next_rs232_Data_in_valid = 1'b0;//Nichts senden
		  next_da_Ready_for_Data_in = 1'b0;//Nichts annehmen
		  next_state = BYTE1_SEND_STATE;//Warten
		end
		timer_start = TIMER_ZERO;
    end
    
    default:
    begin
      //extern
		next_state = IDLE_STATE;
      next_rs232_Data_in = 8'b0;
		next_rs232_Data_in_valid = 1'b0;
		next_da_Ready_for_Data_in = 1'b1;
		
		timer_start = TIMER_ZERO;
    end
  endcase
end
   
 endmodule//data_access
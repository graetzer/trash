/*******************************************************************
 *
 *        Module: order_control_test
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
 
 module order_control_test(
   output reg clock,
   //RS232
   output reg rs232_Data_out_valid,// Rx data output valid
   output reg [7:0] rs232_Data_out,// Rx 8 bit data output
	 output wire oc_rotation_on,//Rotation an
	 output wire [7:0] oc_distance,//Distance
	 output wire oc_power,//Power On or Off
	 output wire oc_action,//Wasser oder Duenger
	 
	 //Interne Konfigurationssignale
	 output reg [35:0] sampling_interval,
	 output reg [1:0] sampling_sensor,
	 output reg set_sampling_interval
 );
  
  wire reset = 1'b1;
  
  order_control#(.TIMER_START_PUMP(25'd1),.TIMER_START_ROTATION(25'd1)) receiver_test(
  //Takt und Reset
  .clock(clock),
  .reset(reset),
  
  //RS232
 	.rs232_Data_out_valid(rs232_Data_out_valid),// Rx data output valid
	.rs232_Data_out(rs232_Data_out),      // Rx 8 bit data output
	
	//Order COntrol Signale
	.oc_rotation_on(oc_rotation_on),//Rotation an
	.oc_distance(oc_distance),//Distance
	.oc_power(oc_power),//An und aus Signal
	.oc_action(oc_action),//Wasser oder Duenger
	
	//Messintervallkonfiguration. Messintervall maximal 2^4*5*60*10MHz.
  .sampling_interval(sampling_interval),//Datenleitung fuer einen Konfigurationswert.
  .sampling_sensor(sampling_sensor),//Sensorwahl 
  .set_sampling_interval(set_sampling_interval)//Setze Intervall im adc_controller
	);
	
	always begin
  #5 clock = ~clock;
  end
  
  initial 
  begin
    clock = 1'b1;
    rs232_Data_out_valid = 1'b0;
    
    //Ueberwachen der Werte
    $monitor ("rs232_Data_out_valid=%b,rs232_Data_out=%b,oc_rotation_on=%b,oc_distance=%b,oc_power=%b,oc_action=%b",
    rs232_Data_out_valid,
    rs232_Data_out,
    oc_rotation_on,
    oc_distance,
    oc_power,
    oc_action);
    
    rs232_Data_out = 8'b00100010;
    
    //Ueberwachen ob das Modul erforderliche Aktionen ausfuehrt, anhand der Waveform und der Dokumentation
    repeat(100)
    begin
      #10 rs232_Data_out = rs232_Data_out + 1;
      #100 rs232_Data_out_valid = ~rs232_Data_out_valid;
    end
    
    rs232_Data_out = 8'b00000100;
    repeat(100)
    begin
      #100 rs232_Data_out_valid = ~rs232_Data_out_valid;
    end
    
    $stop;
  end
   
 endmodule// order_control_test
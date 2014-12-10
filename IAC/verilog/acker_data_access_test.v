/*******************************************************************
 *
 *        Module: data_access
 *
 *        Project: Ackerchip
 *
 *        Author: Simon Graetzer <simon.graetzer@googlemail.com>
 *
 *        Testmodul zum Data access
 *
 *******************************************************************/
 `timescale 1ns / 1ps
 
 module data_access_test(
   //Data Input
  output 	wire          da_Ready_for_Data_in,//Ist das Modul Sendebereit?
  output 	reg  [13:0]  da_Data_in,//Dateneingang
  output 	reg		       da_Data_in_valid,//Sind die Daten am Eingang valide?
  output 	reg  [1:0]  da_sensor_type,//Der zu benutzende Datentyp {00, 01, 10, 11}
  
  //RS232 Cables
  output wire rs232_Data_in_valid, // Tx data input valid
  output wire [7:0] rs232_Data_in,       // Tx 8 bit data input
  output reg rs232_Ready_for_Data_in         // RS232 interface ready for Tx
  );
  
  reg clock = 1'b0;
  reg reset = 1'b1;
 
 //RS232 Data Send Controller
  data_access transmission_test(
  //Takt und Reset
  .clock(clock),
  .reset(reset),
  
  //Data Access Module
  .da_Ready_for_Data_in(da_Ready_for_Data_in),//Ist das Modul Sendebereit?
  .da_Data_in(da_Data_in),//Dateneingang
  .da_Data_in_valid(da_Data_in_valid),//Sind die Daten am Eingang valide?
  .da_sensor_type(da_sensor_type),//Der zu benutzende Datentyp {00, 01, 10, 11}
  
  //RS232 Cables
	.rs232_Data_in_valid(rs232_Data_in_valid), // Tx data input valid
	.rs232_Data_in(rs232_Data_in),// Tx 8 bit data input
	.rs232_Ready_for_Data_in(rs232_Ready_for_Data_in)// RS232 interface ready for Tx
  );

  always begin
  #5 clock = ~clock;
  end 
  
  reg [14:0] count = 14'b0;
  reg [1:0] type = 2'b11;
  
  //Einfach nur Warten und auf die Richtigen Daten Testen
  initial 
  begin
    $monitor ("da_Ready_for_Data_in=%b,da_Data_in=%b,da_Data_in_valid=%b,da_Ready_for_Data_in=%b,da_sensor_type=%b,rs232_Data_in_valid=%b,rs232_Data_in=%b,rs232_Ready_for_Data_in=%b",
    da_Ready_for_Data_in,
    da_Data_in,
    da_Data_in_valid,
    da_Ready_for_Data_in,
    da_sensor_type,
    rs232_Data_in_valid,
    rs232_Data_in,
    rs232_Ready_for_Data_in);
    
    rs232_Ready_for_Data_in = 1'b0;
    da_Data_in_valid = 1'b0;
    repeat(10)
    begin
      #5 count = count + 1;
      #5 type = type + 1;
      #5 rs232_Ready_for_Data_in = ~rs232_Ready_for_Data_in;
      
      if(da_Ready_for_Data_in)
      begin
        #10 da_sensor_type = type;
        #10 da_Data_in = count;
        #10 da_Data_in_valid = ~da_Data_in_valid;
      end
    end
    
    $stop;
  end
  
endmodule
  
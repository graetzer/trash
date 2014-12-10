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
 
 module adc_controller_test(
  output reg		    adc_Data_out_valid,//AD Wandler Daten valide
	output reg	[13:0] adc_Data_out_ch0,//AD Channel0
	output reg	[13:0] adc_Data_out_ch1,//AD Channel1 - Das zu Ueberwachende Signal
	
	output reg        da_Ready_for_Data_in,
  output wire  [13:0] da_Data_in,
  output wire		   da_Data_in_valid,
  output wire  [1:0]  da_sensor_type//Tatsaechlicher Sensor 
 );
   
  reg clock = 1'b0;
  reg reset = 1'b1;
	
	//////ADC///
//  wire SPI_SCK;
//  wire AD_conv;
//  wire SPI_MISO;
//  //Verhaltensmodell Simulation
//  LTC1407A1_sim adc_simulator( 
//  .SPI_SCK(SPI_SCK),
//  .AD_conv(AD_conv),
//  .SPI_MISO(SPI_MISO)
//  );
//    
//  //Top module for the LTC1407A-1 ADCs
//  adc adc_top (
//  .clock(clock),
//  .reset(reset),
//	.Data_out_valid(adc_Data_out_valid), 
//	.Data_out_ch0(adc_Data_out_ch0), 
//	.Data_out_ch1(adc_Data_out_ch1),
//	.AD_conv(AD_conv), 
//	.SPI_SCK(SPI_SCK), 
//	.SPI_MISO(SPI_MISO)
//	);
// 

wire [35:0] sampling_interval = 36'd2;
reg [1:0] sampling_sensor = 2'b0;
reg set_sampling_interval;

  adc_controller  ADControl (
  //Takt und Reset
  .clock(clock),
  .reset(reset),
  
  //ADC
 	.adc_Data_out_valid(adc_Data_out_valid),//AD Wandler Daten valide
	.adc_Data_out_ch0(adc_Data_out_ch0),//AD Channel0
	.adc_Data_out_ch1(adc_Data_out_ch1),//AD Channel1 - Das zu Ueberwachende Signal

  //Data Access Module
  .da_Ready_for_Data_in(da_Ready_for_Data_in),
  .da_Data_in(da_Data_in),
  .da_Data_in_valid(da_Data_in_valid),
  .da_sensor_type(da_sensor_type),
  
   	//Messintervallkonfiguration. Messintervall maximal 2^4*5*60*10MHz.
  .sampling_interval(sampling_interval),//Datenleitung fuer einen Konfigurationswert.
  .sampling_sensor(sampling_sensor),//Sensorwahl 
  .set_sampling_interval(set_sampling_interval)//Setze Intervall im adc_controller
);

  always begin
  #5 clock = ~clock;
  end 
  
  reg [14:0] counter = 14'b0;
  //assign da_Ready_for_Data_in = 1'b1;//Daten immer Senden
  //Einfach nur Warten und auf die Richtigen Daten Testen
  initial 
  begin
    $monitor ("adc_Data_out_valid=%b,adc_Data_out_ch0=%b,adc_Data_out_ch1=%b,da_Ready_for_Data_in=%b,da_Data_in=%b,da_Data_in_valid=%b,da_sensor_type=%b",
    adc_Data_out_valid,
    adc_Data_out_ch0,
    adc_Data_out_ch1,
    da_Ready_for_Data_in,
    da_Data_in,
    da_Data_in_valid,
    da_sensor_type);
    
    da_Ready_for_Data_in = 1'b0;
    adc_Data_out_valid = 1'b1;
    
    #10 set_sampling_interval = 1'b1;
    #10 sampling_sensor = 2'b00;
    #10 set_sampling_interval = 1'b0;
    #10 set_sampling_interval = 1'b1;
    #10 sampling_sensor = 2'b01;
    #10 set_sampling_interval = 1'b0;
    #10 set_sampling_interval = 1'b1;
    #10 sampling_sensor = 2'b10;
    #10 set_sampling_interval = 1'b0;
    #10 set_sampling_interval = 1'b1;
    #10 sampling_sensor = 2'b11;
    #10 set_sampling_interval = 1'b0;
    
    repeat(100)
    begin
      adc_Data_out_ch0 = counter;
      adc_Data_out_ch1 = counter + 1;
      
      #100 da_Ready_for_Data_in = ~da_Ready_for_Data_in;
      #100 adc_Data_out_valid = ~adc_Data_out_valid;
      #100 counter = counter + 1;
    end
    $stop;
  end
   
 endmodule//adc_controller_test
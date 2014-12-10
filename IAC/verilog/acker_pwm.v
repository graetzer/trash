
/*******************************************************************
 *
 *        Module: Pulsweitenmodulation
 *
 *        Project: Ackerchip
 *
 *        Author: 
 *
 *        Das Modul implementiert einen Pulsweitenmodulation.
 *			 Dadurch wird das Ansteuern eines Auslassventiles moeglich
 *
 *******************************************************************/
 
 `timescale 1ns / 1ps
 
 module PWM (
    // Takt und Reset
    input	 wire	 clock,
    input  wire		reset,
    
    input wire power,
    
    input wire [7:0] voltage,
    output reg analogOutput
  );
  
  reg [7:0] count = 8'b0;
  
  always @(posedge clock)
  begin
    if(reset == 1'b0)  // LOW ACTIVE reset !
      count <= 8'b0;
    else
    begin
      if(voltage > count)
        analogOutput <= 1'b1 & power;
      else
        analogOutput <= 1'b0;
       
      count <= count + 1;
    end
  end // always @ (posedge clock)
  
endmodule //module PWM
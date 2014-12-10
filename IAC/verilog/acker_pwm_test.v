 

/*******************************************************************
 *
 *        Module: Pulsweitenmodulation Test
 *
 *        Project: Ackerchip
 *
 *        Author: 
 *
 *        Das Modul vereinfacht das ueberwachen eines Sensors 
 *        Wenn man dem Modul ein Signal des AD Umwandlers zuteilt, wird dieses Modul
 *        in Abstataenden von 16 Sekunden versuchen die Daten des Sendors zun  lesen und zu speichern.
 *        Eventuelles Steuern von externen Multiplexern und die synchronisation beim Speicherzugriff
 *        zwischen den EInzelnen Sensor_Observer Modulinstanzen, wird auf einer hoeheren Modulebene gehandhabt.
 *
 *******************************************************************/
 
 `timescale 1ns / 1ps
 
 module PWM_Test(
 output reg clock,
 output reg [7:0] voltage,
 output wire analogOutput
 );
 
  reg reset = 1'b1;
  wire power = 1'b1;
 
  PWM pwm_test(
    
    // Takt und Reset
    .clock(clock),
    .reset(reset),
    .power(power),
    .voltage(voltage),
    .analogOutput(analogOutput)
  );

  always begin
  #5 clock = ~clock;
  end 
  
  reg [7:0] count = 8'b0;
  
  initial begin
    clock = 1'b0;
    voltage = 8'd0;
    repeat(10)
    begin
      #5000 voltage = count;
      #5000 count = count + 1;
    end
    $stop;
  end

endmodule
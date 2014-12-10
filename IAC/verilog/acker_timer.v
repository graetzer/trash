/*****************************************************************************
 *
 *        Project: Ackerchip
 *
 *        Module: Acker_Timer
 *
 *        Author: Markus Holz (holz@ims.uni-hannover.de)
 *
 *****************************************************************************
 **
 ** Beschreibung:
 ** Mit dem Timermodul koennen Wartezyklen in variabler Laenge realisiert
 ** werden. Die maximale Laenge kann ueber den Parameter TIMER_WIDTH
 ** eingestellt werden. Der Timers startet, sobald der Eingang "start" einen
 ** Wert ungleich Null hat. Ein Neustart des Timers ist jederzeit moeglich.
 ** Waehrend der Timer laeuft muss der Eingang "start" den Wert 0 haben!
 ** Der Ablauf des Timer wird mit "done=1" signalisiert.
 **
 *****************************************************************************/

`timescale 1ns / 1ps

module Acker_Timer (clock, reset,
					start, done
				   );

// Modulparameter
parameter TIMER_WIDTH = 26; // default: TIMER_WIDTH = 26
//26'd7_999_999 = 2 Sekunden;

// Eingaenge *****************************************
input clock, reset;
input [TIMER_WIDTH-1:0] start;

// Ausgaenge *****************************************
output done;

// Interne Verbindungen / Register *******************************************
reg done;
reg [TIMER_WIDTH-1:0] counter, counter_next;

// Sequenzieller Block (Register) ********************************************
always @(posedge clock)
  begin
	if (reset == 1'b0)  // LOW ACTIVE reset !
	  counter <= {TIMER_WIDTH{1'b0}};
	else
	  counter <= counter_next;
  end // always @ (posedge clock)

// Kombinatorischer Block I (Berechung des Zaehlers) **************************
always @(counter or start)
  begin

	if (start != {TIMER_WIDTH{1'b0}})
	  counter_next = start;           // starte Timer
	else if (counter != {TIMER_WIDTH{1'b0}})
	  counter_next = counter - 1'b1;  // Timer laeuft
	else
	  counter_next = counter;         // Timer gestoppt

  end // always @ (counter or start)

// Kombinatorischer Block II ("done" Signal) **********************************
always @(counter)  // Das "done" Signal haengt nur von "counter" ab, da sonst
                   // ein kombinatorischer Pfad durch das Timermodul ensteht!
  begin

	if (counter == {TIMER_WIDTH{1'b0}})
	  done = 1'b1;  // Timer abgelaufen
	else
	  done = 1'b0;  // Timer laeuft noch

  end // always @ (counter or start)

endmodule // Acker_Timer

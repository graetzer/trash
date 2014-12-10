using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace IAC {
    public class RS232COM {

        #region Variablen & Objekte

        //*********************
        //Variablen & Objekte
        //*********************

        private SerialPort comPort = new SerialPort();
        private Messwertverwaltung Mwv;

        private byte state_current = state_idle;
        private Int16 value = 0;

        private const byte state_wTemperatur = 0x00;
        private const byte state_wLichtstärke = 0x01;
        private const byte state_wFeuchtigkeit = 0x02;
        private const byte state_wDünger = 0x03;
        private const byte state_idle = 0x04;

        #endregion

        #region Konstruktoren

        //*********************
        //Konstruktoren
        //*********************

        public RS232COM(Messwertverwaltung Mwv, int baudRate, string stopBits, int dataBits) {
            this.Mwv = Mwv;
            this.comPort.BaudRate = baudRate;
            this.comPort.DataBits = dataBits;
            this.comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);

            for(int i = 1; i < 10; i++){
                try {
                    this.comPort.PortName = "COM" + i.ToString();
                    this.comPort.Open();
                }
                catch { }
                this.comPort.DataReceived += new SerialDataReceivedEventHandler(this.DataReceived);
            }
            if(!this.comPort.IsOpen)
                MessageBox.Show("COM Port anschliessen!");
        }

        #endregion

        #region Methoden

        //*********************
        //Methoden
        //*********************

        public void WriteData(byte data) {
            byte[] tmp = {data};
            this.comPort.Write(tmp, 0, 1);
        }

        private void Auswerten(byte data) {
            if (data != 0x00)
            {
                if (this.state_current == state_idle)
                {
                    value = (Int16)((data & 0x3F) << 8);
                    data = (byte)(data & 0xC0);
                    /*if (data == 0x00)
                        this.state_current = state_wTemperatur;
                    else if (data == 0x40)
                        this.state_current = state_wLichtstärke;
                    else if (data == 0x80)
                        this.state_current = state_wFeuchtigkeit;
                    else
                        this.state_current = state_wDünger;*/
                    this.state_current = state_wLichtstärke;
                }
                else
                {
                    if (this.state_current == state_wTemperatur)
                        this.Mwv.AddTemperatur((Int16)(value | data));
                    else if (this.state_current == state_wLichtstärke)
                        this.Mwv.AddLichtstärke((Int16)(value | data));
                    else if (this.state_current == state_wFeuchtigkeit)
                        this.Mwv.AddFeuchtigkeit((Int16)(value | data));
                    else if (this.state_current == state_wDünger)
                        this.Mwv.AddDünger((Int16)(value | data));
                    this.state_current = state_idle;
                }
            }
        }

        #endregion

        #region EventHandler

        //*********************
        //EventHändler
        //*********************

        private void DataReceived(object sender, SerialDataReceivedEventArgs e) {
            this.Auswerten((byte)comPort.ReadByte());
        }

        #endregion

    }
}

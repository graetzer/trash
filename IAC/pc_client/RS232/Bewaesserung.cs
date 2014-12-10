using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace IAC {
    public partial class Bewässerung : Form {


        #region Variablen & Objekte

        //*********************
        //Variablen & Objekte
        //*********************

        private RS232COM ComPort;

        #endregion

        #region Konstruktoren

        //*********************
        //Konstruktoren
        //*********************

        public Bewässerung(RS232COM ComPort) {
            InitializeComponent();
            this.ComPort = ComPort;
        }

        #endregion

        private void btnLos_Click(object sender, EventArgs e) {
            byte send = (byte)((Convert.ToInt16(this.tbDauer.Text) >> 1) & 0x1F);
            if (this.cbDünger.Checked)
                send |= 0x20;
            this.ComPort.WriteData(send);
            Thread.Sleep(100);
            this.ComPort.WriteData((byte)((Convert.ToInt16(this.tbWinkel.Text)*256)/360));
            Thread.Sleep(100);
            this.ComPort.WriteData((byte)(Convert.ToInt16(this.tbEntfernung.Text) >> 1));
            this.Close();
        }


        #region Get/Set

        //*********************
        //Get/Set
        //*********************


        #endregion

        #region Methoden

        //*********************
        //Methoden
        //*********************


        #endregion
    }
}

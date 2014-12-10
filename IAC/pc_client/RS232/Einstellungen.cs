using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace IAC {
    public partial class Einstellungen : Form {

        #region Variablen & Objekte

        //*********************
        //Variablen & Objekte
        //*********************

        MainForm mf;

        #endregion

        #region Konstruktoren

        //*********************
        //Konstruktoren
        //*********************

        public Einstellungen(MainForm mf) {
            InitializeComponent();
            this.mf = mf;
            this.tbDünger.Text = this.mf.DüngerIntervall.ToString();
            this.tbFeuchtigkeit.Text = this.mf.FeuchtigkeitIntervall.ToString();
            this.tbLicht.Text = this.mf.LichtIntervall.ToString();
            this.tbTemperatur.Text = this.mf.TemperaturIntervall.ToString();
        }

        #endregion

        #region Methoden

        //*********************
        //Methoden
        //*********************

        public void SetIntervalls() {
            this.mf.schnittStelle.WriteData((byte)(0x40 | ((Convert.ToInt16(this.mf.TemperaturIntervall) / 5) & 0x0F)));
            Thread.Sleep(100);
            this.mf.schnittStelle.WriteData((byte)(0x50 | ((Convert.ToInt16(this.mf.LichtIntervall) / 5) & 0x0F)));
            Thread.Sleep(100);
            this.mf.schnittStelle.WriteData((byte)(0x60 | ((Convert.ToInt16(this.mf.FeuchtigkeitIntervall) / 5) & 0x0F)));
            Thread.Sleep(100);
            this.mf.schnittStelle.WriteData((byte)(0x70 | ((Convert.ToInt16(this.mf.DüngerIntervall) / 5) & 0x0F)));
        }

        #endregion

        #region EventHändler

        //*********************
        //EventHändler
        //*********************

        private void btnOk_Click(object sender, EventArgs e) {
            try {
                this.mf.TemperaturIntervall = Convert.ToSingle(this.tbTemperatur.Text);
            }
            catch { }
            try {
                this.mf.FeuchtigkeitIntervall = Convert.ToSingle(this.tbFeuchtigkeit.Text);
            }
            catch { }
            try {
                this.mf.DüngerIntervall = Convert.ToSingle(this.tbDünger.Text);
            }
            catch { }
            try {
                this.mf.LichtIntervall = Convert.ToSingle(this.tbLicht.Text);
            }
            catch { }
            this.SetIntervalls();
            this.Close();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion
    }
}

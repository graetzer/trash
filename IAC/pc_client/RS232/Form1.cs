using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using IAC.CsHTTPServer;
using System.Threading;

namespace IAC{
    public partial class MainForm : Form{

        #region Variablen & Objekte

        //*********************
        //Variablen & Objekte
        //*********************

        public RS232COM schnittStelle;
        private Messwertverwaltung Mwv;

        public IACServer server;

        public float TemperaturIntervall = 0;
        public float LichtIntervall = 2;
        public float FeuchtigkeitIntervall = 0;
        public float DüngerIntervall = 0;

        #endregion

        #region Konstruktoren

        //*********************
        //Konstruktoren
        //*********************

        public MainForm(){
            InitializeComponent();
        }

        #endregion

        #region Methoden

        //*********************
        //Methoden
        //*********************


        #endregion

        #region EventHändler

        //*********************
        //EventHändler
        //*********************

        private void btnWässern_Click(object sender, EventArgs e) {
            Bewässerung bw = new Bewässerung(this.schnittStelle);
            bw.Show();
        }

        private void btnEinstellungen_Click(object sender, EventArgs e) {
            Einstellungen ein = new Einstellungen(this);
            ein.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Intervalle.inf");
                sw.WriteLine(this.TemperaturIntervall.ToString());
                sw.WriteLine(this.FeuchtigkeitIntervall.ToString());
                sw.WriteLine(this.DüngerIntervall.ToString());
                sw.WriteLine(this.LichtIntervall.ToString());
                sw.Close();
            }
            catch { }
            server.Stop();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            try {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\Intervalle.inf");
                this.TemperaturIntervall = Convert.ToSingle(sr.ReadLine());
                this.FeuchtigkeitIntervall = Convert.ToSingle(sr.ReadLine());
                this.DüngerIntervall = Convert.ToSingle(sr.ReadLine());
                this.LichtIntervall = Convert.ToSingle(sr.ReadLine());
                sr.Close();
            }
            catch { }
            this.Mwv = new Messwertverwaltung(this, this.TemperaturIntervall, this.LichtIntervall, this.FeuchtigkeitIntervall, this.DüngerIntervall);
            this.schnittStelle = new RS232COM(this.Mwv, 115200, "1", 8);

            this.server = new IACServer(8080, this.Mwv, this.schnittStelle);
            this.server.Start();
        }

        private void btnOptimierung_Click(object sender, EventArgs e) {
            Optimierung opt = new Optimierung(this.Mwv);
            opt.Show();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            this.Mwv.LichtXPosition = 0;
            this.ccLichtstrom.startNewSeries();
        }

        #endregion

        Random rnd = new Random();
        private void testTimer_Tick(object sender, EventArgs e)
        {
            
            if (testCheck.Checked)
            {
                int duration = 2;
                int movement = rnd.Next(359);
                int width = 150;

                byte send = (byte)((Convert.ToInt16(duration) >> 1) & 0x1F);
                this.schnittStelle.WriteData(send);
                Thread.Sleep(100);
                this.schnittStelle.WriteData((byte)((Convert.ToInt16(movement) * 256) / 360));
                Thread.Sleep(100);
                this.schnittStelle.WriteData((byte)(Convert.ToInt16(width) >> 1));

            }
        }
    }
}

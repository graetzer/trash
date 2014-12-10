using System;
using System.Drawing;
using System.Windows.Forms;

namespace IAC {
    public partial class Optimierung : Form {

        #region Variablen & Objekte

        //*********************
        //Variablen & Objekte
        //*********************

        private Messwertverwaltung mwv;

        private string pflanzenart;
        private float temperatur;
        private float lichtenergie;
        private float feuchtigkeit;
        private float dünger;
        private float anpflanzungspreis;
        private float erntekosten;
        private float ertrag;

        private Pen FixkostenPen = new Pen(Color.Red, 3f);
        private Pen VariablekostenPen = new Pen(Color.Purple, 2f);
        private Pen ErtragPen = new Pen(Color.Green, 2f);
        private Pen GesammtkostenPen = new Pen(Color.Black, 4f);

        #endregion

        #region Konstruktoren

        //*********************
        //Konstruktoren
        //*********************

        public Optimierung(Messwertverwaltung mwv) {
            InitializeComponent();
            this.mwv = mwv;
            this.tbdTemperatur.Text =  "14";
            this.tbdLicht.Text =  this.mwv.GetDurschnittsLicht().ToString();
            this.tbdFeuchtigkeit.Text = "12";
            this.tbdDünger.Text =  "17";
            //NAme Temp Licht Feuchte Duenger Kosten Wasseek Ertrag
            this.dgvPflanzen.Rows.Add(new String[] {"Kartoffeln", "15", "1000", "50", "30", "10", "20", "40"});
            this.dgvPflanzen.Rows.Add(new String[] {"Mais", "17", "1230", "60", "50", "20", "20", "50" });
            this.cbAktualisieren();
        }

        #endregion

        #region Methoden

        //*********************
        //Methoden
        //*********************

        private void Aktualisieren() {
            try {
                double tmp = 0;
                this.pflanzenart = this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[0].Value.ToString();
                this.temperatur = Convert.ToSingle(this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[1].Value);
                this.lichtenergie = Convert.ToSingle(this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[2].Value);
                this.feuchtigkeit = Convert.ToSingle(this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[3].Value);
                this.dünger = Convert.ToSingle(this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[4].Value);
                this.anpflanzungspreis = Convert.ToSingle(this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[5].Value);
                this.erntekosten = Convert.ToSingle(this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[6].Value);
                this.ertrag = Convert.ToSingle(this.dgvPflanzen.Rows[this.cbPflanzenauswahl.SelectedIndex].Cells[7].Value);

                this.tbaAnpflanzungskosten.Text = (this.anpflanzungspreis * Convert.ToDouble(this.tbFeldgröße.Text) * 10000).ToString();
                this.tbaErntekosten.Text = (this.erntekosten * Convert.ToDouble(this.tbFeldgröße.Text) * 10000).ToString();
                this.tbaTage.Text = ((this.lichtenergie / Convert.ToDouble(this.tbdLicht.Text)) / 24.0).ToString();
                tmp = (this.feuchtigkeit - Convert.ToDouble(this.tbdFeuchtigkeit.Text)) * Convert.ToDouble(this.tbFeldgröße.Text) * Convert.ToDouble(this.tbWasserpreis.Text) * Convert.ToDouble(this.tbaTage.Text);
                if (tmp < 0)
                    tmp = 0;
                this.tbaWasserkosten.Text = tmp.ToString();
                tmp = (this.dünger - Convert.ToDouble(this.tbdDünger.Text)) * Convert.ToDouble(this.tbFeldgröße.Text) * Convert.ToDouble(this.tbDüngerpreis.Text) * Convert.ToDouble(this.tbaTage.Text);
                if (tmp < 0)
                    tmp = 0;
                this.tbaDüngerkosten.Text = tmp.ToString();
                this.tbaVariablekosten.Text = (Convert.ToDouble(this.tbaAnpflanzungskosten.Text) + Convert.ToDouble(this.tbaErntekosten.Text) + Convert.ToDouble(this.tbaWasserkosten.Text) + Convert.ToDouble(this.tbaDüngerkosten.Text)).ToString();
                this.tbaFixkosten.Text = this.tbFixkosten.Text;
                this.tbaGesammtkosten.Text = (Convert.ToDouble(this.tbaFixkosten.Text) + Convert.ToDouble(this.tbaVariablekosten.Text)).ToString();
                tmp = this.temperatur - Convert.ToDouble(this.tbdTemperatur.Text);
                if (tmp < 0)
                    tmp = -tmp;
                if (tmp > 10)
                    this.tbaErtrag.Text = "0";
                else
                    this.tbaErtrag.Text = (this.ertrag * (1 - 0.1 * tmp) * Convert.ToDouble(this.tbFeldgröße.Text) * 10000).ToString();
                this.tbaUmsatz.Text = (Convert.ToDouble(this.tbaGesammtkosten.Text) + Convert.ToDouble(this.tbaErtrag.Text)).ToString();
                this.tbaGewinn.Text = (Convert.ToDouble(this.tbaErtrag.Text) - Convert.ToDouble(this.tbaGesammtkosten.Text)).ToString();
                this.tbaGewinnprotag.Text = (Convert.ToDouble(this.tbaGewinn.Text) / Convert.ToDouble(this.tbaTage.Text)).ToString();
                this.pbKostenrechnung.Refresh();
            } catch (FormatException e) {
                MessageBox.Show("Bitte füllen sie die komplette Reihe in der Tabelle aus");
            }
        }

        private void cbAktualisieren() {
            this.cbPflanzenauswahl.Items.Clear();
            for (int i = 0; i < this.dgvPflanzen.Rows.Count; i++) {
                DataGridViewCell cell = this.dgvPflanzen.Rows[i].Cells[0];
                Object value = cell.Value;
                if (value != null)
                    this.cbPflanzenauswahl.Items.Add(value.ToString());
            }
        }

        #endregion

        #region EventHändler

        //*********************
        //EventHändler
        //*********************

        private void cbPflanzenauswahl_SelectedIndexChanged(object sender, EventArgs e) {
            this.Aktualisieren();
        }

        private void dgvPflanzen_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 0) {
                this.cbAktualisieren();
            }
        }

        private void pbKostenrechnung_Paint(object sender, PaintEventArgs e) {
            Graphics screen = e.Graphics;
            screen.TranslateTransform(0f, Convert.ToSingle(screen.ClipBounds.Height));

            if (!String.IsNullOrEmpty(this.tbaUmsatz.Text) && !String.IsNullOrEmpty(this.tbFixkosten.Text)) {
                int tmp;
                double anteil = Convert.ToDouble(screen.ClipBounds.Height) / Convert.ToDouble(this.tbaUmsatz.Text);
                screen.Clear(this.pbKostenrechnung.BackColor);
                tmp = Convert.ToInt32(Convert.ToDouble(this.tbFixkosten.Text) * anteil);
                screen.DrawLine(this.FixkostenPen, new Point(0, -tmp), new Point(this.pbKostenrechnung.Width, -tmp));
                screen.DrawLine(this.VariablekostenPen, new Point(0, 0), new Point(this.pbKostenrechnung.Width, -(Convert.ToInt32(Convert.ToDouble(this.tbaVariablekosten.Text) * anteil))));
                screen.DrawLine(this.ErtragPen, new Point(0, 0), new Point(this.pbKostenrechnung.Width, -(Convert.ToInt32(Convert.ToDouble(this.tbaErtrag.Text) * anteil))));
                screen.DrawLine(this.GesammtkostenPen, new Point(0, -tmp), new Point(this.pbKostenrechnung.Width, -(Convert.ToInt32(Convert.ToDouble(this.tbaGesammtkosten.Text) * anteil))));
            }
        }

        #endregion
    }
}

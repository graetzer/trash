namespace IAC {
    partial class Optimierung {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dgvPflanzen = new System.Windows.Forms.DataGridView();
            this.PflanzenArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperatur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lichtenergie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Feuchtigkeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dünger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anpflanzungspreis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erntekosten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ertrag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbKostenrechnung = new System.Windows.Forms.PictureBox();
            this.cbPflanzenauswahl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbFixkosten = new System.Windows.Forms.TextBox();
            this.tbFeldgröße = new System.Windows.Forms.TextBox();
            this.tbWasserpreis = new System.Windows.Forms.TextBox();
            this.tbDüngerpreis = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbaWasserkosten = new System.Windows.Forms.TextBox();
            this.tbaDüngerkosten = new System.Windows.Forms.TextBox();
            this.tbaAnpflanzungskosten = new System.Windows.Forms.TextBox();
            this.tbaErntekosten = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbaVariablekosten = new System.Windows.Forms.TextBox();
            this.tbaFixkosten = new System.Windows.Forms.TextBox();
            this.tbaGesammtkosten = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbaErtrag = new System.Windows.Forms.TextBox();
            this.tbaUmsatz = new System.Windows.Forms.TextBox();
            this.tbaGewinn = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tbaGewinnprotag = new System.Windows.Forms.TextBox();
            this.Durchschnittswerte = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tbdTemperatur = new System.Windows.Forms.TextBox();
            this.tbdLicht = new System.Windows.Forms.TextBox();
            this.tbdFeuchtigkeit = new System.Windows.Forms.TextBox();
            this.tbdDünger = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tbaTage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPflanzen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKostenrechnung)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPflanzen
            // 
            this.dgvPflanzen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPflanzen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PflanzenArt,
            this.Temperatur,
            this.Lichtenergie,
            this.Feuchtigkeit,
            this.Dünger,
            this.Anpflanzungspreis,
            this.Erntekosten,
            this.Ertrag});
            this.dgvPflanzen.Location = new System.Drawing.Point(12, 12);
            this.dgvPflanzen.Name = "dgvPflanzen";
            this.dgvPflanzen.Size = new System.Drawing.Size(845, 276);
            this.dgvPflanzen.TabIndex = 0;
            this.dgvPflanzen.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPflanzen_CellEndEdit);
            // 
            // PflanzenArt
            // 
            this.PflanzenArt.HeaderText = "Pflanzen Art";
            this.PflanzenArt.Name = "PflanzenArt";
            // 
            // Temperatur
            // 
            this.Temperatur.HeaderText = "Temperatur (°C)";
            this.Temperatur.Name = "Temperatur";
            // 
            // Lichtenergie
            // 
            this.Lichtenergie.HeaderText = "Lichtenergie  (lm * h)";
            this.Lichtenergie.Name = "Lichtenergie";
            // 
            // Feuchtigkeit
            // 
            this.Feuchtigkeit.HeaderText = "Feuchtigkeit   (%)";
            this.Feuchtigkeit.Name = "Feuchtigkeit";
            // 
            // Dünger
            // 
            this.Dünger.HeaderText = "Dünger       (ppm)";
            this.Dünger.Name = "Dünger";
            // 
            // Anpflanzungspreis
            // 
            this.Anpflanzungspreis.HeaderText = "Anpflanzungspreis (EUR / m^2)";
            this.Anpflanzungspreis.Name = "Anpflanzungspreis";
            // 
            // Erntekosten
            // 
            this.Erntekosten.HeaderText = "Erntekosten (EUR / m^2)";
            this.Erntekosten.Name = "Erntekosten";
            // 
            // Ertrag
            // 
            this.Ertrag.HeaderText = "Ertrag        (EUR / m^2)";
            this.Ertrag.Name = "Ertrag";
            // 
            // pbKostenrechnung
            // 
            this.pbKostenrechnung.BackColor = System.Drawing.Color.White;
            this.pbKostenrechnung.Location = new System.Drawing.Point(12, 294);
            this.pbKostenrechnung.Name = "pbKostenrechnung";
            this.pbKostenrechnung.Size = new System.Drawing.Size(657, 403);
            this.pbKostenrechnung.TabIndex = 1;
            this.pbKostenrechnung.TabStop = false;
            this.pbKostenrechnung.Paint += new System.Windows.Forms.PaintEventHandler(this.pbKostenrechnung_Paint);
            // 
            // cbPflanzenauswahl
            // 
            this.cbPflanzenauswahl.FormattingEnabled = true;
            this.cbPflanzenauswahl.Location = new System.Drawing.Point(675, 294);
            this.cbPflanzenauswahl.Name = "cbPflanzenauswahl";
            this.cbPflanzenauswahl.Size = new System.Drawing.Size(182, 21);
            this.cbPflanzenauswahl.TabIndex = 2;
            this.cbPflanzenauswahl.SelectedIndexChanged += new System.EventHandler(this.cbPflanzenauswahl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(863, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fixkosten:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(675, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Variable Kosten:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(863, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Feldgröße: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(675, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Wasserkosten:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(675, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Düngungskosten:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(675, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Anpflanzungskosten:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Erntekosten:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(675, 476);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Fixkosten:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(675, 547);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Ertrag:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(675, 521);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Gesammtkosten:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(675, 573);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Umsatz:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(675, 599);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Gewinn:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(863, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Wasserpreis:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(863, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Düngerpreis:";
            // 
            // tbFixkosten
            // 
            this.tbFixkosten.Location = new System.Drawing.Point(945, 15);
            this.tbFixkosten.Name = "tbFixkosten";
            this.tbFixkosten.Size = new System.Drawing.Size(100, 20);
            this.tbFixkosten.TabIndex = 17;
            // 
            // tbFeldgröße
            // 
            this.tbFeldgröße.Location = new System.Drawing.Point(945, 41);
            this.tbFeldgröße.Name = "tbFeldgröße";
            this.tbFeldgröße.Size = new System.Drawing.Size(100, 20);
            this.tbFeldgröße.TabIndex = 18;
            // 
            // tbWasserpreis
            // 
            this.tbWasserpreis.Location = new System.Drawing.Point(945, 67);
            this.tbWasserpreis.Name = "tbWasserpreis";
            this.tbWasserpreis.Size = new System.Drawing.Size(100, 20);
            this.tbWasserpreis.TabIndex = 19;
            // 
            // tbDüngerpreis
            // 
            this.tbDüngerpreis.Location = new System.Drawing.Point(945, 93);
            this.tbDüngerpreis.Name = "tbDüngerpreis";
            this.tbDüngerpreis.Size = new System.Drawing.Size(100, 20);
            this.tbDüngerpreis.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1051, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "EUR";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1051, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Hektar";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1051, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "EUR / m³";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1051, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "EUR / kg";
            // 
            // tbaWasserkosten
            // 
            this.tbaWasserkosten.Location = new System.Drawing.Point(784, 324);
            this.tbaWasserkosten.Name = "tbaWasserkosten";
            this.tbaWasserkosten.ReadOnly = true;
            this.tbaWasserkosten.Size = new System.Drawing.Size(73, 20);
            this.tbaWasserkosten.TabIndex = 25;
            // 
            // tbaDüngerkosten
            // 
            this.tbaDüngerkosten.Location = new System.Drawing.Point(784, 350);
            this.tbaDüngerkosten.Name = "tbaDüngerkosten";
            this.tbaDüngerkosten.ReadOnly = true;
            this.tbaDüngerkosten.Size = new System.Drawing.Size(73, 20);
            this.tbaDüngerkosten.TabIndex = 26;
            // 
            // tbaAnpflanzungskosten
            // 
            this.tbaAnpflanzungskosten.Location = new System.Drawing.Point(784, 376);
            this.tbaAnpflanzungskosten.Name = "tbaAnpflanzungskosten";
            this.tbaAnpflanzungskosten.ReadOnly = true;
            this.tbaAnpflanzungskosten.Size = new System.Drawing.Size(73, 20);
            this.tbaAnpflanzungskosten.TabIndex = 27;
            // 
            // tbaErntekosten
            // 
            this.tbaErntekosten.Location = new System.Drawing.Point(784, 402);
            this.tbaErntekosten.Name = "tbaErntekosten";
            this.tbaErntekosten.ReadOnly = true;
            this.tbaErntekosten.Size = new System.Drawing.Size(73, 20);
            this.tbaErntekosten.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(778, 425);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "____________";
            // 
            // tbaVariablekosten
            // 
            this.tbaVariablekosten.Location = new System.Drawing.Point(784, 447);
            this.tbaVariablekosten.Name = "tbaVariablekosten";
            this.tbaVariablekosten.ReadOnly = true;
            this.tbaVariablekosten.Size = new System.Drawing.Size(73, 20);
            this.tbaVariablekosten.TabIndex = 30;
            // 
            // tbaFixkosten
            // 
            this.tbaFixkosten.Location = new System.Drawing.Point(784, 473);
            this.tbaFixkosten.Name = "tbaFixkosten";
            this.tbaFixkosten.ReadOnly = true;
            this.tbaFixkosten.Size = new System.Drawing.Size(73, 20);
            this.tbaFixkosten.TabIndex = 31;
            // 
            // tbaGesammtkosten
            // 
            this.tbaGesammtkosten.Location = new System.Drawing.Point(784, 518);
            this.tbaGesammtkosten.Name = "tbaGesammtkosten";
            this.tbaGesammtkosten.ReadOnly = true;
            this.tbaGesammtkosten.Size = new System.Drawing.Size(73, 20);
            this.tbaGesammtkosten.TabIndex = 32;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(778, 496);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "____________";
            // 
            // tbaErtrag
            // 
            this.tbaErtrag.Location = new System.Drawing.Point(784, 544);
            this.tbaErtrag.Name = "tbaErtrag";
            this.tbaErtrag.ReadOnly = true;
            this.tbaErtrag.Size = new System.Drawing.Size(73, 20);
            this.tbaErtrag.TabIndex = 34;
            // 
            // tbaUmsatz
            // 
            this.tbaUmsatz.Location = new System.Drawing.Point(784, 570);
            this.tbaUmsatz.Name = "tbaUmsatz";
            this.tbaUmsatz.ReadOnly = true;
            this.tbaUmsatz.Size = new System.Drawing.Size(73, 20);
            this.tbaUmsatz.TabIndex = 35;
            // 
            // tbaGewinn
            // 
            this.tbaGewinn.Location = new System.Drawing.Point(784, 596);
            this.tbaGewinn.Name = "tbaGewinn";
            this.tbaGewinn.ReadOnly = true;
            this.tbaGewinn.Size = new System.Drawing.Size(73, 20);
            this.tbaGewinn.TabIndex = 36;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(827, 678);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(30, 13);
            this.label22.TabIndex = 38;
            this.label22.Text = "EUR";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(675, 651);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "Gewinn pro Tag:";
            // 
            // tbaGewinnprotag
            // 
            this.tbaGewinnprotag.Location = new System.Drawing.Point(784, 648);
            this.tbaGewinnprotag.Name = "tbaGewinnprotag";
            this.tbaGewinnprotag.ReadOnly = true;
            this.tbaGewinnprotag.Size = new System.Drawing.Size(73, 20);
            this.tbaGewinnprotag.TabIndex = 40;
            // 
            // Durchschnittswerte
            // 
            this.Durchschnittswerte.AutoSize = true;
            this.Durchschnittswerte.Location = new System.Drawing.Point(874, 297);
            this.Durchschnittswerte.Name = "Durchschnittswerte";
            this.Durchschnittswerte.Size = new System.Drawing.Size(101, 13);
            this.Durchschnittswerte.TabIndex = 41;
            this.Durchschnittswerte.Text = "Durchschnittswerte:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(928, 327);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 13);
            this.label23.TabIndex = 42;
            this.label23.Text = "Temperatur:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(928, 353);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 13);
            this.label24.TabIndex = 43;
            this.label24.Text = "Lichtstrom:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(928, 379);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 13);
            this.label25.TabIndex = 44;
            this.label25.Text = "Feuchtigkeit:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(928, 405);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 13);
            this.label26.TabIndex = 45;
            this.label26.Text = "Dünger:";
            // 
            // tbdTemperatur
            // 
            this.tbdTemperatur.Location = new System.Drawing.Point(1008, 324);
            this.tbdTemperatur.Name = "tbdTemperatur";
            this.tbdTemperatur.ReadOnly = true;
            this.tbdTemperatur.Size = new System.Drawing.Size(73, 20);
            this.tbdTemperatur.TabIndex = 46;
            // 
            // tbdLicht
            // 
            this.tbdLicht.Location = new System.Drawing.Point(1008, 350);
            this.tbdLicht.Name = "tbdLicht";
            this.tbdLicht.ReadOnly = true;
            this.tbdLicht.Size = new System.Drawing.Size(73, 20);
            this.tbdLicht.TabIndex = 47;
            // 
            // tbdFeuchtigkeit
            // 
            this.tbdFeuchtigkeit.Location = new System.Drawing.Point(1008, 376);
            this.tbdFeuchtigkeit.Name = "tbdFeuchtigkeit";
            this.tbdFeuchtigkeit.ReadOnly = true;
            this.tbdFeuchtigkeit.Size = new System.Drawing.Size(73, 20);
            this.tbdFeuchtigkeit.TabIndex = 48;
            // 
            // tbdDünger
            // 
            this.tbdDünger.Location = new System.Drawing.Point(1008, 402);
            this.tbdDünger.Name = "tbdDünger";
            this.tbdDünger.ReadOnly = true;
            this.tbdDünger.Size = new System.Drawing.Size(73, 20);
            this.tbdDünger.TabIndex = 49;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(1087, 327);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 13);
            this.label27.TabIndex = 50;
            this.label27.Text = "°C";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(1087, 353);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 13);
            this.label28.TabIndex = 51;
            this.label28.Text = "lm";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(1087, 379);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 13);
            this.label29.TabIndex = 52;
            this.label29.Text = "%";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1087, 405);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(27, 13);
            this.label30.TabIndex = 53;
            this.label30.Text = "ppm";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(675, 625);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 54;
            this.label31.Text = "Tage:";
            // 
            // tbaTage
            // 
            this.tbaTage.Location = new System.Drawing.Point(784, 622);
            this.tbaTage.Name = "tbaTage";
            this.tbaTage.ReadOnly = true;
            this.tbaTage.Size = new System.Drawing.Size(73, 20);
            this.tbaTage.TabIndex = 55;
            // 
            // Optimierung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 710);
            this.Controls.Add(this.tbaTage);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.tbdDünger);
            this.Controls.Add(this.tbdFeuchtigkeit);
            this.Controls.Add(this.tbdLicht);
            this.Controls.Add(this.tbdTemperatur);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.Durchschnittswerte);
            this.Controls.Add(this.tbaGewinnprotag);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbaGewinn);
            this.Controls.Add(this.tbaUmsatz);
            this.Controls.Add(this.tbaErtrag);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbaGesammtkosten);
            this.Controls.Add(this.tbaFixkosten);
            this.Controls.Add(this.tbaVariablekosten);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbaErntekosten);
            this.Controls.Add(this.tbaAnpflanzungskosten);
            this.Controls.Add(this.tbaDüngerkosten);
            this.Controls.Add(this.tbaWasserkosten);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbDüngerpreis);
            this.Controls.Add(this.tbWasserpreis);
            this.Controls.Add(this.tbFeldgröße);
            this.Controls.Add(this.tbFixkosten);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPflanzenauswahl);
            this.Controls.Add(this.pbKostenrechnung);
            this.Controls.Add(this.dgvPflanzen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Optimierung";
            this.Text = "Optimierung";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPflanzen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKostenrechnung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPflanzen;
        private System.Windows.Forms.PictureBox pbKostenrechnung;
        private System.Windows.Forms.ComboBox cbPflanzenauswahl;
        private System.Windows.Forms.DataGridViewTextBoxColumn PflanzenArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperatur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lichtenergie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feuchtigkeit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dünger;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anpflanzungspreis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erntekosten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ertrag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbFixkosten;
        private System.Windows.Forms.TextBox tbFeldgröße;
        private System.Windows.Forms.TextBox tbWasserpreis;
        private System.Windows.Forms.TextBox tbDüngerpreis;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbaWasserkosten;
        private System.Windows.Forms.TextBox tbaDüngerkosten;
        private System.Windows.Forms.TextBox tbaAnpflanzungskosten;
        private System.Windows.Forms.TextBox tbaErntekosten;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbaVariablekosten;
        private System.Windows.Forms.TextBox tbaFixkosten;
        private System.Windows.Forms.TextBox tbaGesammtkosten;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbaErtrag;
        private System.Windows.Forms.TextBox tbaUmsatz;
        private System.Windows.Forms.TextBox tbaGewinn;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbaGewinnprotag;
        private System.Windows.Forms.Label Durchschnittswerte;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbdTemperatur;
        private System.Windows.Forms.TextBox tbdLicht;
        private System.Windows.Forms.TextBox tbdFeuchtigkeit;
        private System.Windows.Forms.TextBox tbdDünger;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tbaTage;

    }
}
namespace RS232 {
    partial class MainForm {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.tcMesswerte = new System.Windows.Forms.TabControl();
            this.tpTemperatur = new System.Windows.Forms.TabPage();
            this.tpFeuchtigkeit = new System.Windows.Forms.TabPage();
            this.tpLichtstrom = new System.Windows.Forms.TabPage();
            this.tpDünger = new System.Windows.Forms.TabPage();
            this.btnWässern = new System.Windows.Forms.Button();
            this.btnEinstellungen = new System.Windows.Forms.Button();
            this.btnOptimierung = new System.Windows.Forms.Button();
            this.ccTemperatur = new RS232.Controls.ChartControl();
            this.ccFeuchtigkeit = new RS232.Controls.ChartControl();
            this.ccLichtstrom = new RS232.Controls.ChartControl();
            this.ccDünger = new RS232.Controls.ChartControl();
            this.tcMesswerte.SuspendLayout();
            this.tpTemperatur.SuspendLayout();
            this.tpFeuchtigkeit.SuspendLayout();
            this.tpLichtstrom.SuspendLayout();
            this.tpDünger.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMesswerte
            // 
            this.tcMesswerte.Controls.Add(this.tpTemperatur);
            this.tcMesswerte.Controls.Add(this.tpFeuchtigkeit);
            this.tcMesswerte.Controls.Add(this.tpLichtstrom);
            this.tcMesswerte.Controls.Add(this.tpDünger);
            this.tcMesswerte.Location = new System.Drawing.Point(-2, -2);
            this.tcMesswerte.Name = "tcMesswerte";
            this.tcMesswerte.SelectedIndex = 0;
            this.tcMesswerte.Size = new System.Drawing.Size(626, 399);
            this.tcMesswerte.TabIndex = 0;
            // 
            // tpTemperatur
            // 
            this.tpTemperatur.Controls.Add(this.ccTemperatur);
            this.tpTemperatur.Location = new System.Drawing.Point(4, 22);
            this.tpTemperatur.Name = "tpTemperatur";
            this.tpTemperatur.Size = new System.Drawing.Size(618, 373);
            this.tpTemperatur.TabIndex = 0;
            this.tpTemperatur.Text = "Temperatur";
            this.tpTemperatur.UseVisualStyleBackColor = true;
            // 
            // tpFeuchtigkeit
            // 
            this.tpFeuchtigkeit.Controls.Add(this.ccFeuchtigkeit);
            this.tpFeuchtigkeit.Location = new System.Drawing.Point(4, 22);
            this.tpFeuchtigkeit.Name = "tpFeuchtigkeit";
            this.tpFeuchtigkeit.Size = new System.Drawing.Size(618, 373);
            this.tpFeuchtigkeit.TabIndex = 1;
            this.tpFeuchtigkeit.Text = "Feuchtigkeit";
            this.tpFeuchtigkeit.UseVisualStyleBackColor = true;
            // 
            // tpLichtstrom
            // 
            this.tpLichtstrom.Controls.Add(this.ccLichtstrom);
            this.tpLichtstrom.Location = new System.Drawing.Point(4, 22);
            this.tpLichtstrom.Name = "tpLichtstrom";
            this.tpLichtstrom.Size = new System.Drawing.Size(618, 373);
            this.tpLichtstrom.TabIndex = 2;
            this.tpLichtstrom.Text = "Lichtstrom";
            this.tpLichtstrom.UseVisualStyleBackColor = true;
            // 
            // tpDünger
            // 
            this.tpDünger.Controls.Add(this.ccDünger);
            this.tpDünger.Location = new System.Drawing.Point(4, 22);
            this.tpDünger.Name = "tpDünger";
            this.tpDünger.Size = new System.Drawing.Size(618, 373);
            this.tpDünger.TabIndex = 3;
            this.tpDünger.Text = "Dünger";
            this.tpDünger.UseVisualStyleBackColor = true;
            // 
            // btnWässern
            // 
            this.btnWässern.Location = new System.Drawing.Point(533, 425);
            this.btnWässern.Name = "btnWässern";
            this.btnWässern.Size = new System.Drawing.Size(75, 23);
            this.btnWässern.TabIndex = 1;
            this.btnWässern.Text = "Wässern";
            this.btnWässern.UseVisualStyleBackColor = true;
            this.btnWässern.Click += new System.EventHandler(this.btnWässern_Click);
            // 
            // btnEinstellungen
            // 
            this.btnEinstellungen.Location = new System.Drawing.Point(12, 425);
            this.btnEinstellungen.Name = "btnEinstellungen";
            this.btnEinstellungen.Size = new System.Drawing.Size(83, 23);
            this.btnEinstellungen.TabIndex = 2;
            this.btnEinstellungen.Text = "Einstellungen";
            this.btnEinstellungen.UseVisualStyleBackColor = true;
            this.btnEinstellungen.Click += new System.EventHandler(this.btnEinstellungen_Click);
            // 
            // btnOptimierung
            // 
            this.btnOptimierung.Location = new System.Drawing.Point(142, 425);
            this.btnOptimierung.Name = "btnOptimierung";
            this.btnOptimierung.Size = new System.Drawing.Size(75, 23);
            this.btnOptimierung.TabIndex = 3;
            this.btnOptimierung.Text = "Optimierung";
            this.btnOptimierung.UseVisualStyleBackColor = true;
            this.btnOptimierung.Click += new System.EventHandler(this.btnOptimierung_Click);
            // 
            // ccTemperatur
            // 
            this.ccTemperatur.BackColor = System.Drawing.Color.White;
            this.ccTemperatur.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ccTemperatur.Location = new System.Drawing.Point(0, 0);
            this.ccTemperatur.MinDistX = 25F;
            this.ccTemperatur.MinDistY = 20F;
            this.ccTemperatur.Name = "ccTemperatur";
            this.ccTemperatur.ScaleX = 20F;
            this.ccTemperatur.ScaleY = 6F;
            this.ccTemperatur.Size = new System.Drawing.Size(634, 376);
            this.ccTemperatur.SuffixX = "s";
            this.ccTemperatur.SuffixY = "C";
            this.ccTemperatur.TabIndex = 0;
            // 
            // ccFeuchtigkeit
            // 
            this.ccFeuchtigkeit.BackColor = System.Drawing.Color.White;
            this.ccFeuchtigkeit.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ccFeuchtigkeit.Location = new System.Drawing.Point(3, 0);
            this.ccFeuchtigkeit.MinDistX = 25F;
            this.ccFeuchtigkeit.MinDistY = 20F;
            this.ccFeuchtigkeit.Name = "ccFeuchtigkeit";
            this.ccFeuchtigkeit.ScaleX = 20F;
            this.ccFeuchtigkeit.ScaleY = 2F;
            this.ccFeuchtigkeit.Size = new System.Drawing.Size(628, 369);
            this.ccFeuchtigkeit.SuffixX = "s";
            this.ccFeuchtigkeit.SuffixY = "%";
            this.ccFeuchtigkeit.TabIndex = 0;
            // 
            // ccLichtstrom
            // 
            this.ccLichtstrom.BackColor = System.Drawing.Color.White;
            this.ccLichtstrom.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ccLichtstrom.Location = new System.Drawing.Point(-8, 0);
            this.ccLichtstrom.MinDistX = 25F;
            this.ccLichtstrom.MinDistY = 20F;
            this.ccLichtstrom.Name = "ccLichtstrom";
            this.ccLichtstrom.ScaleX = 20F;
            this.ccLichtstrom.ScaleY = 2F;
            this.ccLichtstrom.Size = new System.Drawing.Size(642, 372);
            this.ccLichtstrom.SuffixX = "s";
            this.ccLichtstrom.SuffixY = "lm";
            this.ccLichtstrom.TabIndex = 0;
            // 
            // ccDünger
            // 
            this.ccDünger.BackColor = System.Drawing.Color.White;
            this.ccDünger.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ccDünger.Location = new System.Drawing.Point(0, 0);
            this.ccDünger.MinDistX = 25F;
            this.ccDünger.MinDistY = 20F;
            this.ccDünger.Name = "ccDünger";
            this.ccDünger.ScaleX = 20F;
            this.ccDünger.ScaleY = 2F;
            this.ccDünger.Size = new System.Drawing.Size(638, 372);
            this.ccDünger.SuffixX = "s";
            this.ccDünger.SuffixY = "%";
            this.ccDünger.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 464);
            this.Controls.Add(this.btnOptimierung);
            this.Controls.Add(this.btnEinstellungen);
            this.Controls.Add(this.btnWässern);
            this.Controls.Add(this.tcMesswerte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Chip für den Acker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tcMesswerte.ResumeLayout(false);
            this.tpTemperatur.ResumeLayout(false);
            this.tpFeuchtigkeit.ResumeLayout(false);
            this.tpLichtstrom.ResumeLayout(false);
            this.tpDünger.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpTemperatur;
        private System.Windows.Forms.TabPage tpFeuchtigkeit;
        private System.Windows.Forms.TabPage tpLichtstrom;
        private System.Windows.Forms.TabPage tpDünger;
        private System.Windows.Forms.Button btnWässern;
        public RS232.Controls.ChartControl ccTemperatur;
        public System.Windows.Forms.TabControl tcMesswerte;
        public RS232.Controls.ChartControl ccFeuchtigkeit;
        public RS232.Controls.ChartControl ccLichtstrom;
        public RS232.Controls.ChartControl ccDünger;
        private System.Windows.Forms.Button btnEinstellungen;
        private System.Windows.Forms.Button btnOptimierung;


    }
}


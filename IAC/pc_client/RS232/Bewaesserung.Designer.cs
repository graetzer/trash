namespace IAC {
    partial class Bewässerung {
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
            this.cbDünger = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEntfernung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWinkel = new System.Windows.Forms.TextBox();
            this.btnLos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDauer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDünger
            // 
            this.cbDünger.AutoSize = true;
            this.cbDünger.Location = new System.Drawing.Point(12, 108);
            this.cbDünger.Name = "cbDünger";
            this.cbDünger.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDünger.Size = new System.Drawing.Size(80, 17);
            this.cbDünger.TabIndex = 4;
            this.cbDünger.Text = "mit Dünger ";
            this.cbDünger.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Entfernung:";
            // 
            // tbEntfernung
            // 
            this.tbEntfernung.Location = new System.Drawing.Point(83, 54);
            this.tbEntfernung.Name = "tbEntfernung";
            this.tbEntfernung.Size = new System.Drawing.Size(100, 20);
            this.tbEntfernung.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Winkel:";
            // 
            // tbWinkel
            // 
            this.tbWinkel.Location = new System.Drawing.Point(83, 83);
            this.tbWinkel.Name = "tbWinkel";
            this.tbWinkel.Size = new System.Drawing.Size(100, 20);
            this.tbWinkel.TabIndex = 3;
            // 
            // btnLos
            // 
            this.btnLos.Location = new System.Drawing.Point(224, 118);
            this.btnLos.Name = "btnLos";
            this.btnLos.Size = new System.Drawing.Size(71, 23);
            this.btnLos.TabIndex = 5;
            this.btnLos.Text = "Los";
            this.btnLos.UseVisualStyleBackColor = true;
            this.btnLos.Click += new System.EventHandler(this.btnLos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dauer:";
            // 
            // tbDauer
            // 
            this.tbDauer.Location = new System.Drawing.Point(83, 28);
            this.tbDauer.Name = "tbDauer";
            this.tbDauer.Size = new System.Drawing.Size(100, 20);
            this.tbDauer.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "m";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "°";
            // 
            // Bewässerung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 169);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDauer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLos);
            this.Controls.Add(this.tbWinkel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEntfernung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDünger);
            this.Name = "Bewässerung";
            this.Text = "Bewässerung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbDünger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEntfernung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWinkel;
        private System.Windows.Forms.Button btnLos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDauer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
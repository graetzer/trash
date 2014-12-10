namespace IAC.Controls {
    partial class ChartControl {
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geaendert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.valueToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.scaleBar = new System.Windows.Forms.HScrollBar();
            this.scaleBarLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scaleBar
            // 
            this.scaleBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.scaleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.scaleBar.Location = new System.Drawing.Point(0, 0);
            this.scaleBar.Maximum = 500;
            this.scaleBar.Minimum = 1;
            this.scaleBar.Name = "scaleBar";
            this.scaleBar.Size = new System.Drawing.Size(400, 17);
            this.scaleBar.TabIndex = 0;
            this.scaleBar.Value = 100;
            this.scaleBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scaleBar_Scroll);
            // 
            // scaleBarLabel
            // 
            this.scaleBarLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scaleBarLabel.AutoSize = true;
            this.scaleBarLabel.BackColor = System.Drawing.Color.Transparent;
            this.scaleBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleBarLabel.Location = new System.Drawing.Point(173, 17);
            this.scaleBarLabel.Name = "scaleBarLabel";
            this.scaleBarLabel.Size = new System.Drawing.Size(28, 12);
            this.scaleBarLabel.TabIndex = 1;
            this.scaleBarLabel.Text = "100%";
            // 
            // ChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleBarLabel);
            this.Controls.Add(this.scaleBar);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Name = "ChartControl";
            this.Size = new System.Drawing.Size(400, 231);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Chart_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseDown);
            this.Resize += new System.EventHandler(this.ChartControl_Resize);
            this.MouseHover += new System.EventHandler(this.ChartControl_MouseHover);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip valueToolTip;
        private System.Windows.Forms.HScrollBar scaleBar;
        private System.Windows.Forms.Label scaleBarLabel;



    }
}

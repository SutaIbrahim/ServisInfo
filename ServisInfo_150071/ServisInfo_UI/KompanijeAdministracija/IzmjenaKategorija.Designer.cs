namespace ServisInfo_UI.KompanijeAdministracija
{
    partial class IzmjenaKategorija
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SacuvajBtn = new System.Windows.Forms.Button();
            this.OdustaniBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.KategorijeList = new System.Windows.Forms.CheckedListBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // SacuvajBtn
            // 
            this.SacuvajBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.SacuvajBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SacuvajBtn.Location = new System.Drawing.Point(286, 406);
            this.SacuvajBtn.Name = "SacuvajBtn";
            this.SacuvajBtn.Size = new System.Drawing.Size(113, 42);
            this.SacuvajBtn.TabIndex = 0;
            this.SacuvajBtn.Text = "Sacuvaj promjene";
            this.SacuvajBtn.UseVisualStyleBackColor = false;
            this.SacuvajBtn.Click += new System.EventHandler(this.SacuvajBtn_Click);
            // 
            // OdustaniBtn
            // 
            this.OdustaniBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.OdustaniBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OdustaniBtn.Location = new System.Drawing.Point(27, 406);
            this.OdustaniBtn.Name = "OdustaniBtn";
            this.OdustaniBtn.Size = new System.Drawing.Size(114, 42);
            this.OdustaniBtn.TabIndex = 1;
            this.OdustaniBtn.Text = "Odustani";
            this.OdustaniBtn.UseVisualStyleBackColor = false;
            this.OdustaniBtn.Click += new System.EventHandler(this.OdustaniBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Odaberite kategorije koje nudi vasa kompanija";
            // 
            // KategorijeList
            // 
            this.KategorijeList.FormattingEnabled = true;
            this.KategorijeList.Location = new System.Drawing.Point(26, 125);
            this.KategorijeList.Name = "KategorijeList";
            this.KategorijeList.Size = new System.Drawing.Size(373, 259);
            this.KategorijeList.TabIndex = 3;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(380, 125);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(19, 259);
            this.vScrollBar1.TabIndex = 4;
            // 
            // IzmjenaKategorija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(424, 480);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.KategorijeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OdustaniBtn);
            this.Controls.Add(this.SacuvajBtn);
            this.MaximumSize = new System.Drawing.Size(440, 519);
            this.MinimumSize = new System.Drawing.Size(440, 519);
            this.Name = "IzmjenaKategorija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IzmjenaKategorija";
            this.Load += new System.EventHandler(this.IzmjenaKategorija_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SacuvajBtn;
        private System.Windows.Forms.Button OdustaniBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox KategorijeList;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}
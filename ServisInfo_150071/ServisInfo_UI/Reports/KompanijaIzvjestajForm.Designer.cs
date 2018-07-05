namespace ServisInfo_UI.Reports
{
    partial class KompanijaIzvjestajForm
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
            this.OdDtm = new System.Windows.Forms.DateTimePicker();
            this.DoDtm = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KreirajBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OdDtm
            // 
            this.OdDtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OdDtm.Location = new System.Drawing.Point(82, 71);
            this.OdDtm.Name = "OdDtm";
            this.OdDtm.Size = new System.Drawing.Size(222, 22);
            this.OdDtm.TabIndex = 0;
            // 
            // DoDtm
            // 
            this.DoDtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DoDtm.Location = new System.Drawing.Point(82, 118);
            this.DoDtm.Name = "DoDtm";
            this.DoDtm.Size = new System.Drawing.Size(222, 22);
            this.DoDtm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(42, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Od:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(42, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Do:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(70, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kreiraj izvjestaj u rasponu";
            // 
            // KreirajBtn
            // 
            this.KreirajBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KreirajBtn.Location = new System.Drawing.Point(179, 165);
            this.KreirajBtn.Name = "KreirajBtn";
            this.KreirajBtn.Size = new System.Drawing.Size(125, 33);
            this.KreirajBtn.TabIndex = 5;
            this.KreirajBtn.Text = "Kreiraj izvjestaj";
            this.KreirajBtn.UseVisualStyleBackColor = true;
            this.KreirajBtn.Click += new System.EventHandler(this.KreirajBtn_Click);
            // 
            // KompanijaIzvjestajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 217);
            this.Controls.Add(this.KreirajBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoDtm);
            this.Controls.Add(this.OdDtm);
            this.Name = "KompanijaIzvjestajForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KompanijaIzvjestajForm";
            this.Load += new System.EventHandler(this.KompanijaIzvjestajForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker OdDtm;
        private System.Windows.Forms.DateTimePicker DoDtm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button KreirajBtn;
    }
}
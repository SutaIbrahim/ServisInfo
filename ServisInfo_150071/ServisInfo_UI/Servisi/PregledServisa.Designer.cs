namespace ServisInfo_UI.Servisi
{
    partial class PregledServisa
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.DetaljiBtn = new System.Windows.Forms.Button();
            this.ServisiGrid = new System.Windows.Forms.DataGridView();
            this.PrikaziBtn = new System.Windows.Forms.Button();
            this.DoDtm = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OdDtm = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ZavrseniChck = new System.Windows.Forms.CheckBox();
            this.UtokuChck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ServisiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DetaljiBtn
            // 
            this.DetaljiBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.DetaljiBtn.ForeColor = System.Drawing.Color.White;
            this.DetaljiBtn.Location = new System.Drawing.Point(840, 67);
            this.DetaljiBtn.Name = "DetaljiBtn";
            this.DetaljiBtn.Size = new System.Drawing.Size(139, 31);
            this.DetaljiBtn.TabIndex = 15;
            this.DetaljiBtn.Text = "Prikaz detalja o servisu";
            this.DetaljiBtn.UseVisualStyleBackColor = false;
            this.DetaljiBtn.Click += new System.EventHandler(this.DetaljiBtn_Click);
            // 
            // ServisiGrid
            // 
            this.ServisiGrid.AllowUserToAddRows = false;
            this.ServisiGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServisiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServisiGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ServisiGrid.Location = new System.Drawing.Point(0, 132);
            this.ServisiGrid.Name = "ServisiGrid";
            this.ServisiGrid.ReadOnly = true;
            this.ServisiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServisiGrid.Size = new System.Drawing.Size(991, 357);
            this.ServisiGrid.TabIndex = 14;
            // 
            // PrikaziBtn
            // 
            this.PrikaziBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PrikaziBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrikaziBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.PrikaziBtn.Location = new System.Drawing.Point(436, 68);
            this.PrikaziBtn.Name = "PrikaziBtn";
            this.PrikaziBtn.Size = new System.Drawing.Size(140, 33);
            this.PrikaziBtn.TabIndex = 13;
            this.PrikaziBtn.Text = "Prikaži";
            this.PrikaziBtn.UseVisualStyleBackColor = false;
            this.PrikaziBtn.Click += new System.EventHandler(this.PrikaziBtn_Click);
            // 
            // DoDtm
            // 
            this.DoDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DoDtm.Location = new System.Drawing.Point(203, 76);
            this.DoDtm.Name = "DoDtm";
            this.DoDtm.Size = new System.Drawing.Size(85, 20);
            this.DoDtm.TabIndex = 12;
            this.DoDtm.Value = new System.DateTime(2018, 5, 18, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(166, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "DO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "OD:";
            // 
            // OdDtm
            // 
            this.OdDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.OdDtm.Location = new System.Drawing.Point(59, 76);
            this.OdDtm.Name = "OdDtm";
            this.OdDtm.Size = new System.Drawing.Size(85, 20);
            this.OdDtm.TabIndex = 9;
            this.OdDtm.Value = new System.DateTime(2018, 2, 28, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Izabrani raspon za prikaz:";
            // 
            // ZavrseniChck
            // 
            this.ZavrseniChck.AutoSize = true;
            this.ZavrseniChck.Location = new System.Drawing.Point(363, 79);
            this.ZavrseniChck.Name = "ZavrseniChck";
            this.ZavrseniChck.Size = new System.Drawing.Size(67, 17);
            this.ZavrseniChck.TabIndex = 17;
            this.ZavrseniChck.Text = "Zavrseni";
            this.ZavrseniChck.UseVisualStyleBackColor = true;
            this.ZavrseniChck.CheckedChanged += new System.EventHandler(this.ZavrseniChck_CheckedChanged);
            // 
            // UtokuChck
            // 
            this.UtokuChck.AutoSize = true;
            this.UtokuChck.Location = new System.Drawing.Point(299, 79);
            this.UtokuChck.Name = "UtokuChck";
            this.UtokuChck.Size = new System.Drawing.Size(58, 17);
            this.UtokuChck.TabIndex = 16;
            this.UtokuChck.Text = "U toku";
            this.UtokuChck.UseVisualStyleBackColor = true;
            this.UtokuChck.CheckedChanged += new System.EventHandler(this.UtokuChck_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(814, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "*potrebno je oznaciti zeljeni servis";
            // 
            // PregledServisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(991, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ZavrseniChck);
            this.Controls.Add(this.UtokuChck);
            this.Controls.Add(this.DetaljiBtn);
            this.Controls.Add(this.ServisiGrid);
            this.Controls.Add(this.PrikaziBtn);
            this.Controls.Add(this.DoDtm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OdDtm);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1007, 528);
            this.MinimumSize = new System.Drawing.Size(1007, 528);
            this.Name = "PregledServisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pregled servisa";
            this.Load += new System.EventHandler(this.PregledServisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ServisiGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button DetaljiBtn;
        private System.Windows.Forms.DataGridView ServisiGrid;
        private System.Windows.Forms.Button PrikaziBtn;
        private System.Windows.Forms.DateTimePicker DoDtm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker OdDtm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ZavrseniChck;
        private System.Windows.Forms.CheckBox UtokuChck;
        private System.Windows.Forms.Label label4;
    }
}
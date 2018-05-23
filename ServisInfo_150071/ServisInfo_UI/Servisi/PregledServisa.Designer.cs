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
            ((System.ComponentModel.ISupportInitialize)(this.ServisiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DetaljiBtn
            // 
            this.DetaljiBtn.Location = new System.Drawing.Point(776, 199);
            this.DetaljiBtn.Name = "DetaljiBtn";
            this.DetaljiBtn.Size = new System.Drawing.Size(127, 31);
            this.DetaljiBtn.TabIndex = 15;
            this.DetaljiBtn.Text = "Prikaz detalja o servisu";
            this.DetaljiBtn.UseVisualStyleBackColor = true;
            this.DetaljiBtn.Click += new System.EventHandler(this.DetaljiBtn_Click);
            // 
            // ServisiGrid
            // 
            this.ServisiGrid.AllowUserToAddRows = false;
            this.ServisiGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServisiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServisiGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ServisiGrid.Location = new System.Drawing.Point(0, 258);
            this.ServisiGrid.Name = "ServisiGrid";
            this.ServisiGrid.ReadOnly = true;
            this.ServisiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServisiGrid.Size = new System.Drawing.Size(1202, 336);
            this.ServisiGrid.TabIndex = 14;
            // 
            // PrikaziBtn
            // 
            this.PrikaziBtn.Location = new System.Drawing.Point(253, 170);
            this.PrikaziBtn.Name = "PrikaziBtn";
            this.PrikaziBtn.Size = new System.Drawing.Size(140, 60);
            this.PrikaziBtn.TabIndex = 13;
            this.PrikaziBtn.Text = "Prikaži";
            this.PrikaziBtn.UseVisualStyleBackColor = true;
            this.PrikaziBtn.Click += new System.EventHandler(this.PrikaziBtn_Click);
            // 
            // DoDtm
            // 
            this.DoDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DoDtm.Location = new System.Drawing.Point(66, 210);
            this.DoDtm.Name = "DoDtm";
            this.DoDtm.Size = new System.Drawing.Size(85, 20);
            this.DoDtm.TabIndex = 12;
            this.DoDtm.Value = new System.DateTime(2018, 5, 18, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(20, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "DO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(20, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "OD:";
            // 
            // OdDtm
            // 
            this.OdDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.OdDtm.Location = new System.Drawing.Point(66, 170);
            this.OdDtm.Name = "OdDtm";
            this.OdDtm.Size = new System.Drawing.Size(85, 20);
            this.OdDtm.TabIndex = 9;
            this.OdDtm.Value = new System.DateTime(2018, 2, 28, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Izabrani raspon za prikaz:";
            // 
            // ZavrseniChck
            // 
            this.ZavrseniChck.AutoSize = true;
            this.ZavrseniChck.Location = new System.Drawing.Point(169, 210);
            this.ZavrseniChck.Name = "ZavrseniChck";
            this.ZavrseniChck.Size = new System.Drawing.Size(67, 17);
            this.ZavrseniChck.TabIndex = 17;
            this.ZavrseniChck.Text = "Zavrseni";
            this.ZavrseniChck.UseVisualStyleBackColor = true;
            // 
            // UtokuChck
            // 
            this.UtokuChck.AutoSize = true;
            this.UtokuChck.Location = new System.Drawing.Point(169, 173);
            this.UtokuChck.Name = "UtokuChck";
            this.UtokuChck.Size = new System.Drawing.Size(58, 17);
            this.UtokuChck.TabIndex = 16;
            this.UtokuChck.Text = "U toku";
            this.UtokuChck.UseVisualStyleBackColor = true;
            // 
            // PregledServisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 594);
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
            this.Name = "PregledServisa";
            this.Text = "PregledServisa";
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
    }
}
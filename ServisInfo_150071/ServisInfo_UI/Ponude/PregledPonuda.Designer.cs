namespace ServisInfo_UI.Ponude
{
    partial class PregledPonuda
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
            this.PonudeGrid = new System.Windows.Forms.DataGridView();
            this.PrikaziBtn = new System.Windows.Forms.Button();
            this.DoDtm = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OdDtm = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DetaljiBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PonudeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PonudeGrid
            // 
            this.PonudeGrid.AllowUserToAddRows = false;
            this.PonudeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PonudeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PonudeGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PonudeGrid.Location = new System.Drawing.Point(0, 153);
            this.PonudeGrid.Name = "PonudeGrid";
            this.PonudeGrid.ReadOnly = true;
            this.PonudeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PonudeGrid.Size = new System.Drawing.Size(991, 336);
            this.PonudeGrid.TabIndex = 14;
            this.PonudeGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PonudeGrid_CellContentDoubleClick);
            // 
            // PrikaziBtn
            // 
            this.PrikaziBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PrikaziBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrikaziBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PrikaziBtn.Location = new System.Drawing.Point(186, 67);
            this.PrikaziBtn.Name = "PrikaziBtn";
            this.PrikaziBtn.Size = new System.Drawing.Size(140, 60);
            this.PrikaziBtn.TabIndex = 13;
            this.PrikaziBtn.Text = "Prikaži";
            this.PrikaziBtn.UseVisualStyleBackColor = false;
            this.PrikaziBtn.Click += new System.EventHandler(this.PrikaziBtn_Click);
            // 
            // DoDtm
            // 
            this.DoDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DoDtm.Location = new System.Drawing.Point(60, 107);
            this.DoDtm.Name = "DoDtm";
            this.DoDtm.Size = new System.Drawing.Size(85, 20);
            this.DoDtm.TabIndex = 12;
            this.DoDtm.Value = new System.DateTime(2018, 5, 18, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "DO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "OD:";
            // 
            // OdDtm
            // 
            this.OdDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.OdDtm.Location = new System.Drawing.Point(60, 67);
            this.OdDtm.Name = "OdDtm";
            this.OdDtm.Size = new System.Drawing.Size(85, 20);
            this.OdDtm.TabIndex = 9;
            this.OdDtm.Value = new System.DateTime(2018, 2, 28, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Izabrani raspon za prikaz:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(799, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "*potrebno je oznaciti zeljeniu ponudu";
            // 
            // DetaljiBtn
            // 
            this.DetaljiBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.DetaljiBtn.ForeColor = System.Drawing.Color.White;
            this.DetaljiBtn.Location = new System.Drawing.Point(852, 80);
            this.DetaljiBtn.Name = "DetaljiBtn";
            this.DetaljiBtn.Size = new System.Drawing.Size(127, 31);
            this.DetaljiBtn.TabIndex = 15;
            this.DetaljiBtn.Text = "Prikaz detalja o ponudi";
            this.DetaljiBtn.UseVisualStyleBackColor = false;
            this.DetaljiBtn.Click += new System.EventHandler(this.DetaljiBtn_Click);
            // 
            // PregledPonuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(991, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DetaljiBtn);
            this.Controls.Add(this.PonudeGrid);
            this.Controls.Add(this.PrikaziBtn);
            this.Controls.Add(this.DoDtm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OdDtm);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1007, 528);
            this.MinimumSize = new System.Drawing.Size(1007, 528);
            this.Name = "PregledPonuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PregledPonuda";
            this.Load += new System.EventHandler(this.PregledPonuda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PonudeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView PonudeGrid;
        private System.Windows.Forms.Button PrikaziBtn;
        private System.Windows.Forms.DateTimePicker DoDtm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker OdDtm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DetaljiBtn;
    }
}
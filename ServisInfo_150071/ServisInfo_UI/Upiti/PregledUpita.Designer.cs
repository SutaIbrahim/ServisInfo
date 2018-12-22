namespace ServisInfo_UI.Upiti
{
    partial class PregledUpita
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
            this.label1 = new System.Windows.Forms.Label();
            this.OdDtm = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DoDtm = new System.Windows.Forms.DateTimePicker();
            this.PrikaziBtn = new System.Windows.Forms.Button();
            this.UpitiGrid = new System.Windows.Forms.DataGridView();
            this.DetaljiBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UpitiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izabrani raspon za prikaz:";
            // 
            // OdDtm
            // 
            this.OdDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.OdDtm.Location = new System.Drawing.Point(62, 73);
            this.OdDtm.Name = "OdDtm";
            this.OdDtm.Size = new System.Drawing.Size(85, 20);
            this.OdDtm.TabIndex = 1;
            this.OdDtm.Value = new System.DateTime(2018, 2, 28, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "OD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(16, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "DO:";
            // 
            // DoDtm
            // 
            this.DoDtm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DoDtm.Location = new System.Drawing.Point(62, 113);
            this.DoDtm.Name = "DoDtm";
            this.DoDtm.Size = new System.Drawing.Size(85, 20);
            this.DoDtm.TabIndex = 4;
            this.DoDtm.Value = new System.DateTime(2018, 5, 18, 0, 0, 0, 0);
            // 
            // PrikaziBtn
            // 
            this.PrikaziBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PrikaziBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrikaziBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrikaziBtn.Location = new System.Drawing.Point(169, 73);
            this.PrikaziBtn.Name = "PrikaziBtn";
            this.PrikaziBtn.Size = new System.Drawing.Size(140, 60);
            this.PrikaziBtn.TabIndex = 5;
            this.PrikaziBtn.Text = "Prikaži";
            this.PrikaziBtn.UseVisualStyleBackColor = false;
            this.PrikaziBtn.Click += new System.EventHandler(this.PrikaziBtn_Click);
            // 
            // UpitiGrid
            // 
            this.UpitiGrid.AllowUserToAddRows = false;
            this.UpitiGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UpitiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UpitiGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UpitiGrid.Location = new System.Drawing.Point(0, 153);
            this.UpitiGrid.Name = "UpitiGrid";
            this.UpitiGrid.ReadOnly = true;
            this.UpitiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UpitiGrid.Size = new System.Drawing.Size(991, 336);
            this.UpitiGrid.TabIndex = 6;
            // 
            // DetaljiBtn
            // 
            this.DetaljiBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.DetaljiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DetaljiBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DetaljiBtn.Location = new System.Drawing.Point(852, 88);
            this.DetaljiBtn.Name = "DetaljiBtn";
            this.DetaljiBtn.Size = new System.Drawing.Size(127, 31);
            this.DetaljiBtn.TabIndex = 7;
            this.DetaljiBtn.Text = "Prikaz detalja o upitu";
            this.DetaljiBtn.UseVisualStyleBackColor = false;
            this.DetaljiBtn.Click += new System.EventHandler(this.DetaljiBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(824, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "*potrebno je oznaciti zeljeni upit";
            // 
            // PregledUpita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(991, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DetaljiBtn);
            this.Controls.Add(this.UpitiGrid);
            this.Controls.Add(this.PrikaziBtn);
            this.Controls.Add(this.DoDtm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OdDtm);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1007, 528);
            this.MinimumSize = new System.Drawing.Size(1007, 528);
            this.Name = "PregledUpita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PregledUpita";
            this.Load += new System.EventHandler(this.PregledUpita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpitiGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker OdDtm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DoDtm;
        private System.Windows.Forms.Button PrikaziBtn;
        private System.Windows.Forms.DataGridView UpitiGrid;
        private System.Windows.Forms.Button DetaljiBtn;
        private System.Windows.Forms.Label label4;
    }
}
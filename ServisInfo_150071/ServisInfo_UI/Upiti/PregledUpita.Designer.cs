﻿namespace ServisInfo_UI.Upiti
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.PrikaziBtn.Location = new System.Drawing.Point(188, 73);
            this.PrikaziBtn.Name = "PrikaziBtn";
            this.PrikaziBtn.Size = new System.Drawing.Size(140, 60);
            this.PrikaziBtn.TabIndex = 5;
            this.PrikaziBtn.Text = "Prikaži";
            this.PrikaziBtn.UseVisualStyleBackColor = true;
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
            // PregledUpita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 489);
            this.Controls.Add(this.UpitiGrid);
            this.Controls.Add(this.PrikaziBtn);
            this.Controls.Add(this.DoDtm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OdDtm);
            this.Controls.Add(this.label1);
            this.Name = "PregledUpita";
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
    }
}
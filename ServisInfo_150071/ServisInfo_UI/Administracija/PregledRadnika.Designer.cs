﻿namespace ServisInfo_UI.Administracija
{
    partial class PregledRadnika
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.obrisiBtn = new System.Windows.Forms.Button();
            this.KompanijeGrid = new System.Windows.Forms.DataGridView();
            this.traziButton = new System.Windows.Forms.Button();
            this.NazivBtn = new System.Windows.Forms.Label();
            this.NazivInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.KompanijeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Dodaj radnika";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Izmijeni";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // obrisiBtn
            // 
            this.obrisiBtn.BackColor = System.Drawing.Color.Salmon;
            this.obrisiBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.obrisiBtn.Location = new System.Drawing.Point(298, 62);
            this.obrisiBtn.Name = "obrisiBtn";
            this.obrisiBtn.Size = new System.Drawing.Size(135, 23);
            this.obrisiBtn.TabIndex = 23;
            this.obrisiBtn.Text = "Obriši";
            this.obrisiBtn.UseVisualStyleBackColor = false;
            this.obrisiBtn.Click += new System.EventHandler(this.obrisiBtn_Click);
            // 
            // KompanijeGrid
            // 
            this.KompanijeGrid.AllowUserToAddRows = false;
            this.KompanijeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KompanijeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KompanijeGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KompanijeGrid.Location = new System.Drawing.Point(0, 91);
            this.KompanijeGrid.MultiSelect = false;
            this.KompanijeGrid.Name = "KompanijeGrid";
            this.KompanijeGrid.ReadOnly = true;
            this.KompanijeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.KompanijeGrid.Size = new System.Drawing.Size(466, 157);
            this.KompanijeGrid.TabIndex = 22;
            // 
            // traziButton
            // 
            this.traziButton.Location = new System.Drawing.Point(358, 20);
            this.traziButton.Name = "traziButton";
            this.traziButton.Size = new System.Drawing.Size(75, 23);
            this.traziButton.TabIndex = 21;
            this.traziButton.Text = "Traži";
            this.traziButton.UseVisualStyleBackColor = true;
            this.traziButton.Click += new System.EventHandler(this.traziButton_Click);
            // 
            // NazivBtn
            // 
            this.NazivBtn.AutoSize = true;
            this.NazivBtn.Location = new System.Drawing.Point(12, 25);
            this.NazivBtn.Name = "NazivBtn";
            this.NazivBtn.Size = new System.Drawing.Size(75, 13);
            this.NazivBtn.TabIndex = 19;
            this.NazivBtn.Text = "Naziv radnika:";
            // 
            // NazivInput
            // 
            this.NazivInput.Location = new System.Drawing.Point(125, 22);
            this.NazivInput.Name = "NazivInput";
            this.NazivInput.Size = new System.Drawing.Size(210, 20);
            this.NazivInput.TabIndex = 18;
            // 
            // PregledRadnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 248);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.obrisiBtn);
            this.Controls.Add(this.KompanijeGrid);
            this.Controls.Add(this.traziButton);
            this.Controls.Add(this.NazivBtn);
            this.Controls.Add(this.NazivInput);
            this.Name = "PregledRadnika";
            this.Text = "Pregled radnika";
            this.Load += new System.EventHandler(this.PregledRadnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KompanijeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button obrisiBtn;
        private System.Windows.Forms.DataGridView KompanijeGrid;
        private System.Windows.Forms.Button traziButton;
        private System.Windows.Forms.Label NazivBtn;
        private System.Windows.Forms.TextBox NazivInput;
    }
}
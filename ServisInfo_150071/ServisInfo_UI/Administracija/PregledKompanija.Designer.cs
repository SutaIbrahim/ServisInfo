namespace ServisInfo_UI.Administracija
{
    partial class PregledKompanija
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
            this.traziButton = new System.Windows.Forms.Button();
            this.novaKompanijaBtn = new System.Windows.Forms.Button();
            this.NazivBtn = new System.Windows.Forms.Label();
            this.NazivInput = new System.Windows.Forms.TextBox();
            this.KompanijeGrid = new System.Windows.Forms.DataGridView();
            this.obrisiBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KompanijeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // traziButton
            // 
            this.traziButton.Location = new System.Drawing.Point(448, 28);
            this.traziButton.Name = "traziButton";
            this.traziButton.Size = new System.Drawing.Size(75, 23);
            this.traziButton.TabIndex = 11;
            this.traziButton.Text = "Traži";
            this.traziButton.UseVisualStyleBackColor = true;
            this.traziButton.Click += new System.EventHandler(this.traziButton_Click);
            // 
            // novaKompanijaBtn
            // 
            this.novaKompanijaBtn.Location = new System.Drawing.Point(649, 16);
            this.novaKompanijaBtn.Name = "novaKompanijaBtn";
            this.novaKompanijaBtn.Size = new System.Drawing.Size(132, 23);
            this.novaKompanijaBtn.TabIndex = 10;
            this.novaKompanijaBtn.Text = "Dodaj novu kompaniju";
            this.novaKompanijaBtn.UseVisualStyleBackColor = true;
            this.novaKompanijaBtn.Click += new System.EventHandler(this.novaKompanijaBtn_Click);
            // 
            // NazivBtn
            // 
            this.NazivBtn.AutoSize = true;
            this.NazivBtn.Location = new System.Drawing.Point(11, 37);
            this.NazivBtn.Name = "NazivBtn";
            this.NazivBtn.Size = new System.Drawing.Size(88, 13);
            this.NazivBtn.TabIndex = 9;
            this.NazivBtn.Text = "Naziv kompanije:";
            // 
            // NazivInput
            // 
            this.NazivInput.Location = new System.Drawing.Point(125, 30);
            this.NazivInput.Name = "NazivInput";
            this.NazivInput.Size = new System.Drawing.Size(317, 20);
            this.NazivInput.TabIndex = 8;
            // 
            // KompanijeGrid
            // 
            this.KompanijeGrid.AllowUserToAddRows = false;
            this.KompanijeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KompanijeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KompanijeGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KompanijeGrid.Location = new System.Drawing.Point(0, 85);
            this.KompanijeGrid.MultiSelect = false;
            this.KompanijeGrid.Name = "KompanijeGrid";
            this.KompanijeGrid.ReadOnly = true;
            this.KompanijeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.KompanijeGrid.Size = new System.Drawing.Size(931, 382);
            this.KompanijeGrid.TabIndex = 13;
            // 
            // obrisiBtn
            // 
            this.obrisiBtn.BackColor = System.Drawing.Color.Salmon;
            this.obrisiBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.obrisiBtn.Location = new System.Drawing.Point(787, 45);
            this.obrisiBtn.Name = "obrisiBtn";
            this.obrisiBtn.Size = new System.Drawing.Size(132, 23);
            this.obrisiBtn.TabIndex = 14;
            this.obrisiBtn.Text = "Obriši";
            this.obrisiBtn.UseVisualStyleBackColor = false;
            this.obrisiBtn.Click += new System.EventHandler(this.obrisiBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Izmijeni";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(787, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Pregled radnika";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // PregledKompanija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 467);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.obrisiBtn);
            this.Controls.Add(this.KompanijeGrid);
            this.Controls.Add(this.traziButton);
            this.Controls.Add(this.novaKompanijaBtn);
            this.Controls.Add(this.NazivBtn);
            this.Controls.Add(this.NazivInput);
            this.MaximumSize = new System.Drawing.Size(947, 506);
            this.MinimumSize = new System.Drawing.Size(947, 506);
            this.Name = "PregledKompanija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pregled kompanija";
            this.Load += new System.EventHandler(this.PregledKompanija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KompanijeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button traziButton;
        private System.Windows.Forms.Button novaKompanijaBtn;
        private System.Windows.Forms.Label NazivBtn;
        private System.Windows.Forms.TextBox NazivInput;
        private System.Windows.Forms.DataGridView KompanijeGrid;
        private System.Windows.Forms.Button obrisiBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
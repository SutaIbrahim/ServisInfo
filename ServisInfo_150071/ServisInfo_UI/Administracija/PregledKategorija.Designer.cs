namespace ServisInfo_UI.Administracija
{
    partial class PregledKategorija
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
            this.KategorijeGrid = new System.Windows.Forms.DataGridView();
            this.NovaBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KategorijeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // KategorijeGrid
            // 
            this.KategorijeGrid.AllowUserToAddRows = false;
            this.KategorijeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KategorijeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KategorijeGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KategorijeGrid.Location = new System.Drawing.Point(0, 118);
            this.KategorijeGrid.MultiSelect = false;
            this.KategorijeGrid.Name = "KategorijeGrid";
            this.KategorijeGrid.ReadOnly = true;
            this.KategorijeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.KategorijeGrid.Size = new System.Drawing.Size(492, 382);
            this.KategorijeGrid.TabIndex = 18;
            // 
            // NovaBtn
            // 
            this.NovaBtn.Location = new System.Drawing.Point(282, 36);
            this.NovaBtn.Name = "NovaBtn";
            this.NovaBtn.Size = new System.Drawing.Size(198, 37);
            this.NovaBtn.TabIndex = 16;
            this.NovaBtn.Text = "Dodaj novu kategoriju";
            this.NovaBtn.UseVisualStyleBackColor = true;
            this.NovaBtn.Click += new System.EventHandler(this.NovaBtn_Click);
            // 
            // PregledKategorija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 500);
            this.Controls.Add(this.KategorijeGrid);
            this.Controls.Add(this.NovaBtn);
            this.MaximumSize = new System.Drawing.Size(508, 539);
            this.MinimumSize = new System.Drawing.Size(508, 539);
            this.Name = "PregledKategorija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PregledKategorija";
            this.Load += new System.EventHandler(this.PregledKategorija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KategorijeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView KategorijeGrid;
        private System.Windows.Forms.Button NovaBtn;
    }
}
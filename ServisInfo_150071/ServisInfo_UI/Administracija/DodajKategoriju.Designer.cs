namespace ServisInfo_UI.Administracija
{
    partial class DodajKategoriju
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
            this.label1 = new System.Windows.Forms.Label();
            this.NazivTxt = new System.Windows.Forms.TextBox();
            this.DodajBtn = new System.Windows.Forms.Button();
            this.OdustaniBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(27, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv kategorije:";
            // 
            // NazivTxt
            // 
            this.NazivTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NazivTxt.Location = new System.Drawing.Point(171, 42);
            this.NazivTxt.Name = "NazivTxt";
            this.NazivTxt.Size = new System.Drawing.Size(187, 22);
            this.NazivTxt.TabIndex = 1;
            // 
            // DodajBtn
            // 
            this.DodajBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DodajBtn.Location = new System.Drawing.Point(282, 84);
            this.DodajBtn.Name = "DodajBtn";
            this.DodajBtn.Size = new System.Drawing.Size(75, 23);
            this.DodajBtn.TabIndex = 2;
            this.DodajBtn.Text = "Dodaj";
            this.DodajBtn.UseVisualStyleBackColor = true;
            this.DodajBtn.Click += new System.EventHandler(this.DodajBtn_Click);
            // 
            // OdustaniBtn
            // 
            this.OdustaniBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OdustaniBtn.Location = new System.Drawing.Point(189, 84);
            this.OdustaniBtn.Name = "OdustaniBtn";
            this.OdustaniBtn.Size = new System.Drawing.Size(75, 23);
            this.OdustaniBtn.TabIndex = 3;
            this.OdustaniBtn.Text = "Odustani";
            this.OdustaniBtn.UseVisualStyleBackColor = true;
            this.OdustaniBtn.Click += new System.EventHandler(this.OdustaniBtn_Click);
            // 
            // DodajKategoriju
            // 
            this.AcceptButton = this.DodajBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.OdustaniBtn;
            this.ClientSize = new System.Drawing.Size(377, 134);
            this.ControlBox = false;
            this.Controls.Add(this.OdustaniBtn);
            this.Controls.Add(this.DodajBtn);
            this.Controls.Add(this.NazivTxt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(393, 173);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(393, 173);
            this.Name = "DodajKategoriju";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodavanje nove kategorije";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NazivTxt;
        private System.Windows.Forms.Button DodajBtn;
        private System.Windows.Forms.Button OdustaniBtn;
    }
}
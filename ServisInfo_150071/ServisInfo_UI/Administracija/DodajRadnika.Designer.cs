namespace ServisInfo_UI.Administracija
{
    partial class DodajRadnika
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
            this.NazadBtn = new System.Windows.Forms.Button();
            this.DodajBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LozinkaTxt = new System.Windows.Forms.TextBox();
            this.KorisickoImeTxt = new System.Windows.Forms.TextBox();
            this.KorisicnkImeLbl = new System.Windows.Forms.Label();
            this.LozinkaLbl = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NazadBtn
            // 
            this.NazadBtn.Location = new System.Drawing.Point(13, 208);
            this.NazadBtn.Name = "NazadBtn";
            this.NazadBtn.Size = new System.Drawing.Size(126, 38);
            this.NazadBtn.TabIndex = 30;
            this.NazadBtn.Text = "Nazad";
            this.NazadBtn.UseVisualStyleBackColor = true;
            this.NazadBtn.Click += new System.EventHandler(this.NazadBtn_Click);
            // 
            // DodajBtn
            // 
            this.DodajBtn.Location = new System.Drawing.Point(220, 208);
            this.DodajBtn.Name = "DodajBtn";
            this.DodajBtn.Size = new System.Drawing.Size(126, 38);
            this.DodajBtn.TabIndex = 19;
            this.DodajBtn.Text = "Dodaj";
            this.DodajBtn.UseVisualStyleBackColor = true;
            this.DodajBtn.Click += new System.EventHandler(this.DodajBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LozinkaTxt);
            this.groupBox2.Controls.Add(this.KorisickoImeTxt);
            this.groupBox2.Controls.Add(this.KorisicnkImeLbl);
            this.groupBox2.Controls.Add(this.LozinkaLbl);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(16, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 160);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Korisnicki podaci";
            // 
            // LozinkaTxt
            // 
            this.LozinkaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LozinkaTxt.Location = new System.Drawing.Point(149, 93);
            this.LozinkaTxt.Name = "LozinkaTxt";
            this.LozinkaTxt.PasswordChar = '*';
            this.LozinkaTxt.Size = new System.Drawing.Size(157, 20);
            this.LozinkaTxt.TabIndex = 15;
            // 
            // KorisickoImeTxt
            // 
            this.KorisickoImeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KorisickoImeTxt.Location = new System.Drawing.Point(149, 49);
            this.KorisickoImeTxt.Name = "KorisickoImeTxt";
            this.KorisickoImeTxt.Size = new System.Drawing.Size(157, 20);
            this.KorisickoImeTxt.TabIndex = 14;
            // 
            // KorisicnkImeLbl
            // 
            this.KorisicnkImeLbl.AutoSize = true;
            this.KorisicnkImeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KorisicnkImeLbl.Location = new System.Drawing.Point(27, 50);
            this.KorisicnkImeLbl.Name = "KorisicnkImeLbl";
            this.KorisicnkImeLbl.Size = new System.Drawing.Size(98, 16);
            this.KorisicnkImeLbl.TabIndex = 2;
            this.KorisicnkImeLbl.Text = "Korisnicko ime:";
            // 
            // LozinkaLbl
            // 
            this.LozinkaLbl.AutoSize = true;
            this.LozinkaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LozinkaLbl.Location = new System.Drawing.Point(64, 96);
            this.LozinkaLbl.Name = "LozinkaLbl";
            this.LozinkaLbl.Size = new System.Drawing.Size(57, 16);
            this.LozinkaLbl.TabIndex = 4;
            this.LozinkaLbl.Text = "Lozinka:";
            // 
            // DodajRadnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 265);
            this.Controls.Add(this.NazadBtn);
            this.Controls.Add(this.DodajBtn);
            this.Controls.Add(this.groupBox2);
            this.Name = "DodajRadnika";
            this.Text = "Dodaj radnika";
            this.Load += new System.EventHandler(this.DodajRadnika_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NazadBtn;
        private System.Windows.Forms.Button DodajBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LozinkaTxt;
        private System.Windows.Forms.TextBox KorisickoImeTxt;
        private System.Windows.Forms.Label KorisicnkImeLbl;
        private System.Windows.Forms.Label LozinkaLbl;
    }
}
namespace ServisInfo_UI.Administracija
{
    partial class DodajKompaniju
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
            this.components = new System.ComponentModel.Container();
            this.DodajBtn = new System.Windows.Forms.Button();
            this.NazivLbl = new System.Windows.Forms.Label();
            this.KorisicnkImeLbl = new System.Windows.Forms.Label();
            this.EmailLbl = new System.Windows.Forms.Label();
            this.LozinkaLbl = new System.Windows.Forms.Label();
            this.TelefonLbl = new System.Windows.Forms.Label();
            this.AdresaLbl = new System.Windows.Forms.Label();
            this.GradLbl = new System.Windows.Forms.Label();
            this.NazivTxt = new System.Windows.Forms.TextBox();
            this.AdresaTxt = new System.Windows.Forms.TextBox();
            this.EmailTxt = new System.Windows.Forms.TextBox();
            this.KorisickoImeTxt = new System.Windows.Forms.TextBox();
            this.LozinkaTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TelefonTxt = new System.Windows.Forms.MaskedTextBox();
            this.GradoviCmb = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NazadBtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DodajBtn
            // 
            this.DodajBtn.Location = new System.Drawing.Point(551, 359);
            this.DodajBtn.Name = "DodajBtn";
            this.DodajBtn.Size = new System.Drawing.Size(126, 38);
            this.DodajBtn.TabIndex = 0;
            this.DodajBtn.Text = "Dodaj";
            this.DodajBtn.UseVisualStyleBackColor = true;
            this.DodajBtn.Click += new System.EventHandler(this.DodajBtn_Click);
            // 
            // NazivLbl
            // 
            this.NazivLbl.AutoSize = true;
            this.NazivLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NazivLbl.Location = new System.Drawing.Point(35, 69);
            this.NazivLbl.Name = "NazivLbl";
            this.NazivLbl.Size = new System.Drawing.Size(111, 16);
            this.NazivLbl.TabIndex = 1;
            this.NazivLbl.Text = "Naziv kompanije:";
            // 
            // KorisicnkImeLbl
            // 
            this.KorisicnkImeLbl.AutoSize = true;
            this.KorisicnkImeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KorisicnkImeLbl.Location = new System.Drawing.Point(25, 50);
            this.KorisicnkImeLbl.Name = "KorisicnkImeLbl";
            this.KorisicnkImeLbl.Size = new System.Drawing.Size(98, 16);
            this.KorisicnkImeLbl.TabIndex = 2;
            this.KorisicnkImeLbl.Text = "Korisnicko ime:";
            // 
            // EmailLbl
            // 
            this.EmailLbl.AutoSize = true;
            this.EmailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLbl.Location = new System.Drawing.Point(423, 115);
            this.EmailLbl.Name = "EmailLbl";
            this.EmailLbl.Size = new System.Drawing.Size(45, 16);
            this.EmailLbl.TabIndex = 3;
            this.EmailLbl.Text = "Email:";
            this.EmailLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // LozinkaLbl
            // 
            this.LozinkaLbl.AutoSize = true;
            this.LozinkaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LozinkaLbl.Location = new System.Drawing.Point(388, 53);
            this.LozinkaLbl.Name = "LozinkaLbl";
            this.LozinkaLbl.Size = new System.Drawing.Size(57, 16);
            this.LozinkaLbl.TabIndex = 4;
            this.LozinkaLbl.Text = "Lozinka:";
            // 
            // TelefonLbl
            // 
            this.TelefonLbl.AutoSize = true;
            this.TelefonLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelefonLbl.Location = new System.Drawing.Point(411, 69);
            this.TelefonLbl.Name = "TelefonLbl";
            this.TelefonLbl.Size = new System.Drawing.Size(57, 16);
            this.TelefonLbl.TabIndex = 5;
            this.TelefonLbl.Text = "Telefon:";
            // 
            // AdresaLbl
            // 
            this.AdresaLbl.AutoSize = true;
            this.AdresaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdresaLbl.Location = new System.Drawing.Point(91, 115);
            this.AdresaLbl.Name = "AdresaLbl";
            this.AdresaLbl.Size = new System.Drawing.Size(55, 16);
            this.AdresaLbl.TabIndex = 6;
            this.AdresaLbl.Text = "Adresa:";
            // 
            // GradLbl
            // 
            this.GradLbl.AutoSize = true;
            this.GradLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradLbl.Location = new System.Drawing.Point(108, 165);
            this.GradLbl.Name = "GradLbl";
            this.GradLbl.Size = new System.Drawing.Size(41, 16);
            this.GradLbl.TabIndex = 7;
            this.GradLbl.Text = "Grad:";
            // 
            // NazivTxt
            // 
            this.NazivTxt.Location = new System.Drawing.Point(172, 69);
            this.NazivTxt.Name = "NazivTxt";
            this.NazivTxt.Size = new System.Drawing.Size(157, 20);
            this.NazivTxt.TabIndex = 8;
            this.NazivTxt.Validating += new System.ComponentModel.CancelEventHandler(this.NazivTxt_Validating);
            // 
            // AdresaTxt
            // 
            this.AdresaTxt.Location = new System.Drawing.Point(172, 115);
            this.AdresaTxt.Name = "AdresaTxt";
            this.AdresaTxt.Size = new System.Drawing.Size(157, 20);
            this.AdresaTxt.TabIndex = 10;
            this.AdresaTxt.Validating += new System.ComponentModel.CancelEventHandler(this.AdresaTxt_Validating);
            // 
            // EmailTxt
            // 
            this.EmailTxt.Location = new System.Drawing.Point(496, 115);
            this.EmailTxt.Name = "EmailTxt";
            this.EmailTxt.Size = new System.Drawing.Size(157, 20);
            this.EmailTxt.TabIndex = 12;
            this.EmailTxt.Validating += new System.ComponentModel.CancelEventHandler(this.EmailTxt_Validating);
            // 
            // KorisickoImeTxt
            // 
            this.KorisickoImeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KorisickoImeTxt.Location = new System.Drawing.Point(149, 49);
            this.KorisickoImeTxt.Name = "KorisickoImeTxt";
            this.KorisickoImeTxt.Size = new System.Drawing.Size(157, 20);
            this.KorisickoImeTxt.TabIndex = 14;
            this.KorisickoImeTxt.Validating += new System.ComponentModel.CancelEventHandler(this.KorisickoImeTxt_Validating);
            // 
            // LozinkaTxt
            // 
            this.LozinkaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LozinkaTxt.Location = new System.Drawing.Point(473, 50);
            this.LozinkaTxt.Name = "LozinkaTxt";
            this.LozinkaTxt.PasswordChar = '*';
            this.LozinkaTxt.Size = new System.Drawing.Size(157, 20);
            this.LozinkaTxt.TabIndex = 15;
            this.LozinkaTxt.Validating += new System.ComponentModel.CancelEventHandler(this.LozinkaTxt_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TelefonTxt);
            this.groupBox1.Controls.Add(this.GradoviCmb);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(23, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 190);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci";
            // 
            // TelefonTxt
            // 
            this.TelefonTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TelefonTxt.Location = new System.Drawing.Point(473, 34);
            this.TelefonTxt.Mask = "(999) 000-000";
            this.TelefonTxt.Name = "TelefonTxt";
            this.TelefonTxt.Size = new System.Drawing.Size(157, 20);
            this.TelefonTxt.TabIndex = 54;
            this.TelefonTxt.Validating += new System.ComponentModel.CancelEventHandler(this.TelefonTxt_Validating);
            // 
            // GradoviCmb
            // 
            this.GradoviCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GradoviCmb.FormattingEnabled = true;
            this.GradoviCmb.ItemHeight = 13;
            this.GradoviCmb.Location = new System.Drawing.Point(149, 127);
            this.GradoviCmb.Name = "GradoviCmb";
            this.GradoviCmb.Size = new System.Drawing.Size(157, 21);
            this.GradoviCmb.TabIndex = 18;
            this.GradoviCmb.Validating += new System.ComponentModel.CancelEventHandler(this.GradoviCmb_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LozinkaTxt);
            this.groupBox2.Controls.Add(this.KorisickoImeTxt);
            this.groupBox2.Controls.Add(this.KorisicnkImeLbl);
            this.groupBox2.Controls.Add(this.LozinkaLbl);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(23, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 101);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Korisnicki podaci";
            // 
            // NazadBtn
            // 
            this.NazadBtn.Location = new System.Drawing.Point(23, 359);
            this.NazadBtn.Name = "NazadBtn";
            this.NazadBtn.Size = new System.Drawing.Size(126, 38);
            this.NazadBtn.TabIndex = 18;
            this.NazadBtn.Text = "Nazad";
            this.NazadBtn.UseVisualStyleBackColor = true;
            this.NazadBtn.Click += new System.EventHandler(this.NazadBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DodajKompaniju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 429);
            this.Controls.Add(this.NazadBtn);
            this.Controls.Add(this.EmailTxt);
            this.Controls.Add(this.AdresaTxt);
            this.Controls.Add(this.NazivTxt);
            this.Controls.Add(this.GradLbl);
            this.Controls.Add(this.AdresaLbl);
            this.Controls.Add(this.TelefonLbl);
            this.Controls.Add(this.EmailLbl);
            this.Controls.Add(this.NazivLbl);
            this.Controls.Add(this.DodajBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(715, 468);
            this.MinimumSize = new System.Drawing.Size(715, 468);
            this.Name = "DodajKompaniju";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DodajKompaniju";
            this.Load += new System.EventHandler(this.DodajKompaniju_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DodajBtn;
        private System.Windows.Forms.Label NazivLbl;
        private System.Windows.Forms.Label KorisicnkImeLbl;
        private System.Windows.Forms.Label EmailLbl;
        private System.Windows.Forms.Label LozinkaLbl;
        private System.Windows.Forms.Label TelefonLbl;
        private System.Windows.Forms.Label AdresaLbl;
        private System.Windows.Forms.Label GradLbl;
        private System.Windows.Forms.TextBox NazivTxt;
        private System.Windows.Forms.TextBox AdresaTxt;
        private System.Windows.Forms.TextBox EmailTxt;
        private System.Windows.Forms.TextBox KorisickoImeTxt;
        private System.Windows.Forms.TextBox LozinkaTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox GradoviCmb;
        private System.Windows.Forms.Button NazadBtn;
        private System.Windows.Forms.MaskedTextBox TelefonTxt;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
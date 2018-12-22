namespace ServisInfo_UI
{
    partial class LoginForm
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
            this.odustaniButton = new System.Windows.Forms.Button();
            this.potvrdiButton = new System.Windows.Forms.Button();
            this.lozinkaInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.korisnickoImeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // odustaniButton
            // 
            this.odustaniButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.odustaniButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.odustaniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.odustaniButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.odustaniButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.odustaniButton.Location = new System.Drawing.Point(130, 219);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(81, 30);
            this.odustaniButton.TabIndex = 17;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.odustaniButton.UseVisualStyleBackColor = false;
            this.odustaniButton.Click += new System.EventHandler(this.odustaniButton_Click);
            // 
            // potvrdiButton
            // 
            this.potvrdiButton.BackColor = System.Drawing.Color.SteelBlue;
            this.potvrdiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.potvrdiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrdiButton.ForeColor = System.Drawing.SystemColors.Control;
            this.potvrdiButton.Location = new System.Drawing.Point(217, 207);
            this.potvrdiButton.Name = "potvrdiButton";
            this.potvrdiButton.Size = new System.Drawing.Size(99, 41);
            this.potvrdiButton.TabIndex = 16;
            this.potvrdiButton.Text = "Potvrdi";
            this.potvrdiButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.potvrdiButton.UseVisualStyleBackColor = false;
            this.potvrdiButton.Click += new System.EventHandler(this.potvrdiButton_Click);
            // 
            // lozinkaInput
            // 
            this.lozinkaInput.Location = new System.Drawing.Point(109, 181);
            this.lozinkaInput.Name = "lozinkaInput";
            this.lozinkaInput.PasswordChar = '*';
            this.lozinkaInput.Size = new System.Drawing.Size(207, 20);
            this.lozinkaInput.TabIndex = 15;
            this.lozinkaInput.UseWaitCursor = true;
            this.lozinkaInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lozinkaInput_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Lozinka:";
            // 
            // korisnickoImeInput
            // 
            this.korisnickoImeInput.Location = new System.Drawing.Point(109, 155);
            this.korisnickoImeInput.Name = "korisnickoImeInput";
            this.korisnickoImeInput.Size = new System.Drawing.Size(207, 20);
            this.korisnickoImeInput.TabIndex = 13;
            this.korisnickoImeInput.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Korisničko ime:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ServisInfo_UI.Properties.Resources.mobile_maintenance_256;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(59, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 108);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(199, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "ServisInfo";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(346, 261);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.potvrdiButton);
            this.Controls.Add(this.lozinkaInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.korisnickoImeInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(362, 300);
            this.MinimumSize = new System.Drawing.Size(362, 300);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prijava na sistem";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.Button potvrdiButton;
        private System.Windows.Forms.TextBox lozinkaInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox korisnickoImeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}
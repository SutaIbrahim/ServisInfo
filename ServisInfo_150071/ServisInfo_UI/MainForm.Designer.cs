﻿namespace ServisInfo_UI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.upitiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledUpitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ponudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledPonudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledServisaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmjenaKategorijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uredjivanjeProfilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ServisLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UpitiLbl = new System.Windows.Forms.Label();
            this.DatumLbl = new System.Windows.Forms.Label();
            this.UpitiBtn = new System.Windows.Forms.Button();
            this.ServisiBtn = new System.Windows.Forms.Button();
            this.PonudeBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BrojServisaLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OdjavaBtn = new System.Windows.Forms.Button();
            this.KategorijeBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.prosjekLbl = new System.Windows.Forms.Label();
            this.IzvjestajBtn = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.servisiSviLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ukupnoUpitaLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upitiToolStripMenuItem,
            this.ponudeToolStripMenuItem,
            this.servisiToolStripMenuItem,
            this.postavkeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // upitiToolStripMenuItem
            // 
            this.upitiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledUpitaToolStripMenuItem});
            this.upitiToolStripMenuItem.Name = "upitiToolStripMenuItem";
            this.upitiToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.upitiToolStripMenuItem.Text = "Upiti";
            // 
            // pregledUpitaToolStripMenuItem
            // 
            this.pregledUpitaToolStripMenuItem.Name = "pregledUpitaToolStripMenuItem";
            this.pregledUpitaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pregledUpitaToolStripMenuItem.Text = "Pregled upita";
            this.pregledUpitaToolStripMenuItem.Click += new System.EventHandler(this.pregledUpitaToolStripMenuItem_Click);
            // 
            // ponudeToolStripMenuItem
            // 
            this.ponudeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledPonudaToolStripMenuItem});
            this.ponudeToolStripMenuItem.Name = "ponudeToolStripMenuItem";
            this.ponudeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ponudeToolStripMenuItem.Text = "Ponude";
            // 
            // pregledPonudaToolStripMenuItem
            // 
            this.pregledPonudaToolStripMenuItem.Name = "pregledPonudaToolStripMenuItem";
            this.pregledPonudaToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.pregledPonudaToolStripMenuItem.Text = "Pregled ponuda";
            this.pregledPonudaToolStripMenuItem.Click += new System.EventHandler(this.pregledPonudaToolStripMenuItem_Click);
            // 
            // servisiToolStripMenuItem
            // 
            this.servisiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledServisaToolStripMenuItem});
            this.servisiToolStripMenuItem.Name = "servisiToolStripMenuItem";
            this.servisiToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.servisiToolStripMenuItem.Text = "Servisi";
            // 
            // pregledServisaToolStripMenuItem
            // 
            this.pregledServisaToolStripMenuItem.Name = "pregledServisaToolStripMenuItem";
            this.pregledServisaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pregledServisaToolStripMenuItem.Text = "Pregled servisa";
            this.pregledServisaToolStripMenuItem.Click += new System.EventHandler(this.pregledServisaToolStripMenuItem_Click);
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izmjenaKategorijaToolStripMenuItem,
            this.uredjivanjeProfilaToolStripMenuItem});
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            this.postavkeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.postavkeToolStripMenuItem.Text = "Postavke";
            // 
            // izmjenaKategorijaToolStripMenuItem
            // 
            this.izmjenaKategorijaToolStripMenuItem.Name = "izmjenaKategorijaToolStripMenuItem";
            this.izmjenaKategorijaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.izmjenaKategorijaToolStripMenuItem.Text = "Izmjena kategorija";
            this.izmjenaKategorijaToolStripMenuItem.Click += new System.EventHandler(this.izmjenaKategorijaToolStripMenuItem_Click);
            // 
            // uredjivanjeProfilaToolStripMenuItem
            // 
            this.uredjivanjeProfilaToolStripMenuItem.Name = "uredjivanjeProfilaToolStripMenuItem";
            this.uredjivanjeProfilaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.uredjivanjeProfilaToolStripMenuItem.Text = "Uredjivanje profila";
            this.uredjivanjeProfilaToolStripMenuItem.Click += new System.EventHandler(this.uredjivanjeProfilaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(28, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prijavljeni ste kao:";
            // 
            // ServisLbl
            // 
            this.ServisLbl.AutoSize = true;
            this.ServisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ServisLbl.Location = new System.Drawing.Point(212, 584);
            this.ServisLbl.Name = "ServisLbl";
            this.ServisLbl.Size = new System.Drawing.Size(40, 24);
            this.ServisLbl.TabIndex = 3;
            this.ServisLbl.Text = "asd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(182, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dobro došli u ServisInfo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(18, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Novi upiti:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(17, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Servisi u toku:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // UpitiLbl
            // 
            this.UpitiLbl.AutoSize = true;
            this.UpitiLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpitiLbl.Location = new System.Drawing.Point(128, 160);
            this.UpitiLbl.Name = "UpitiLbl";
            this.UpitiLbl.Size = new System.Drawing.Size(40, 24);
            this.UpitiLbl.TabIndex = 8;
            this.UpitiLbl.Text = "asd";
            // 
            // DatumLbl
            // 
            this.DatumLbl.AutoSize = true;
            this.DatumLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DatumLbl.Location = new System.Drawing.Point(116, 121);
            this.DatumLbl.Name = "DatumLbl";
            this.DatumLbl.Size = new System.Drawing.Size(62, 24);
            this.DatumLbl.TabIndex = 9;
            this.DatumLbl.Text = "datum";
            // 
            // UpitiBtn
            // 
            this.UpitiBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.UpitiBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.UpitiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpitiBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UpitiBtn.Location = new System.Drawing.Point(439, 420);
            this.UpitiBtn.Name = "UpitiBtn";
            this.UpitiBtn.Size = new System.Drawing.Size(302, 36);
            this.UpitiBtn.TabIndex = 10;
            this.UpitiBtn.Text = "Upiti";
            this.UpitiBtn.UseVisualStyleBackColor = false;
            this.UpitiBtn.Click += new System.EventHandler(this.UpitiBtn_Click);
            // 
            // ServisiBtn
            // 
            this.ServisiBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.ServisiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ServisiBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServisiBtn.Location = new System.Drawing.Point(439, 507);
            this.ServisiBtn.Name = "ServisiBtn";
            this.ServisiBtn.Size = new System.Drawing.Size(302, 36);
            this.ServisiBtn.TabIndex = 11;
            this.ServisiBtn.Text = "Servisi";
            this.ServisiBtn.UseVisualStyleBackColor = false;
            this.ServisiBtn.Click += new System.EventHandler(this.ServisiBtn_Click);
            // 
            // PonudeBtn
            // 
            this.PonudeBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PonudeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PonudeBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PonudeBtn.Location = new System.Drawing.Point(439, 462);
            this.PonudeBtn.Name = "PonudeBtn";
            this.PonudeBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PonudeBtn.Size = new System.Drawing.Size(302, 38);
            this.PonudeBtn.TabIndex = 12;
            this.PonudeBtn.Text = "Ponude";
            this.PonudeBtn.UseVisualStyleBackColor = false;
            this.PonudeBtn.Click += new System.EventHandler(this.PonudeBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(26, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "Datum:";
            // 
            // BrojServisaLbl
            // 
            this.BrojServisaLbl.AutoSize = true;
            this.BrojServisaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrojServisaLbl.Location = new System.Drawing.Point(165, 202);
            this.BrojServisaLbl.Name = "BrojServisaLbl";
            this.BrojServisaLbl.Size = new System.Drawing.Size(40, 24);
            this.BrojServisaLbl.TabIndex = 14;
            this.BrojServisaLbl.Text = "asd";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(10, 615);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 10);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(601, 631);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Copyright © ServisInfo 2018";
            // 
            // OdjavaBtn
            // 
            this.OdjavaBtn.BackColor = System.Drawing.Color.Tomato;
            this.OdjavaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OdjavaBtn.ForeColor = System.Drawing.Color.Snow;
            this.OdjavaBtn.Location = new System.Drawing.Point(576, 577);
            this.OdjavaBtn.Name = "OdjavaBtn";
            this.OdjavaBtn.Size = new System.Drawing.Size(165, 32);
            this.OdjavaBtn.TabIndex = 38;
            this.OdjavaBtn.Text = "Odjava";
            this.OdjavaBtn.UseVisualStyleBackColor = false;
            this.OdjavaBtn.Click += new System.EventHandler(this.OdjavaBtn_Click);
            // 
            // KategorijeBtn
            // 
            this.KategorijeBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.KategorijeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KategorijeBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KategorijeBtn.Location = new System.Drawing.Point(26, 420);
            this.KategorijeBtn.Name = "KategorijeBtn";
            this.KategorijeBtn.Size = new System.Drawing.Size(301, 35);
            this.KategorijeBtn.TabIndex = 39;
            this.KategorijeBtn.Text = "Izmjena kategorija";
            this.KategorijeBtn.UseVisualStyleBackColor = false;
            this.KategorijeBtn.Click += new System.EventHandler(this.KategorijeBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(17, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 24);
            this.label7.TabIndex = 40;
            this.label7.Text = "Prosječna ocjena:";
            // 
            // prosjekLbl
            // 
            this.prosjekLbl.AutoSize = true;
            this.prosjekLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prosjekLbl.Location = new System.Drawing.Point(201, 41);
            this.prosjekLbl.Name = "prosjekLbl";
            this.prosjekLbl.Size = new System.Drawing.Size(40, 24);
            this.prosjekLbl.TabIndex = 41;
            this.prosjekLbl.Text = "asd";
            // 
            // IzvjestajBtn
            // 
            this.IzvjestajBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.IzvjestajBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IzvjestajBtn.Location = new System.Drawing.Point(26, 505);
            this.IzvjestajBtn.Name = "IzvjestajBtn";
            this.IzvjestajBtn.Size = new System.Drawing.Size(301, 36);
            this.IzvjestajBtn.TabIndex = 42;
            this.IzvjestajBtn.Text = "Izvještaj o prometu";
            this.IzvjestajBtn.UseVisualStyleBackColor = false;
            this.IzvjestajBtn.Click += new System.EventHandler(this.IzvjestajBtn_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BackgroundImage = global::ServisInfo_UI.Properties.Resources.mobile_applications_icon_11;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(398, 132);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 272);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(26, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(301, 35);
            this.button1.TabIndex = 43;
            this.button1.Text = "Uređivanje profila";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.servisiSviLbl);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ukupnoUpitaLbl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.prosjekLbl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BrojServisaLbl);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.UpitiLbl);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(26, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 245);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Osnovne informacije";
            // 
            // servisiSviLbl
            // 
            this.servisiSviLbl.AutoSize = true;
            this.servisiSviLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.servisiSviLbl.Location = new System.Drawing.Point(146, 120);
            this.servisiSviLbl.Name = "servisiSviLbl";
            this.servisiSviLbl.Size = new System.Drawing.Size(40, 24);
            this.servisiSviLbl.TabIndex = 45;
            this.servisiSviLbl.Text = "asd";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(17, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 24);
            this.label9.TabIndex = 44;
            this.label9.Text = "Broj servisa:";
            // 
            // ukupnoUpitaLbl
            // 
            this.ukupnoUpitaLbl.AutoSize = true;
            this.ukupnoUpitaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ukupnoUpitaLbl.Location = new System.Drawing.Point(128, 80);
            this.ukupnoUpitaLbl.Name = "ukupnoUpitaLbl";
            this.ukupnoUpitaLbl.Size = new System.Drawing.Size(40, 24);
            this.ukupnoUpitaLbl.TabIndex = 43;
            this.ukupnoUpitaLbl.Text = "asd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(17, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 24);
            this.label8.TabIndex = 42;
            this.label8.Text = "Broj upita:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(764, 653);
            this.Controls.Add(this.ServisLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IzvjestajBtn);
            this.Controls.Add(this.KategorijeBtn);
            this.Controls.Add(this.OdjavaBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PonudeBtn);
            this.Controls.Add(this.ServisiBtn);
            this.Controls.Add(this.UpitiBtn);
            this.Controls.Add(this.DatumLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(780, 692);
            this.MinimumSize = new System.Drawing.Size(780, 692);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServisInfo@Pocetna";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem upitiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledUpitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ponudeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledPonudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledServisaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ServisLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label UpitiLbl;
        private System.Windows.Forms.Label DatumLbl;
        private System.Windows.Forms.Button UpitiBtn;
        private System.Windows.Forms.Button ServisiBtn;
        private System.Windows.Forms.Button PonudeBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BrojServisaLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem izmjenaKategorijaToolStripMenuItem;
        private System.Windows.Forms.Button OdjavaBtn;
        private System.Windows.Forms.Button KategorijeBtn;
        private System.Windows.Forms.ToolStripMenuItem uredjivanjeProfilaToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label prosjekLbl;
        private System.Windows.Forms.Button IzvjestajBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ukupnoUpitaLbl;
        private System.Windows.Forms.Label servisiSviLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
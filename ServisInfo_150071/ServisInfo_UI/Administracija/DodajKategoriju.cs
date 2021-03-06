﻿using ServisInfo_API.Models;
using ServisInfo_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisInfo_UI.Administracija
{
    public partial class DodajKategoriju : Form
    {
        private WebAPIHelper KategorijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KategorijeRoute);

        public DodajKategoriju()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }


        private void DodajBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Kategorije k = new Kategorije();
                k.Naziv = NazivTxt.Text;

                HttpResponseMessage response = KategorijeService.PostResponse(k);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Uspjesno dodana kategorija", "Dodano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string msg = response.ReasonPhrase;

                    MessageBox.Show("Kategorija vec postoji");
                }
            }
        }

        private void OdustaniBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NazivTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(NazivTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(NazivTxt, "Morate unijeti naziv kategorije");
            }
            else
                errorProvider.SetError(NazivTxt, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ServisInfo_UI.Util;
using ServisInfo_API.Models;
using System.Net.Http;
using System.Resources;
using System.Configuration;

namespace ServisInfo_UI
{
    public partial class LoginForm : Form
    {
        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Prijava()
        {
            HttpResponseMessage response = KompanijeService.GetActionResponse("GetByKorisnickoIme", korisnickoImeInput.Text);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                MessageBox.Show("Korisnicko ime nije pronadjeno", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (response.IsSuccessStatusCode)
            {
                Kompanije k = response.Content.ReadAsAsync<Kompanije>().Result;

                if (UIHelper.GenerateHash(k.LozinkaSalt, lozinkaInput.Text) == k.LozinkaHash)
                {
                    this.DialogResult = DialogResult.OK;
                    Global.notBrojac = 0;
                    Global.prijavljenaKompanija = k;
                    Form frm = new Administracija.DodajKompaniju();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Pogresni korisnicki podaci", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lozinkaInput.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " Message - " + response.ReasonPhrase);
            }

        }


        private void potvrdiButton_Click(object sender, EventArgs e)
        {
            Prijava();
        }

        private void odustaniButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lozinkaInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Prijava();
        }

    }
}

using ServisInfo_API.Models;
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
    public partial class DodajKompaniju : Form
    {

        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);
        private WebAPIHelper GradoviService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradoviRoute);

        public DodajKompaniju()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }
        private void DodajKompaniju_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = GradoviService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                GradoviCmb.DataSource = response.Content.ReadAsAsync<List<Gradovi>>().Result;
                GradoviCmb.DisplayMember = "Naziv";
                GradoviCmb.ValueMember = "GradID";
                GradoviCmb.SelectedIndex = 0;
            }

        }

        private void DodajBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                string ID = GradoviCmb.SelectedValue.ToString();

                Kompanije k = new Kompanije();
                k.Naziv = NazivTxt.Text;
                k.Adresa = AdresaTxt.Text;
                k.Email = EmailTxt.Text;
                k.Telefon = TelefonTxt.Text;
                k.KorisickoIme = KorisickoImeTxt.Text;
                k.GradID = Convert.ToInt32(ID); // gradID


                k.LozinkaSalt = UIHelper.GenerateSalt();
                k.LozinkaHash = UIHelper.GenerateHash(k.LozinkaSalt, LozinkaTxt.Text);

                HttpResponseMessage response = KompanijeService.PostResponse(k);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Uspjesno dodano", "Dodano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string msg = response.ReasonPhrase;

                    MessageBox.Show("Error Code" +
                    response.StatusCode + " : Message - " + msg);
                }
            }
        }

   




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NazadBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NazivTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(NazivTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(NazivTxt, "Naziv je obavezan");
            }
            else
                errorProvider.SetError(NazivTxt, null);
        }

        private void TelefonTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(TelefonTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(TelefonTxt, "Telefon je obavezan");
            }
            else
                errorProvider.SetError(TelefonTxt, null);
        }

        private void AdresaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(AdresaTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(AdresaTxt, "Adresa je obavezna");
            }
            else
                errorProvider.SetError(AdresaTxt, null);
        }

        private void GradoviCmb_Validating(object sender, CancelEventArgs e)
        {
        }

        private void KorisickoImeTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(KorisickoImeTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(KorisickoImeTxt, "Korisnicko ime je obavezno");
            }
            else
                errorProvider.SetError(KorisickoImeTxt, null);
        }

        private void LozinkaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(LozinkaTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(LozinkaTxt, Messages.pass_req);
            }
            else if (LozinkaTxt.TextLength < 6 || !LozinkaTxt.Text.Any(char.IsDigit) || !LozinkaTxt.Text.Any(char.IsLetter))
            {
                e.Cancel = true;
                errorProvider.SetError(LozinkaTxt, Messages.pass_err);
            }
            else
                errorProvider.SetError(LozinkaTxt, null);
        }

        private void EmailTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(EmailTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(EmailTxt, "Email je obavezan");
            }
            else
                errorProvider.SetError(EmailTxt, null);
        }
    }
}

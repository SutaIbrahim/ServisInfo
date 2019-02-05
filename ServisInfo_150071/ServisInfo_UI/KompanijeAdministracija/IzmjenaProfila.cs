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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisInfo_UI.KompanijeAdministracija
{
    public partial class IzmjenaProfila : Form
    {
        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);

        private Kompanije k { get; set; }

        public IzmjenaProfila(int? id=null)
        {

            if (id == null)
            {
                k = Global.prijavljenaKompanija;
            }
            else
            {
                HttpResponseMessage response = KompanijeService.GetResponse(id.GetValueOrDefault().ToString());

                if (response.IsSuccessStatusCode)
                {
                    k = response.Content.ReadAsAsync<Kompanije>().Result;
                }
                else
                {
                    MessageBox.Show("Error Code" +
                    response.StatusCode + " : Message - " + response.ReasonPhrase);
                }
            }
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }
        private void IzmjenaProfila_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            nazivInput.Text = k.Naziv;
            telefonInput.Text = k.Telefon;
            emailInput.Text = k.Email;
            korisnickoImeInput.Text = k.KorisickoIme;
        }

        private void sacuvajButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                k.Naziv = nazivInput.Text;
                k.Telefon = telefonInput.Text;
                k.Email = emailInput.Text;
                k.KorisickoIme = korisnickoImeInput.Text;

                if (lozinkaInput.Text != String.Empty)
                {
                    k.LozinkaSalt = UIHelper.GenerateSalt();
                    k.LozinkaHash = UIHelper.GenerateHash(k.LozinkaSalt, lozinkaInput.Text);
                }
                else
                {
                 
                }

                k.kategorije = null;

                HttpResponseMessage response = KompanijeService.PutResponse(k.KompanijaID, k);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Uspjesno ste izmijenili podatke", Messages.msg_succ, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error Code" +
                    response.StatusCode + " : Message - " + response.ReasonPhrase);
                }
            }
        }

        private void nazivInput_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(nazivInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(nazivInput, "Naziv je obavezan");
            }
            else
                errorProvider.SetError(nazivInput, null);
        }

        private void emailInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(emailInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.email_req);
            }
            else
            {
                try
                {
                    MailAddress mail = new MailAddress(emailInput.Text);
                    errorProvider.SetError(emailInput, null);

                }
                catch (FormatException)
                {
                    e.Cancel = true;
                    errorProvider.SetError(emailInput, Messages.email_err);
                }
            }
        }

        private void telefonInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(telefonInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(telefonInput, "Telefon je obavezan");
            }
            else
                errorProvider.SetError(telefonInput, null);
        }

        private void korisnickoImeInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(korisnickoImeInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(korisnickoImeInput, "Korisnicko ime je obavezno");
            }
            else
                errorProvider.SetError(korisnickoImeInput, null);
        }

        private void lozinkaInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(lozinkaInput.Text.Trim()))
            {
                //ok, prazan string, ostaje stara lozinka
                errorProvider.SetError(lozinkaInput, null);
            }
            else if (lozinkaInput.TextLength < 6 || !lozinkaInput.Text.Any(char.IsDigit) || !lozinkaInput.Text.Any(char.IsLetter))
            {
                e.Cancel = true;
                errorProvider.SetError(lozinkaInput, Messages.pass_err);
            }
            else
                errorProvider.SetError(lozinkaInput, null);
        }
    }
}

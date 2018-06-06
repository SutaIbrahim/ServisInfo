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

namespace ServisInfo_UI.KompanijeAdministracija
{
    public partial class IzmjenaProfila : Form
    {
        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);

        private Kompanije k { get; set; }

        public IzmjenaProfila()
        {
            k = Global.prijavljenaKompanija;
            InitializeComponent();
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
            k.Naziv = nazivInput.Text;
            k.Telefon = telefonInput.Text;
            k.Email = emailInput.Text;
            k.KorisickoIme = korisnickoImeInput.Text;

            if (lozinkaInput.Text != String.Empty)
            {
                k.LozinkaSalt = UIHelper.GenerateSalt();
                k.LozinkaHash = UIHelper.GenerateHash(k.LozinkaSalt, lozinkaInput.Text);
            }

            k.kategorije = null;

            HttpResponseMessage response = KompanijeService.PutResponse(k.KompanijaID, k);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Uspjesno ste izmijenili podatek", Messages.msg_succ, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
    }
    }
}

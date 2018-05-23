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
    }
}

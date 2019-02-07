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
    public partial class DodajRadnika : Form
    {
        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);
        int _id = 0;
        public DodajRadnika(int id)
        {
            _id = id;

            InitializeComponent();
        }

        private void DodajBtn_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int _rnd = rnd.Next(1, 100000);

            Kompanije k = new Kompanije();
            k.Naziv = "";
            k.Adresa = "";
            k.Email = _rnd.ToString();
            k.Telefon = "";
            k.KorisickoIme = KorisickoImeTxt.Text;
            k.GradID = 1; // gradID

            k.KorisickoIme = KorisickoImeTxt.Text;
            k.RefKompanijaID = _id;

            k.LozinkaSalt = UIHelper.GenerateSalt();
            k.LozinkaHash = UIHelper.GenerateHash(k.LozinkaSalt, LozinkaTxt.Text);

            HttpResponseMessage response = KompanijeService.PostResponse(k);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Uspjesno dodan radnik", "Dodano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Korisnicko ime je zauzeto", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //string msg = response.ReasonPhrase;
                //MessageBox.Show("Error Code" +
                //response.StatusCode + " : Message - " + msg);
            }
        }

        private void DodajRadnika_Load(object sender, EventArgs e)
        {
           
        }

        private void NazadBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

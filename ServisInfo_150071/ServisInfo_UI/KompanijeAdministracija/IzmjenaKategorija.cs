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
    public partial class IzmjenaKategorija : Form
    {


        private WebAPIHelper KategorijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KategorijeRoute);
        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);

        private Kompanije k { get; set; }
        private List<Kategorije> sveKategorije { get; set; }
        public IzmjenaKategorija()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void IzmjenaKategorija_Load(object sender, EventArgs e)
        {
            k = Global.prijavljenaKompanija;

            HttpResponseMessage response = KategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                sveKategorije= response.Content.ReadAsAsync<List<Kategorije>>().Result;
                KategorijeList.DataSource = sveKategorije;

                KategorijeList.DisplayMember = "Naziv";
                KategorijeList.ClearSelected();
            }

            // kod za oznacavanje kvadratica za postojece kategorije kompanija
            HttpResponseMessage response2 = KategorijeService.GetActionResponse("GetKategorijeByKompanijaID", k.KompanijaID.ToString());

            if (response.IsSuccessStatusCode)
            {

                List<KompanijeKategorije> kategorije = response2.Content.ReadAsAsync<List<KompanijeKategorije>>().Result;

                kategorije = kategorije.OrderBy(x => x.KategorijaID).ToList();




                // jer id-evi ne idu po redu ( 3,2,6,7...)
                int ukupnoKategorija = sveKategorije.Count();
                int brojac = 0;

                for (int i = 0; i < ukupnoKategorija; i++)
                {
                    foreach (var x in kategorije)
                    {
                        if (sveKategorije[i].KategorijaID == x.KategorijaID)
                        {
                            KategorijeList.SetItemChecked(brojac, true);
                        }
                    }
                    brojac++;
                }


            }
            else
            {
                MessageBox.Show("Error Code" +
                   response.StatusCode + " : Message - " + response.ReasonPhrase);

            }

        }

        private void SacuvajBtn_Click(object sender, EventArgs e)
        {



            k.kategorije = KategorijeList.CheckedItems.Cast<Kategorije>().ToList();

            HttpResponseMessage response = KompanijeService.PutResponse(k.KompanijaID, k);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Uspjesno sacuvano", "Sacuvano!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void OdustaniBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

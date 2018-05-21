using ServisInfo_UI.Util;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ServisInfo_API.Models;
using ServisInfo_UI.Util;
using System.Net.Http;
using System.Resources;
using System.Configuration;


namespace ServisInfo_UI.Upiti
{
    public partial class DetaljiUpita : Form
    {

        private WebAPIHelper UpitiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.UpitiRoute);


        private DetaljiUpita_Result u { get; set; }
        private int UID { get; set; }

        public DetaljiUpita(int upitID)
        {

            UID = upitID;
            InitializeComponent();

            HttpResponseMessage response = UpitiService.GetActionResponse("GetDetalji",upitID.ToString());

            if (response.IsSuccessStatusCode)
            {


                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    u = null;
                else if (response.IsSuccessStatusCode)
                {
                    u = response.Content.ReadAsAsync<DetaljiUpita_Result>().Result;
                    FillForm();
                }
            }
        }



        private void FillForm()
        {
            DatumLbl.Text = u.Datum_upita.ToString();
            MarkaLbl.Text = u.Marka_uredjaja;
            ModelLbl.Text = u.Model_uredjaja;
            OdLbl.Text = u.ZeljeniDatumPrijemaOd.ToString();
            DoLbl.Text = u.ZeljeniDatumPrijemaDo.ToString();
            KlijentLbl.Text = u.NazivKlijenta;
            OpisTxt.Text = u.Opis_kvara;

            //nazik kategorije dodati!!! u.Kategorija ..
            if (u.Odgovoreno == true)
            {
                KreirajPonuduBtn.Hide();
                DaLbl.Text = "DA";
                NeLbl.Hide();
            }
            else
            {
                DaLbl.Hide();
                NeLbl.Text = "NE";
            }

        }

            private void DetaljiUpita_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void KreirajPonuduBtn_Click(object sender, EventArgs e)
        {
            Ponude.KreirajPonudu frm= new Ponude.KreirajPonudu(UID, u.KlijentID,u.KompanijaUpitID, OdLbl.Text,DoLbl.Text,u.Opis_kvara,"Naziv kategorije !!! DODATI");
            frm.ShowDialog();
            this.Close();
        }

        private void NazadBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

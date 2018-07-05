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

namespace ServisInfo_UI.Ponude
{
    public partial class KreirajPonudu : Form
    {
        private WebAPIHelper PonudeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.PonudeRoute);
        private WebAPIHelper KlijentiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KlijentiRoute);
        private WebAPIHelper UpitiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.UpitiRoute);
        private WebAPIHelper KompanijeUpitiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeUpitiRoute);


        private int UpitID { get; set; }
        private int KlijentID { get; set; }
        private int KUID { get; set; }
        private string Od { get; set; }
        private string Do { get; set; }
        private string OpisKvara { get; set; }
        private string Kategorija { get; set; }

        private Klijenti Klijent { get; set; }
        private ServisInfo_API.Models.Upiti Upit { get; set; }



        public KreirajPonudu(int upitID, int klijentID, int kuID, string Od, string Do, string opisKvara,string kategorija)
        {
            UpitID = upitID;
            KlijentID = klijentID;
            KUID = kuID;
            this.Od = Od;
            this.Do = Do;
            OpisKvara = opisKvara;
            Kategorija = kategorija;


            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }


        private void KreirajPonudu_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = KlijentiService.GetResponse(KlijentID.ToString());

            if (response.IsSuccessStatusCode)
            {
                Klijent = response.Content.ReadAsAsync<Klijenti>().Result;

                KlijentLbl.Text = Klijent.Ime + ' ' + Klijent.Prezime;
            }


            //zeljeni datum prijema klijenta
            OdLbl.Text = Od;
            DoLbl.Text = Do;
            PitanjeTxt.Text = OpisKvara;
            kategorijaLbl.Text = Kategorija;

        }

        private void KreirajBtn_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren())
            {

                ServisInfo_API.Models.Ponude p = new ServisInfo_API.Models.Ponude();

                p.Prihvacena = false;
                p.UpitID = UpitID;
                p.KlijentID = KlijentID;
                p.DatumKreiranja = DateTime.Now;
                p.KompanijaID = Global.prijavljenaKompanija.KompanijaID;

                p.Odgovor = OdgovorTxt.Text;
                p.DatumNajranijegMogucegPrijema = DateTime.Parse(NajranijiPrijemDateTime.Value.ToString());
                p.Cijena = CijenaTxt.Text;
                p.TrajanjeDani = Convert.ToDecimal(DaniSelect.Value);
                p.TrajanjeSati = Convert.ToDecimal(SatiSelect.Value);

                HttpResponseMessage response = PonudeService.PostResponse(p);

                if (response.IsSuccessStatusCode)
                {
                    HttpResponseMessage response2 = KompanijeUpitiService.GetResponse(KUID.ToString());
                    if (response2.IsSuccessStatusCode)
                    {
                        KompanijeUpiti ku = response2.Content.ReadAsAsync<KompanijeUpiti>().Result;
                        ku.Odgovoreno = true;

                        HttpResponseMessage response3 = KompanijeUpitiService.PutResponse(ku.KompanijaUpitID, ku);
                    }


                    MessageBox.Show("Uspjesno dodana ponuda", "Dodano", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void OdustaniBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OdgovorTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(OdgovorTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(OdgovorTxt, "Morate unijeti odgovor");
            }
            else
                errorProvider.SetError(OdgovorTxt, null);
        }

        private void CijenaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(CijenaTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(CijenaTxt, "Morate unijeti okvirnu cijenu");
            }
            else
                errorProvider.SetError(CijenaTxt, null);
        }

        private void CijenaTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //samo brojevi
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

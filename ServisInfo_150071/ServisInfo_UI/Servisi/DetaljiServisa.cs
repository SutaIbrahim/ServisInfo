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

namespace ServisInfo_UI.Servisi
{
    public partial class DetaljiServisa : Form
    {
        private WebAPIHelper ServisiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.ServisiRoute);
        private WebAPIHelper OcjeneService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.OcjeneRoute);


        private int ServisID { get; set; }
        private ServisDetalji_Result s { get; set; }

        public DetaljiServisa(int servisID)
        {

            ServisID = servisID;
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            Bind();
        }

        private void Bind()
        {
            HttpResponseMessage response = ServisiService.GetActionResponse("GetDetalji", ServisID.ToString());

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    s = null;
                else if (response.IsSuccessStatusCode)
                {
                    s = response.Content.ReadAsAsync<ServisDetalji_Result>().Result;
                    FillForm();
                }
            }
        }


        private void FillForm()
        {
            PonudaIDLbl.Text = s.PonudaID.ToString();
            DatumPrihvatanjaLbl.Text = s.DatumPrihvatanja.ToShortDateString();
            KlijentLbl.Text = s.Ime_klijenta;
            ServisIDLbl.Text = ServisID.ToString();
            IzvjestajBtn.Hide();
            TrajanjeLbl.Text = s.Kategorija; // kategorija !
            UredjajTxt.Text = s.Uredjaj;
            upitTxt.Text = s.OpisKvara;
            ocjena1Lbl.Text = "";
            ocjena2Lbl.Text = "";
            ocjena3Lbl.Text = "";
            OcjeneLbl.Text = "";
            opisTxt.Text = s.Opis;

            if (s.DatumPocetka == null)
            {
                ZapocniBtn.Show();
                DatumPocetkaLbl.Hide();
                DatumZavrsetkaLbl.Hide();
                //TrajanjeLbl.Hide();
                CijenaTxt.Hide();
               // TrajanjeLbl.Hide();
                NijeZavrsenLbl.Hide();
                ZavrsiBtn.Hide();
                NapomenaLbl.Hide();
                PonudaBtn.Hide();

                label1.Hide();
                label3.Hide();
                label5.Show();
                label4.Hide();
                label7.Hide();
                opisTxt.ReadOnly = true;

            }
            else
            {
                ZapocniBtn.Hide();
                DatumPocetkaLbl.Show();
               // TrajanjeLbl.Show();
                CijenaTxt.Show();
                NijeZavrsenLbl.Show();
                PonudaBtn.Show();

                label1.Show();
                label3.Show();
                label4.Show();
                label7.Show();

                DatumPocetkaLbl.Text = s.DatumPocetka.ToString();

                if (s.DatumZavršetka.ToString() == "")
                {
                    NijeZavrsenLbl.Show();
                    NijeZavrsenLbl.Text = "*Servis je jos uvijek u toku";
                    CijenaTxt.ReadOnly = false;
                    NapomenaLbl.Show();
                    DatumZavrsetkaLbl.Hide();
                    ZavrsiBtn.Show();
                    DatumZavrsetkaLbl.Hide();
                    // TrajanjeLbl.Hide();
                    opisTxt.ReadOnly = false;
                }
                else
                {
                    NijeZavrsenLbl.Hide();
                    DatumZavrsetkaLbl.Text = s.DatumZavršetka.ToString();
                    DatumZavrsetkaLbl.Show();
                    CijenaTxt.ReadOnly = true;
                    CijenaTxt.Text = s.Cijena.ToString();
                    NapomenaLbl.Hide();
                    ZavrsiBtn.Hide();
                   // TrajanjeLbl.Show();
                   // TrajanjeLbl.Text = s.TrajanjeDani.ToString();
                    IzvjestajBtn.Show();
                    //
                    PostaviOcjene();
                    opisTxt.ReadOnly = true;

                }
            }
        }

        private void PostaviOcjene()
        {
            HttpResponseMessage response = OcjeneService.GetActionResponse("GetOcjeneList", ServisID.ToString());


            if (response.IsSuccessStatusCode)
            {
                List<Ocjene> ocjene = response.Content.ReadAsAsync<List<Ocjene>>().Result;

                OcjeneLbl.Text = "Klijent jos uvijek nije ocijenio ovaj servis";

                foreach (var x in ocjene)
                {
                    if (x.VrstaOcjeneID == 1)
                    {
                        ocjena1Lbl.Text = "Brzina usluge: " + x.Ocjena.ToString();
                        OcjeneLbl.Text = "Ocjene od klijenta:";
                    }
                    if (x.VrstaOcjeneID == 2)
                    {
                        ocjena2Lbl.Text = "Kvalitet usluge: " + x.Ocjena.ToString();
                    }
                    if (x.VrstaOcjeneID == 3)
                    {
                        ocjena3Lbl.Text = "Komunikacija: " + x.Ocjena.ToString();
                    }
                }
            }
        }

        private void NazadBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ZapocniBtn_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = ServisiService.GetResponse(ServisID.ToString());

            if (response.IsSuccessStatusCode)
            {
                ServisInfo_API.Models.Servisi servis = response.Content.ReadAsAsync<ServisInfo_API.Models.Servisi>().Result;
                servis.DatumPocetka = DateTime.Now;
                HttpResponseMessage response2 = ServisiService.PutResponse(ServisID, servis);
                MessageBox.Show("Servis uspjesno zapocet");

                Bind();
            }

        }

        private void ZavrsiBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                HttpResponseMessage response = ServisiService.GetResponse(ServisID.ToString());

                if (response.IsSuccessStatusCode)
                {
                    ServisInfo_API.Models.Servisi servis = response.Content.ReadAsAsync<ServisInfo_API.Models.Servisi>().Result;
                    servis.DatumZavršetka = DateTime.Now;
                    servis.Cijena = Convert.ToDecimal(CijenaTxt.Text);
                    servis.Opis = opisTxt.Text;

                    servis.TrajanjeDani = DateTime.Now.DayOfYear -  s.DatumPocetka.Value.DayOfYear; // bug ako su 2 razlicite godine !

                    HttpResponseMessage response2 = ServisiService.PutResponse(ServisID, servis);
                    MessageBox.Show("Servis uspjesno završen");

                    if (MessageBox.Show("Da li zelite prikazati izvjestaj servisa?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        HttpResponseMessage r = ServisiService.GetActionResponse("GetIzvjestaj", ServisID.ToString());
                        if (r.IsSuccessStatusCode)
                        {
                            DetaljiServisa_Report detalji = r.Content.ReadAsAsync<DetaljiServisa_Report>().Result;

                            Reports.ReportViewForm frm = new Reports.ReportViewForm();
                            frm.detalji = detalji;
                            frm.Show();
                        }
                    }

                    Bind();
                }
            }
        }

        private void PonudaBtn_Click(object sender, EventArgs e)
        {
            Ponude.DetaljiPonude frm = new Ponude.DetaljiPonude(s.PonudaID);
            frm.ShowDialog();
            Bind();
        }

        private void CijenaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(CijenaTxt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(CijenaTxt, "Morate unijeti konacnu cijenu popravke");
            }
            else
                errorProvider.SetError(CijenaTxt, null);
        }

        private void IzvjestajBtn_Click(object sender, EventArgs e)
        {

            HttpResponseMessage r = ServisiService.GetActionResponse("GetIzvjestaj", ServisID.ToString());
            if (r.IsSuccessStatusCode)
            {
                DetaljiServisa_Report detalji = r.Content.ReadAsAsync<DetaljiServisa_Report>().Result;

                Reports.ReportViewForm frm = new Reports.ReportViewForm();
                frm.detalji = detalji;

                frm.Show();
            }
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

        private void DetaljiServisa_Load(object sender, EventArgs e)
        {

        }
    }
}

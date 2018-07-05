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
    public partial class DetaljiPonude : Form
    {
        private WebAPIHelper PonudeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.PonudeRoute);
        private WebAPIHelper ServisiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.ServisiRoute);


        private int PonudaID { get; set; }
        private PonudaDetalji_Result p { get; set; }

        public DetaljiPonude(int ponudaID)
        {
            PonudaID = ponudaID;
            InitializeComponent();
        }


        private void DetaljiPonude_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = PonudeService.GetActionResponse("GetDetalji", PonudaID.ToString());
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    p = null;
                else if (response.IsSuccessStatusCode)
                {
                    p = response.Content.ReadAsAsync<PonudaDetalji_Result>().Result;
                    FillForm();
                }
            }


        }
        private void FillForm()
        {
            PonudaIDLbl.Text = PonudaID.ToString();
            UpitIDLbl.Text = p.UpitID.ToString();
            DatumLbl.Text = p.DatumKreiranja.ToShortDateString();
            KlijentLbl.Text = p.Klijent_ime_i_prezime;
            DaniLbl.Text = (Convert.ToInt32(p.TrajanjeDani)).ToString();
            SatiLbl.Text = p.TrajanjeSati.ToString();
            CijenaLbl.Text = p.Cijena.ToString();
            OdgovorTxt.Text = p.Odgovor;
            KategorijaLbl.Text = p.Naziv;
            

            if (p.Prihvacena == true)
            {
                DaLbl.Text = "DA";
                NeLbl.Hide();
                servisBtn.Show();
            }
            else
            {
                DaLbl.Hide();
                NeLbl.Text = "NE";
                servisBtn.Hide();
            }
        }
    
        private void NazadBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   

        private void servisBtn_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = ServisiService.GetActionResponse("GetServisByPonudaID", PonudaID.ToString());

                Servisi.DetaljiServisa frm=new Servisi.DetaljiServisa(response.Content.ReadAsAsync<int>().Result);
                frm.ShowDialog();
        }
    }
}

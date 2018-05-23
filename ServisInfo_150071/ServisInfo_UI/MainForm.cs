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

namespace ServisInfo_UI
{
    public partial class MainForm : Form
    {
        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);
        private WebAPIHelper KompanijeUpitiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeUpitiRoute);
        private WebAPIHelper ServisiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.ServisiRoute);




        public MainForm()
        {
            InitializeComponent();
            BindGrid();
        }

        private void BindGrid()
        {
            HttpResponseMessage response = KompanijeService.GetResponse(Global.prijavljenaKompanija.KompanijaID.ToString());
            if (response.IsSuccessStatusCode)
            {
                Kompanije k = response.Content.ReadAsAsync<Kompanije>().Result;
                ServisLbl.Text = k.Naziv;
            }

            //

            HttpResponseMessage response2 = KompanijeUpitiService.GetActionResponse("GetCountNeodgovoreni", Global.prijavljenaKompanija.KompanijaID.ToString());
            if (response2.IsSuccessStatusCode)
            {
                UpitiLbl.Text = response2.Content.ReadAsAsync<int>().Result.ToString();
            }
            else
            {
                UpitiLbl.Text = "0";
            }

            //

            HttpResponseMessage response3 = ServisiService.GetActionResponse("GetCountUtoku", Global.prijavljenaKompanija.KompanijaID.ToString());
            if (response3.IsSuccessStatusCode)
            {
                BrojServisaLbl.Text = response3.Content.ReadAsAsync<int>().Result.ToString();
            }
            else
            {
                BrojServisaLbl.Text = "0";
            }

            //

            DatumLbl.Text = DateTime.Now.ToShortDateString();



        }

        private void pregledUpitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upiti.PregledUpita frm = new Upiti.PregledUpita();
            frm.ShowDialog();
            BindGrid();
        }

        private void pregledPonudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ponude.PregledPonuda frm = new Ponude.PregledPonuda();
            frm.ShowDialog();
            BindGrid();
        }

        private void pregledServisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Servisi.PregledServisa frm = new Servisi.PregledServisa();
            frm.ShowDialog();
            BindGrid();
        }

        private void UpitiBtn_Click(object sender, EventArgs e)
        {
            Upiti.PregledUpita frm = new Upiti.PregledUpita();
            frm.ShowDialog();
            BindGrid();
        }

        private void PonudeBtn_Click(object sender, EventArgs e)
        {
            Servisi.PregledServisa frm = new Servisi.PregledServisa();
            frm.ShowDialog();
            BindGrid();
        }

        private void ServisiBtn_Click(object sender, EventArgs e)
        {
            Servisi.PregledServisa frm = new Servisi.PregledServisa();
            frm.ShowDialog();
            BindGrid();
        }
    }
}

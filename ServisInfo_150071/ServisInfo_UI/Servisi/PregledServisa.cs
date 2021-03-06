﻿using ServisInfo_API.Models;
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
    public partial class PregledServisa : Form
    {
        private WebAPIHelper ServisiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.ServisiRoute);

        public PregledServisa()
        {

            InitializeComponent();
        }


        private void PregledServisa_Load(object sender, EventArgs e)
        {
            OdDtm.Value = DateTime.Now.AddDays(-30);
            DoDtm.Value = DateTime.Now.AddDays(1);
            UtokuChck.Checked = true;
            ZavrseniChck.Checked = true;

            BindGrid();
        }

        private string getStatus()
        {
            string status = "";

            if (UtokuChck.Checked && ZavrseniChck.Checked)
            {
                status = "sve";
            }
            else if (UtokuChck.Checked && ZavrseniChck.Checked == false)
            {
                status = "utoku";
            }
            else if (UtokuChck.Checked == false && ZavrseniChck.Checked == true)
            {
                status = "zavrseni";
            }
            else
            {
                status = "nista";
            }

            return status;
        }
        private void BindGrid()
        {

            string status = getStatus();

            HttpResponseMessage response = ServisiService.GetActionResponse("GetByDate", Global.prijavljenaKompanija.KompanijaID.ToString(), OdDtm.Value.ToUniversalTime().ToString("dd-MM-yyyy"), DoDtm.Value.ToUniversalTime().ToString("dd-MM-yyyy"), status);

            if (response.IsSuccessStatusCode)
            {
                List<KompanijaServisi_Result> upiti = response.Content.ReadAsAsync<List<KompanijaServisi_Result>>().Result;
                ServisiGrid.DataSource = upiti;
                ServisiGrid.ClearSelection();
                LayoutSet();
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void LayoutSet()
        {
            ServisiGrid.Columns["ServisID"].Visible = false;
            ServisiGrid.Columns["PonudaID"].Visible = false;
            ServisiGrid.Columns["UpitID"].Visible = false;
            ServisiGrid.Columns["KlijentID"].Visible = false;

            ServisiGrid.Columns["Ime_klijenta"].HeaderText = "Ime klijenta";
            ServisiGrid.Columns["Završna_Cijena"].HeaderText = "Zavrsna cijena";
            ServisiGrid.Columns["DatumPocetka"].HeaderText = "Datum pocetka servisa";
            ServisiGrid.Columns["DatumPrihvatanja"].HeaderText = "Datum prihvatanja servisa";
            ServisiGrid.Columns["DatumZavršetka"].HeaderText = "Datum zavrsetka servisa";


            ServisiGrid.Columns["DatumPrihvatanja"].DisplayIndex = 5;
            ServisiGrid.Columns["DatumPocetka"].DisplayIndex = 6;
            ServisiGrid.Columns["DatumZavršetka"].DisplayIndex = 7;
            ServisiGrid.Columns["Završna_Cijena"].DisplayIndex = 8;
        }



        private void DetaljiBtn_Click(object sender, EventArgs e)
        {

            if (ServisiGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati servis");
            }
            else
            {
                DetaljiServisa frm = new DetaljiServisa(Convert.ToInt32(ServisiGrid.SelectedRows[0].Cells[0].Value));
                frm.ShowDialog();
                BindGrid();
            }
        }

        private void PrikaziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void UtokuChck_CheckedChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void ZavrseniChck_CheckedChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}

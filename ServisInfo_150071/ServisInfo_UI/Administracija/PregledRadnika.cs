using ServisInfo_API.Models;
using ServisInfo_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisInfo_UI.Administracija
{
    public partial class PregledRadnika : Form
    {
        public int kId;
        public PregledRadnika(int kompanijaId)
        {
            kId = kompanijaId;
            InitializeComponent();
        }

        private void PregledRadnika_Load(object sender, EventArgs e)
        {
            BindGrid();

        }
        private WebAPIHelper kompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);

        private void BindGrid()
        {
            HttpResponseMessage response = kompanijeService.GetActionResponse("SearchRadniciByKompanijaId",kId.ToString(), NazivInput.Text.Trim());

            if (response.IsSuccessStatusCode)
            {
                List<Kompanije> kompanije = response.Content.ReadAsAsync<List<Kompanije>>().Result;

                KompanijeGrid.DataSource = kompanije;

                KompanijeGrid.ClearSelection();

                KompanijeGrid.Columns[0].Visible=false;
                KompanijeGrid.Columns[1].Visible = false;
                KompanijeGrid.Columns[2].Visible = false;
                KompanijeGrid.Columns[3].Visible = false;
                KompanijeGrid.Columns[6].Visible = false;
                KompanijeGrid.Columns[7].Visible = false;
                KompanijeGrid.Columns[8].Visible = false;
                KompanijeGrid.Columns[9].Visible = false;
                KompanijeGrid.Columns[10].Visible = false;
                KompanijeGrid.Columns[11].Visible = false;
                KompanijeGrid.Columns[12].Visible = false;
                KompanijeGrid.Columns[13].Visible = false;
                KompanijeGrid.Columns[14].Visible = false;

                KompanijeGrid.Columns[5].HeaderText = "Radnik";
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void traziButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KompanijeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati kompaniju");
            }
            else
            {
                int id = Convert.ToInt32(KompanijeGrid.SelectedRows[0].Cells[0].Value);

                KompanijeAdministracija.IzmjenaProfila frm = new KompanijeAdministracija.IzmjenaProfila(id);
                frm.ShowDialog();
                BindGrid();
            }

        }

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
            if (KompanijeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati korisnika");
            }
            else
            {
                int id = Convert.ToInt32(KompanijeGrid.SelectedRows[0].Cells[0].Value);

                if (id != 12)
                {
                    kompanijeService.DeleteResponse(id.ToString());
                }
                BindGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajRadnika frm = new DodajRadnika(kId);
            frm.ShowDialog();
            BindGrid();
        }
    }
}

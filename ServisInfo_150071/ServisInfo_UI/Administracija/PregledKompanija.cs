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
    public partial class PregledKompanija : Form
    {
        public PregledKompanija()
        {
            InitializeComponent();
        }
        private void PregledKompanija_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private WebAPIHelper kompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);


        private void BindGrid()
        {
            HttpResponseMessage response = kompanijeService.GetActionResponse("SearchByNaziv", NazivInput.Text.Trim());

            if (response.IsSuccessStatusCode)
            {
                List<Kompanije_Result> kompanije = response.Content.ReadAsAsync<List<Kompanije_Result>>().Result;

                kompanije = kompanije.Where(x => !string.IsNullOrEmpty(x.Naziv_kompanije)).ToList();
                KompanijeGrid.DataSource = kompanije;
                KompanijeGrid.ClearSelection();

                KompanijeGrid.Columns[0].HeaderText = "ID kompanije";
                KompanijeGrid.Columns[1].HeaderText = "Naziv kompanije";
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


        private void novaKompanijaBtn_Click(object sender, EventArgs e)
        {
            DodajKompaniju frm = new DodajKompaniju();
            frm.ShowDialog();
            BindGrid();
        }

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
            if (KompanijeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati kompaniju");
            }
            else
            {
                int id = Convert.ToInt32(KompanijeGrid.SelectedRows[0].Cells[0].Value);

                kompanijeService.DeleteResponse(id.ToString());

                BindGrid();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (KompanijeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati kompaniju");
            }
            else
            {
                int id = Convert.ToInt32(KompanijeGrid.SelectedRows[0].Cells[0].Value);

               DodajRadnika frm = new DodajRadnika(id);
                frm.ShowDialog();
                BindGrid();
            }
        }
    }
}

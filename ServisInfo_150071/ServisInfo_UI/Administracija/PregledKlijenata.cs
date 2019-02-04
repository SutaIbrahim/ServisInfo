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
    public partial class PregledKlijenata : Form
    {
        public PregledKlijenata()
        {
            InitializeComponent();
        }

        private void PregledKlijenata_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private WebAPIHelper klijentiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KlijentiRoute);

        private void BindGrid()
        {
            HttpResponseMessage response = klijentiService.GetActionResponse("SearchByNaziv", NazivInput.Text.Trim());

            if (response.IsSuccessStatusCode)
            {
                List<Klijenti> kompanije = response.Content.ReadAsAsync<List<Klijenti>>().Result;
                KompanijeGrid.DataSource = kompanije;
                KompanijeGrid.ClearSelection();

                KompanijeGrid.Columns[0].HeaderText = "ID klijenta";
                KompanijeGrid.Columns[1].HeaderText = "Ime ";
                KompanijeGrid.Columns[2].HeaderText = "Prezime ";

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

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
             if (KompanijeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati kompaniju");
            }
            else
            {
                int id = Convert.ToInt32(KompanijeGrid.SelectedRows[0].Cells[0].Value);

                klijentiService.DeleteResponse(id.ToString());

                BindGrid();
            }
        }
    }
}

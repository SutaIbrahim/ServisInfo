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
    public partial class PregledPonuda : Form
    {

        private WebAPIHelper PonudeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.PonudeRoute);

        public PregledPonuda()
        {
            InitializeComponent();
        }

        private void PregledPonuda_Load(object sender, EventArgs e)
        {
            OdDtm.Value = DateTime.Now.AddDays(-30);
            DoDtm.Value = DateTime.Now.AddDays(1);

            BindGrid();
        }

        private void BindGrid()
        {

            HttpResponseMessage response = PonudeService.GetActionResponse("GetByDate", Global.prijavljenaKompanija.KompanijaID.ToString(), OdDtm.Value.ToUniversalTime().ToString(),DoDtm.Value.ToUniversalTime().ToString()); 


            if (response.IsSuccessStatusCode)
            {
                List<KompanijaPonude_Result> ponude = response.Content.ReadAsAsync<List<KompanijaPonude_Result>>().Result;
                PonudeGrid.DataSource = ponude;
                PonudeGrid.ClearSelection();

            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void PonudeGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DetaljiPonude frm = new DetaljiPonude(Convert.ToInt32(PonudeGrid.SelectedRows[0].Cells[0].Value));
            frm.ShowDialog();
            BindGrid();
        }

        private void PrikaziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}

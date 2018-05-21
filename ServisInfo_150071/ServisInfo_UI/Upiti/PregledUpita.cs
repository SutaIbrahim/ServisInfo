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

namespace ServisInfo_UI.Upiti
{
    public partial class PregledUpita : Form
    {
        public PregledUpita()
        {
            InitializeComponent();
        }

        private WebAPIHelper UpitiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.UpitiRoute);


        private void PregledUpita_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {


            ///    HttpResponseMessage response = UpitiService.GetActionResponse("GetByDate", OdDtm.ToString(),DoDtm.ToString());

            HttpResponseMessage response = UpitiService.GetActionResponse("GetByDate", Global.prijavljenaKompanija.KompanijaID.ToString(), OdDtm.Value.ToUniversalTime().ToString(),DoDtm.Value.ToUniversalTime().ToString());

           // HttpResponseMessage response = UpitiService.GetActionResponse("GetByDate","2","2"); // poslati datum za provjeru i kompanija id




            if (response.IsSuccessStatusCode)
            {
                List<KompanijaUpiti_Result> upiti = response.Content.ReadAsAsync<List<KompanijaUpiti_Result>>().Result;
                UpitiGrid.DataSource = upiti;
                UpitiGrid.ClearSelection();

            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PrikaziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void DetaljiBtn_Click(object sender, EventArgs e)
        {
            DetaljiUpita frm = new DetaljiUpita(Convert.ToInt32(UpitiGrid.SelectedRows[0].Cells[0].Value));
            frm.ShowDialog();
            BindGrid();


        }
    }
}

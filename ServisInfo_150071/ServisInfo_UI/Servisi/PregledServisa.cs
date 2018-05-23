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

            HttpResponseMessage response = ServisiService.GetActionResponse("GetByDate", Global.prijavljenaKompanija.KompanijaID.ToString(), OdDtm.Value.ToUniversalTime().ToString(), DoDtm.Value.ToUniversalTime().ToString(),status);

            if (response.IsSuccessStatusCode)
            {
                List<KompanijaServisi_Result> upiti = response.Content.ReadAsAsync<List<KompanijaServisi_Result>>().Result;
                ServisiGrid.DataSource = upiti;
                ServisiGrid.ClearSelection();

            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }


        private void DetaljiBtn_Click(object sender, EventArgs e)
        {
            DetaljiServisa frm = new DetaljiServisa(Convert.ToInt32(ServisiGrid.SelectedRows[0].Cells[0].Value));
            frm.ShowDialog();
            BindGrid();
        }

        private void PrikaziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}

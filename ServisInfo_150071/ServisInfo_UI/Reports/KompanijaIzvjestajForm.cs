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

namespace ServisInfo_UI.Reports
{
    public partial class KompanijaIzvjestajForm : Form
    {
        private WebAPIHelper KompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);

        public KompanijaIzvjestajForm()
        {
            InitializeComponent();
        }
        private void KompanijaIzvjestajForm_Load(object sender, EventArgs e)
        {
            OdDtm.Value = DateTime.Now.AddDays(-30);
            DoDtm.Value = DateTime.Now.AddDays(1);
        }

        private void KreirajBtn_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = KompanijeService.GetActionResponse("GetPodaci",Global.prijavljenaKompanija.KompanijaID.ToString(), OdDtm.Value.ToUniversalTime().ToString(), DoDtm.Value.ToUniversalTime().ToString());
            if (response.IsSuccessStatusCode)
            {
                List<KompanijaPrometByDate_Report> podaci = response.Content.ReadAsAsync<List<KompanijaPrometByDate_Report>>().Result;
                //report


                this.Close();

            }
        }

       
    }
}

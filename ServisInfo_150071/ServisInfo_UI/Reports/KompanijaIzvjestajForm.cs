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
            HttpResponseMessage response = KompanijeService.GetActionResponse("GetPodaci", Global.prijavljenaKompanija.KompanijaID.ToString(), OdDtm.Value.ToUniversalTime().ToString("dd-MM-yyyy"), DoDtm.Value.ToUniversalTime().ToString("dd-MM-yyyy"));
            if (response.IsSuccessStatusCode)
            {
                List<KompanijaPrometByDate_Report> podaci = response.Content.ReadAsAsync<List<KompanijaPrometByDate_Report>>().Result;

                if (podaci.Count() > 0)
                {
                    //report
                    Reports.KompanijaIzvjestajViewForm frm = new Reports.KompanijaIzvjestajViewForm();
                    frm.podaci = podaci;
                    frm.Show();
                    //
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nisu pronadjeni podaci za trazeni raspon datuma");
                }
            }
            else
            {
                MessageBox.Show("Doslo je do greske");
            }
        }


    }
}

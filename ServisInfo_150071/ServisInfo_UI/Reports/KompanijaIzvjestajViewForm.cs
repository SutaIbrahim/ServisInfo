using Microsoft.Reporting.WinForms;
using ServisInfo_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisInfo_UI.Reports
{
    public partial class KompanijaIzvjestajViewForm : Form
    {

        public List<KompanijaPrometByDate_Report> podaci;

        public KompanijaIzvjestajViewForm()
        {
            InitializeComponent();
        }

        private void KompanijaIzvjestajViewForm_Load(object sender, EventArgs e)
        {

            ReportDataSource rds = new ReportDataSource("DataSet2", podaci);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

           // this.reportViewer1.LocalReport.SetParameters(new ReportParameter("NazivKompanije", podaci[0].Naziv_kompanije));
            
            this.reportViewer1.RefreshReport();
        }
    }
}

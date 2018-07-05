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
    public partial class ReportViewForm : Form
    {

        public DetaljiServisa_Report detalji;


        public ReportViewForm()
        {
            InitializeComponent();
        }

        private void ReportViewForm_Load(object sender, EventArgs e)
        {

            List<DetaljiServisa_Report> l = new List<DetaljiServisa_Report>();
            l.Add(detalji);

            ReportDataSource rds = new ReportDataSource("DataSet1", l);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ServisID", detalji.ServisID.ToString()));

            this.reportViewer1.RefreshReport();
        }
    }
}

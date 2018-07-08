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
            OdDtm.Value = DateTime.Now.AddDays(-30);
            DoDtm.Value = DateTime.Now.AddDays(1);

            BindGrid();
        }

        private void BindGrid()
        {
            HttpResponseMessage response = UpitiService.GetActionResponse("GetByDate", Global.prijavljenaKompanija.KompanijaID.ToString(), OdDtm.Value.ToUniversalTime().ToString("dd-MM-yyyy"), DoDtm.Value.ToUniversalTime().ToString("dd-MM-yyyy"));

            if (response.IsSuccessStatusCode)
            {
                List<KompanijaUpiti_Result> upiti = response.Content.ReadAsAsync<List<KompanijaUpiti_Result>>().Result;
                UpitiGrid.DataSource = upiti;
                UpitiGrid.ClearSelection();

                LayoutSet();
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void LayoutSet()
        {
            UpitiGrid.Columns[0].Visible = false;
            UpitiGrid.Columns[1].Visible = false;
            UpitiGrid.Columns[2].Visible = false;

            UpitiGrid.Columns["KAtegorija"].HeaderText = "Kategorija";
            UpitiGrid.Columns["Datum_upita"].HeaderText = "Datum kreiranja upita";
            UpitiGrid.Columns["Marka_uredjaja"].HeaderText = "Marka uredjaja";
            UpitiGrid.Columns["Zeljeni_datum_prijema_Od"].HeaderText = "Zeljeni datum prijema OD";
            UpitiGrid.Columns["Zeljeni_datum_prijema_Do"].HeaderText = "Zeljeni datum prijema DO";
            UpitiGrid.Columns["Odgovoreno"].DisplayIndex = 9;
        }

        private void PrikaziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void DetaljiBtn_Click(object sender, EventArgs e)
        {
            if (UpitiGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati upit");
            }
            else
            {
                DetaljiUpita frm = new DetaljiUpita(Convert.ToInt32(UpitiGrid.SelectedRows[0].Cells[0].Value));
                frm.ShowDialog();
                BindGrid();
            }

        }

    }
}

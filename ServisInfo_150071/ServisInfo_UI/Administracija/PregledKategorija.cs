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
    public partial class PregledKategorija : Form
    {
        private WebAPIHelper KategorijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KategorijeRoute);

        public PregledKategorija()
        {
            InitializeComponent();
        }

        private void NovaBtn_Click(object sender, EventArgs e)
        {
            Administracija.DodajKategoriju frm = new Administracija.DodajKategoriju();
            frm.ShowDialog();
            BindGrid();
        }

        private void PregledKategorija_Load(object sender, EventArgs e)
        {
            BindGrid();
        }


        private void BindGrid()
        {

            HttpResponseMessage response = KategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Kategorije> lista = response.Content.ReadAsAsync<List<Kategorije>>().Result;
                lista = lista.OrderBy(x => x.Naziv).ToList();

                KategorijeGrid.DataSource = lista;
                KategorijeGrid.ClearSelection();
                KategorijeGrid.Columns[0].HeaderText = "ID Kategorije";
                KategorijeGrid.Columns[2].Visible = false;
                KategorijeGrid.Columns[3].Visible = false;
            }
        }


    }
}

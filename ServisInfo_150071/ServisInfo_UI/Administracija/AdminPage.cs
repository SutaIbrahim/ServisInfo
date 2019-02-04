using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisInfo_UI.Administracija
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void KompanijaBtn_Click(object sender, EventArgs e)
        {
            Administracija.DodajKompaniju frm = new Administracija.DodajKompaniju();
            frm.ShowDialog();
        }

        private void OdjavaBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void KategorijaBtn_Click(object sender, EventArgs e)
        {
            Administracija.DodajKategoriju frm = new Administracija.DodajKategoriju();
            frm.ShowDialog();
        }

        private void PregledKompanijaBtn_Click(object sender, EventArgs e)
        {
            Administracija.PregledKompanija frm = new Administracija.PregledKompanija();
            frm.ShowDialog();
        }

        private void pregledKategorijaBtn_Click(object sender, EventArgs e)
        {
            Administracija.PregledKategorija frm = new Administracija.PregledKategorija();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administracija.PregledKlijenata frm = new Administracija.PregledKlijenata();
            frm.ShowDialog();
        }
    }
}

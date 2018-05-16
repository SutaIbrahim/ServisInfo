using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ServisInfo_UI.Util;
using ServisInfo_API.Models;
using System.Net.Http;
using System.Resources;
using System.Configuration;

namespace ServisInfo_UI
{
    public partial class LoginForm : Form
    {
        private WebAPIHelper kompanijeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KompanijeRoute);

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Prijava()
        {
            
        }

        private void potvrdiButton_Click(object sender, EventArgs e)
        {
            Prijava();
        }

        private void odustaniButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lozinkaInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Prijava();
        }
    }
}

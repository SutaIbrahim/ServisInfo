using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisInfo_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            #region Culture set
            // koristeno za potrebe promjene formata datuma (pogledati app.config(UI) i web.config(API)
            CultureInfo culture = new CultureInfo(ConfigurationManager.AppSettings["DefaultCulture"]);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            //
            # endregion



            //Application.Run(new LoginForm());

            //Application.Run(new Ponude.PregledPonuda());

            LoginForm frm = new LoginForm();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                //if (Global.prijavljenaKompanija.Naziv == "Admin")
                //    Application.Run(new Administracija.AdminPage());
                //else
                    Application.Run(new MainForm());
            }
        }
    }
}
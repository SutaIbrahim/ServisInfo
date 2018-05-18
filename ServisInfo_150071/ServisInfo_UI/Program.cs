using System;
using System.Collections.Generic;
using System.Linq;
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
            //Application.Run(new LoginForm());

            //Application.Run(new Upiti.PregledUpita());

            LoginForm frm = new LoginForm();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
                Application.Run(new Upiti.PregledUpita());
        }
    }
}

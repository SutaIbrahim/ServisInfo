using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace ServisInfoSolution
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            Global.prvoPokretanje = true;

            Global.APIAdress = "http://192.168.0.26/"; // setovanje API ADRESSE

            MainPage = new Navigation.MasterDetailPage();

        }
       
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{

            //var userSelectedCulture = new CultureInfo("hr-HR");

            //Thread.CurrentThread.CurrentCulture = userSelectedCulture;

            // Handle when your app resumes
        }
	}
}

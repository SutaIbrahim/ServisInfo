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
            //SetCultureToUSEnglish();
            //MainPage = new NavigationPage(new Prijava());

            Global.prvoPokretanje = true;
            Global.APIAdress = "http://localhost:64158/";

            MainPage = new Navigation.MasterDetailPage();

            //MainPage = new NavigationPage(new MasterDetailPage());

        }
        //private void SetCultureToUSEnglish()
        //{
        //    CultureInfo englishUSCulture = new CultureInfo("hr-HR");
        //    CultureInfo.DefaultThreadCurrentCulture = englishUSCulture;
        //}
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

            var userSelectedCulture = new CultureInfo("hr-HR");

            Thread.CurrentThread.CurrentCulture = userSelectedCulture;
            // Handle when your app resumes
        }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ServisInfo_PCL.Util;
using ServisInfo_PCL.Model;
using System.Net.Http;


namespace ServisInfoSolution
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registracija : ContentPage
	{

        private WebAPIHelper klijentiService = new WebAPIHelper("http://localhost:64158/", "api/Klijenti");

		public Registracija ()
		{
			InitializeComponent();
		}

        private void registrujSeButton_Clicked(object sender, EventArgs e)
        {

            HttpResponseMessage response = klijentiService.GetResponse("1");

            if (response.IsSuccessStatusCode)
            {


            }
        }
    }

}
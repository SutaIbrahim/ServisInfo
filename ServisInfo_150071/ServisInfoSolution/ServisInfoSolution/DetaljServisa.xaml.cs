using ServisInfo_PCL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServisInfoSolution
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetaljServisa : ContentPage
	{
        private WebAPIHelper servisiService = new WebAPIHelper("http://localhost:64158/", "api/Servisi");

        private int servisID;

        public DetaljServisa (int servisID)
		{
            this.servisID = servisID;
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            Fill();
        }

        private void Fill()
        {
            HttpResponseMessage response = servisiService.GetActionResponse("GetDetalji", ponudaID.ToString());



        }


    }
}
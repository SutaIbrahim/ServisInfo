using Newtonsoft.Json;
using ServisInfo_PCL.Model;
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
	public partial class PregledServisa : ContentPage
	{
        private WebAPIHelper servisiService = new WebAPIHelper("http://localhost:64158/", "api/Servisi");


        public PregledServisa ()
		{
            InitializeComponent ();
            OdDtm.Date = DateTime.Now.AddDays(-30);
            DoDtm.Date = DateTime.Now.AddDays(1);

        }

        protected override void OnAppearing()
        {
            //HttpResponseMessage response = servisiService.GetActionResponse("GetByDateAndKlijent", Global.prijavljeniKlijent.KlijentID.ToString(), DateTime.Now.AddDays(-30).ToString("dd.MM.yyyy"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
            HttpResponseMessage response = servisiService.GetActionResponse("GetByDateAndKlijent", Global.prijavljeniKlijent.KlijentID.ToString(), OdDtm.Date.ToString("dd.MM.yyyy"), DoDtm.Date.ToString("dd.MM.yyyy"));

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<ServisiKlijent_Result> servisi = JsonConvert.DeserializeObject<List<ServisiKlijent_Result>>(jsonObject.Result);

                foreach (var x in servisi) // set datetime to string
                {
                    x.DatumPrihvatanjaS = x.DatumPrihvatanja.ToShortDateString().ToString();
                    x.DatumPocetkaS = x.DatumPocetka.ToString();
                    x.DatumZavrsetkaS = x.DatumZavršetka.ToString();
                }

                servisiList.ItemsSource = servisi;
            }


            base.OnAppearing();
        }


        private void Search()
        {
            HttpResponseMessage response = servisiService.GetActionResponse("GetByDateAndKlijent", Global.prijavljeniKlijent.KlijentID.ToString(), OdDtm.Date.ToString("dd.MM.yyyy"), DoDtm.Date.ToString("dd.MM.yyyy"));

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<ServisiKlijent_Result> servisi = JsonConvert.DeserializeObject<List<ServisiKlijent_Result>>(jsonObject.Result);
                
                foreach(var x in servisi) // set datetime to string
                {
                    x.DatumPrihvatanjaS = x.DatumPrihvatanja.ToShortDateString().ToString();
                    x.DatumPocetkaS = x.DatumPocetka.ToString();
                    x.DatumZavrsetkaS = x.DatumZavršetka.ToString();
                }

                servisiList.ItemsSource = servisi;
            }

        }


        private void servisiList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void OdDtm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }

        private void DoDtm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }
    }
}
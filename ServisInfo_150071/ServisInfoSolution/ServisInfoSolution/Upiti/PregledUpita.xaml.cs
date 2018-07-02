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
	public partial class PregledUpita : ContentPage
	{

        private WebAPIHelper upitiService = new WebAPIHelper(Global.APIAdress, "api/Upiti");

        public PregledUpita ()
		{
			InitializeComponent ();
            OdDtm.Date = DateTime.Now.AddDays(-30);
            DoDtm.Date = DateTime.Now.AddDays(1);
        }

        protected override void OnAppearing()
        {
            Search();

            base.OnAppearing();
        }

        private void Search()
        {
            HttpResponseMessage response = upitiService.GetActionResponse("GetByDateAndKlijent", Global.prijavljeniKlijent.KlijentID.ToString(), OdDtm.Date.ToString("dd-MM-yyyy"), DoDtm.Date.ToString("dd-MM-yyyy"));

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<UpitiKlijentByDate_Result> upiti = JsonConvert.DeserializeObject<List<UpitiKlijentByDate_Result>>(jsonObject.Result);

                foreach (var x in upiti) // set datetime to string
                {
                    x.DatumUpitaS = x.Datum_upita.ToString();
                }

                upitiList.ItemsSource = upiti;
            }

        }

        private void upitiList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.Navigation.PushAsync(new DetaljiUpita((e.Item as UpitiKlijentByDate_Result).UpitID));
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
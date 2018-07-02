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
        private WebAPIHelper servisiService = new WebAPIHelper(Global.APIAdress, "api/Servisi");
        List<ServisiKlijent_Result> servisi;

        public PregledServisa()
        {
            InitializeComponent();
            OdDtm.Date = DateTime.Now.AddDays(-30);
            DoDtm.Date = DateTime.Now.AddDays(1);
            uTokuSw.IsToggled = true;
            zavrseniSw.IsToggled = true;
        }

        protected override void OnAppearing()
        {
            Search();

            base.OnAppearing();
        }


        private void Search()
        {
            HttpResponseMessage response = servisiService.GetActionResponse("GetByDateAndKlijent", Global.prijavljeniKlijent.KlijentID.ToString(), OdDtm.Date.ToString("dd-MM-yyyy"), DoDtm.Date.ToString("dd-MM-yyyy"));

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<ServisiKlijent_Result> s = JsonConvert.DeserializeObject<List<ServisiKlijent_Result>>(jsonObject.Result);

                servisi = s;

                pripremiPodatke();
            }

        }

        private void pripremiPodatke()
        {

            List<ServisiKlijent_Result> filtriraniServisi = new List<ServisiKlijent_Result>();


            foreach (var x in servisi)
            {
                if (uTokuSw.IsToggled == true && zavrseniSw.IsToggled == true)
                {
                    filtriraniServisi.Add(x);
                }
                else if (uTokuSw.IsToggled == true && zavrseniSw.IsToggled == false)
                {
                    if (x.DatumZavršetka == null)
                    {
                        filtriraniServisi.Add(x);
                    }
                }
                else if (uTokuSw.IsToggled == false && zavrseniSw.IsToggled == true)
                {
                    if (x.DatumZavršetka != null)
                    {
                        filtriraniServisi.Add(x);
                    }
                }
            }


            foreach (var x in filtriraniServisi) // set datetime to string
            {
                x.DatumPrihvatanjaS = x.DatumPrihvatanja.ToShortDateString().ToString();
                x.DatumPocetkaS = x.DatumPocetka.ToString();
                x.DatumZavrsetkaS = x.DatumZavršetka.ToString();
            }

            servisiList.ItemsSource = filtriraniServisi;
        }

        private void servisiList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.Navigation.PushAsync(new DetaljServisa((e.Item as ServisiKlijent_Result).ServisID));
        }

        private void OdDtm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }

        private void DoDtm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }

        private void uTokuSw_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }

        private void zavrseniSw_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }
    }
}
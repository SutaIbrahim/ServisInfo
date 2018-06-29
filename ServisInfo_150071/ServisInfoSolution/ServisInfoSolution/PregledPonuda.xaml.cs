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
    public partial class PregledPonuda : ContentPage
    {
        private WebAPIHelper ponudeService = new WebAPIHelper("http://localhost:64158/", "api/Ponude");

        public PregledPonuda()
        {
            InitializeComponent();
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
            HttpResponseMessage response = ponudeService.GetActionResponse("GetByDateAndKlijent", Global.prijavljeniKlijent.KlijentID.ToString(), OdDtm.Date.ToString("dd.MM.yyyy"), DoDtm.Date.ToString("dd.MM.yyyy"));

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<PonudeByDate_Result> ponude = JsonConvert.DeserializeObject<List<PonudeByDate_Result>>(jsonObject.Result);

                foreach (var x in ponude) // set datetime to string
                {
                    x.DatumKreiranjaS = x.DatumKreiranja.ToShortDateString();
                }

                ponudeList.ItemsSource = ponude;
            }

        }



        private void ponudeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.Navigation.PushAsync(new DetaljiPonude((e.Item as PonudeKlijent_Result).PonudaID));

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
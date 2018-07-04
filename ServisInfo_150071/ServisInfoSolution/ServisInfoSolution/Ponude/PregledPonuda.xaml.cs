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
        private WebAPIHelper ponudeService = new WebAPIHelper(Global.APIAdress, "api/Ponude");

        private List<PonudeByDate_Result> ponude;

        public PregledPonuda()
        {
            InitializeComponent();
            OdDtm.Date = DateTime.Now.AddDays(-30);
            DoDtm.Date = DateTime.Now.AddDays(1);

            neSW.IsToggled = true;
            daSW.IsToggled = true;
        }

        protected override void OnAppearing()
        {
            Search();

            base.OnAppearing();
        }

        private void Search()
        {
            HttpResponseMessage response = ponudeService.GetActionResponse("GetByDateAndKlijent", Global.prijavljeniKlijent.KlijentID.ToString(), OdDtm.Date.ToString("dd-MM-yyyy"), DoDtm.Date.ToString("dd-MM-yyyy"));

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                ponude = JsonConvert.DeserializeObject<List<PonudeByDate_Result>>(jsonObject.Result);

                Filter();
               // ponudeList.ItemsSource = ponude;
            }

        }

        private void Filter()
        {
            List<PonudeByDate_Result> filtriranePonude = new List<PonudeByDate_Result>();

            foreach (var x in ponude)
            {
                if (neSW.IsToggled == true && daSW.IsToggled == true)
                {
                    filtriranePonude.Add(x);
                }
                else if (neSW.IsToggled == true && daSW.IsToggled == false)
                {
                    if (x.Prihvacena == false)
                    {
                        filtriranePonude.Add(x);
                    }
                }
                else if (neSW.IsToggled == false && daSW.IsToggled == true)
                {
                    if (x.Prihvacena ==true)
                    {
                        filtriranePonude.Add(x);
                    }
                }

                ponudeList.ItemsSource = filtriranePonude;

            }
            foreach (var x in filtriranePonude) // set datetime to string
            {
                x.DatumKreiranjaS = x.DatumKreiranja.ToShortDateString();
                if (x.Prihvacena)
                {
                    x.PrihvacenaS = "DA";
                }
                else
                {
                    x.PrihvacenaS = "NE";
                }
            }



        }

        private void ponudeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.Navigation.PushAsync(new DetaljiPonude((e.Item as PonudeByDate_Result).PonudaID));

        }

        private void OdDtm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }

        private void DoDtm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Search();
        }

        private void neSW_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Filter();
        }

        private void daSW_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Filter();
        }
    }
}
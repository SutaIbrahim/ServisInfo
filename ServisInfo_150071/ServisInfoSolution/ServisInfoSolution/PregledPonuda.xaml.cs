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
        }

        protected override void OnAppearing()
        {
            HttpResponseMessage response = ponudeService.GetActionResponse("GetPonudeByKlijentID",Global.prijavljeniKlijent.KlijentID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<PonudeKlijent_Result> ponude = JsonConvert.DeserializeObject<List<PonudeKlijent_Result>>(jsonObject.Result);
                ponudeList.ItemsSource = ponude;
            }

            base.OnAppearing();
        }

    }
}
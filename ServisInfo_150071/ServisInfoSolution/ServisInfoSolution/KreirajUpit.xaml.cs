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
    public partial class KreirajUpit : ContentPage
    {

        private WebAPIHelper markeUredjajaService = new WebAPIHelper("http://localhost:64158/", "api/MarkeUredjaja");
        private WebAPIHelper modeliUredjajaService = new WebAPIHelper("http://localhost:64158/", "api/ModeliUredjaja");


        public KreirajUpit()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            HttpResponseMessage response = markeUredjajaService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<MarkeUredjaja> marke = JsonConvert.DeserializeObject<List<MarkeUredjaja>>(jsonObject.Result);
                markaUredjajaPicker.ItemsSource = marke;

                markaUredjajaPicker.ItemDisplayBinding = new Binding("Naziv");
            }


          



        }

        private void markaUredjajaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpResponseMessage response2 = modeliUredjajaService.GetActionResponse("GetByMarkaId",((markaUredjajaPicker.SelectedItem as MarkeUredjaja).MarkaUredjajaID).ToString());

            if (response2.IsSuccessStatusCode)
            {
                var jsonObject = response2.Content.ReadAsStringAsync();
                List<ModeliUredjaja> modeli = JsonConvert.DeserializeObject<List<ModeliUredjaja>>(jsonObject.Result);
                modelUredjajaPicker.ItemsSource = modeli;

                modelUredjajaPicker.ItemDisplayBinding = new Binding("Naziv");
            }
        }
    }
}
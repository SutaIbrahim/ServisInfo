using Newtonsoft.Json;
using Plugin.Media;
using ServisInfo_PCL.Model;
using ServisInfo_PCL.Util;
using System;
using System.Collections.Generic;
using System.IO;
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

            kategorijaLbl.Text = "Izabrana kategorija: " + Global.izabranaKategorija.Naziv;

            string last = "";
            string kompanije = "";
            kompanije = "Izabrane kompanije: ";
            for (int x = 0; x < Global.izabraneKompanije.Count() - 1; x++)
            {
                kompanije += Global.izabraneKompanije[x] + ", ";
            }

            last = Global.izabraneKompanije[Global.izabraneKompanije.Count() - 1];
            kompanije += last;
            kompanijeLbl.Text = kompanije;

            dodajSlikuBtn.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("no upload", "picking a photo is not supported", "ok");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                    return;

                slika.Source = ImageSource.FromStream(() => file.GetStream());

            };

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
            HttpResponseMessage response2 = modeliUredjajaService.GetActionResponse("GetByMarkaId", ((markaUredjajaPicker.SelectedItem as MarkeUredjaja).MarkaUredjajaID).ToString());

            if (response2.IsSuccessStatusCode)
            {
                var jsonObject = response2.Content.ReadAsStringAsync();
                List<ModeliUredjaja> modeli = JsonConvert.DeserializeObject<List<ModeliUredjaja>>(jsonObject.Result);
                modelUredjajaPicker.ItemsSource = modeli;

                modelUredjajaPicker.ItemDisplayBinding = new Binding("Naziv");
            }
        }

        private void posaljiBtn_Clicked(object sender, EventArgs e)
        {
            validacija();


        }

        private void dodajSlikuBtn_Clicked(object sender, EventArgs e)
        {
            
            }


        private void validacija()
        {



        }
    }
}
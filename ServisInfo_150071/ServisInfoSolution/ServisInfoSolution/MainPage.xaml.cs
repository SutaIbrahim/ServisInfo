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

namespace ServisInfoSolution
{
    public partial class MainPage : ContentPage
    {
        private WebAPIHelper kategorijeService = new WebAPIHelper("http://localhost:64158/", "api/Kategorije");
        private WebAPIHelper kompanijeService = new WebAPIHelper("http://localhost:64158/", "api/Kompanije");
        private WebAPIHelper gradoviService = new WebAPIHelper("http://localhost:64158/", "api/Gradovi");

        List<Kompanije> kompanije = new List<Kompanije>();


        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            HttpResponseMessage response = kategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Kategorije> kategorije = JsonConvert.DeserializeObject<List<Kategorije>>(jsonObject.Result);
                kategorijePicker.ItemsSource = kategorije;

                kategorijePicker.ItemDisplayBinding = new Binding("Naziv");
            }

            HttpResponseMessage response2 = gradoviService.GetResponse();

            if (response2.IsSuccessStatusCode)
            {
                var jsonObject = response2.Content.ReadAsStringAsync();
                List<Gradovi> gradovi = JsonConvert.DeserializeObject<List<Gradovi>>(jsonObject.Result);
                gradoviPicker.ItemsSource = gradovi;

                gradoviPicker.ItemDisplayBinding = new Binding("Naziv");
            }

            GreskaLbl.Text = "Nema rezultata";


            base.OnAppearing();
        }

        private void kategorijePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void gradoviPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {

            if (kategorijePicker.SelectedItem != null && gradoviPicker.SelectedItem != null)
            {

                int kategorijaId = (kategorijePicker.SelectedItem as Kategorije).KategorijaID;
                int gradId = (gradoviPicker.SelectedItem as Gradovi).GradID;

                HttpResponseMessage response = kompanijeService.GetActionResponse("SearchByKategorijaGradovi", kategorijaId.ToString(), gradId.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var jsonObject = response.Content.ReadAsStringAsync();
                    kompanije = JsonConvert.DeserializeObject<List<Kompanije>>(jsonObject.Result);
                    kompanijeList.ItemsSource = kompanije;

                    if (kompanije.Count() > 0)
                    {
                        GreskaLbl.Text = "Odaberite kompaniju/e";
                    }
                    else {
                        GreskaLbl.Text = "Nema rezultata";
                    }
                }
            }
            else
            {
                GreskaLbl.Text = "Nema rezultata";
                
            }


        }

        private void kreirajUpitBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}

using Newtonsoft.Json;
using ServisInfo_PCL.Model;
using ServisInfo_PCL.Util;
using ServisInfoSolution.Kompanija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

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
           

            Global.izabraneKompanijeID = new List<int>();
            Global.izabraneKompanije = new List<string>();

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (Global.prvoPokretanje == true) // dodano jer pri prvim pokretanjem pojavi se sidebar
            {
                Global.prvoPokretanje = false;
                this.Navigation.PushAsync(new Prijava());
            }
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


            base.OnAppearing();
        }

        private void kategorijePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.izabraneKompanijeID = new List<int>();
            Global.izabraneKompanije = new List<string>();

            Global.izabranaKategorija = (kategorijePicker.SelectedItem as Kategorije);

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

                    PostaviCheckBox();

                    kompanijeList.ItemsSource = kompanije;

                    if (kompanije.Count() > 0)
                    {
                        GreskaLbl.Text = "Kliknite na kompaniju za prikaz detalja";
                    }
                    else
                    {
                        GreskaLbl.Text = "Nema rezultata";
                    }
                }
            }
            else
            {
                GreskaLbl.Text = "Nema rezultata";
                kompanijeList.ItemsSource = new List<Kompanije>();
            }


        }

        private void PostaviCheckBox()
        {
            if (Global.izabraneKompanijeID.Count > 0)
            {
                foreach (var x in Global.izabraneKompanijeID)
                {
                    foreach (var k in kompanije)
                    {
                        if (k.KompanijaID == x)
                        {
                            k.Izabrana = "✓";
                        }
                    }
                }
            }

        }

        private void kreirajUpitBtn_Clicked(object sender, EventArgs e)
        {
            if (!(Global.izabraneKompanijeID.Count() > 0))
            {
                errorLbl.Text = "*potrebno je izabrati minimalno jednu kompaniju";
            }
            else
            {
                this.Navigation.PushAsync(new KreirajUpit());
            }

        }

        private void kompanijeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.Navigation.PushAsync(new DetaljiKompanije((e.Item as Kompanije).KompanijaID));
        }

        //private void Button_Pressed(object sender, EventArgs e)
        //{
        //}

        public void Dodaj(Object Sender, EventArgs args)
        {
            Xamarin.Forms.Button button = (Xamarin.Forms.Button)Sender;
            string ID = button.CommandParameter.ToString();

            errorLbl.Text = "";

            ////int id = (e.Item as Kompanije).KompanijaID;

            int id = Convert.ToInt32(ID);

            HttpResponseMessage response = kompanijeService.GetResponse(ID);
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                Kompanije temp = JsonConvert.DeserializeObject<Kompanije>(jsonObject.Result);

                bool postoji = false;
                foreach (var x in Global.izabraneKompanijeID.ToList())
                {
                    if (id == x)
                    {
                        Global.izabraneKompanijeID.Remove(x);
                        Global.izabraneKompanije.Remove((temp.Naziv));

                        postoji = true;

                        foreach (var k in kompanije)
                        {
                            if (x == k.KompanijaID)
                                k.Izabrana = "";
                        }
                    }
                }

                if (postoji == false)
                {
                    Global.izabraneKompanijeID.Add(id);
                    Global.izabraneKompanije.Add(temp.Naziv);
                }

                Search();
            }
        }
    }
}

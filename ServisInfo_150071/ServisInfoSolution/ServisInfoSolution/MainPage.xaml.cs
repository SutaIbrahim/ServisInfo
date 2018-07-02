using Newtonsoft.Json;
using ServisInfo_PCL.Model;
using ServisInfo_PCL.Util;
using ServisInfoSolution.Kompanija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ServisInfoSolution
{
    public partial class MainPage : ContentPage
    {
        private WebAPIHelper kategorijeService = new WebAPIHelper(Global.APIAdress, "api/Kategorije");
        private WebAPIHelper kompanijeService = new WebAPIHelper(Global.APIAdress, "api/Kompanije");
        private WebAPIHelper gradoviService = new WebAPIHelper(Global.APIAdress, "api/Gradovi");

        List<KompanijeDetalji_X_Result> kompanije = new List<KompanijeDetalji_X_Result>();


        public MainPage()
        {


            InitializeComponent();
            Fill();
        }

        protected override void OnAppearing()
        {
            if (Global.prvoPokretanje == true) // dodano jer pri prvim pokretanjem pojavi se sidebar na prijavi
            {
                Global.prvoPokretanje = false;
                Global.izabraneKompanijeID = new List<int>();
                Global.izabraneKompanije = new List<string>();
                Global.izabranaKategorija = null;
                Global.izabraniGradIndex = -1;
                Global.izabranaKategorijaIndex = -1;
                this.Navigation.PushAsync(new Prijava());
            }
            base.OnAppearing();
        }
        private void Fill()
        {
            HttpResponseMessage response = kategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Kategorije> kategorije = JsonConvert.DeserializeObject<List<Kategorije>>(jsonObject.Result);
                kategorijePicker.ItemsSource = kategorije;

                kategorijePicker.ItemDisplayBinding = new Binding("Naziv");

                if (Global.izabranaKategorijaIndex != -1)
                {
                    kategorijePicker.SelectedIndex = Global.izabranaKategorijaIndex;
                }
                else
                {
                    // ponistavanje odabira kompanija jer jedna kompanija nema sve kategorije 
                    Global.izabraneKompanijeID = new List<int>();
                    Global.izabraneKompanije = new List<string>();
                }

            }

            HttpResponseMessage response2 = gradoviService.GetResponse();

            if (response2.IsSuccessStatusCode)
            {
                var jsonObject = response2.Content.ReadAsStringAsync();
                List<Gradovi> gradovi = JsonConvert.DeserializeObject<List<Gradovi>>(jsonObject.Result);
                gradoviPicker.ItemsSource = gradovi;

                gradoviPicker.ItemDisplayBinding = new Binding("Naziv");

                if (Global.izabraniGradIndex != -1)
                {
                    gradoviPicker.SelectedIndex = Global.izabraniGradIndex;
                }

            }

        }

        private void kategorijePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((kategorijePicker.SelectedItem as Kategorije) != null)
            {
                // ponistavanje odabira kompanija jer jedna kompanija nema sve kategorije 
                Global.izabraneKompanijeID = new List<int>();
                Global.izabraneKompanije = new List<string>();

                Global.izabranaKategorijaIndex = kategorijePicker.SelectedIndex;
                Global.izabranaKategorija = (kategorijePicker.SelectedItem as Kategorije);
            }

            Search();
        }

        private void gradoviPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((gradoviPicker.SelectedItem as Gradovi) != null)
            {

                // ponistavanje odabira kompanija jer jedna kompanija je iz jednog grada
                Global.izabraneKompanijeID = new List<int>();
                Global.izabraneKompanije = new List<string>();

                Global.izabraniGradIndex = gradoviPicker.SelectedIndex;
            }

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
                    kompanije = JsonConvert.DeserializeObject<List<KompanijeDetalji_X_Result>>(jsonObject.Result);

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
                kompanijeList.ItemsSource = new List<KompanijeDetalji_X_Result>();
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

                        if (k.ProsjecnaOcjena != null)
                        {
                            decimal temp = Convert.ToDecimal(k.ProsjecnaOcjena);
                            k.ProsjecnaOcjena = Math.Round(temp, 2);
                        }

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
                Fill();
            }

        }

        private void kompanijeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.Navigation.PushAsync(new DetaljiKompanije((e.Item as KompanijeDetalji_X_Result).KompanijaID));
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

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

        private WebAPIHelper markeUredjajaService = new WebAPIHelper(Global.APIAdress, "api/MarkeUredjaja");
        private WebAPIHelper modeliUredjajaService = new WebAPIHelper(Global.APIAdress, "api/ModeliUredjaja");
        private WebAPIHelper upitiService = new WebAPIHelper(Global.APIAdress, "api/Upiti");
        private WebAPIHelper kompanijeUpitiService = new WebAPIHelper(Global.APIAdress, "api/Kompanijeupiti");

        int selected1; // odabir marke index
        int selected2; // odabir modela index

        private Stream s; // za sliku

        public KreirajUpit()
        {

            InitializeComponent();

            selected1 = -1;
            selected2 = -1;

            kategorijaLbl.Text = "Izabrana kategorija: " + Global.izabranaKategorija.Naziv;

            string last = "";
            string kompanije = "";
            kompanije = "Izabrane kompanije: ";
            for (int x = 0; x < Global.izabraneKompanije.Count() - 1; x++)
            {
                kompanije += Global.izabraneKompanije[x] + ", ";
            }

            List<int> a = Global.izabraneKompanijeID;

            last = Global.izabraneKompanije[Global.izabraneKompanije.Count() - 1];
            kompanije += last;
            kompanijeLbl.Text = kompanije;
            s = null;


            //otvaranje galerije -->> xam.plugin.media nuget 
            dodajSlikuBtn.Clicked += async (sender, args) =>
            {

                if (slika.Source == null)
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("x", "upload slika nije podrzan", "Ok");
                        return;
                    }

                    var file = await CrossMedia.Current.PickPhotoAsync();
                    if (file == null)
                    {
                        if (selected1 != -1) // dodano zbog androida 8.0 i 8.1 jer se nakon odabira slike resetuje odabir uredjaja
                        {
                            markaUredjajaPicker.SelectedIndex = selected1;
                        }
                        if (selected2 != -1)
                        {
                            modelUredjajaPicker.SelectedIndex = selected2;
                        }
                        return;
                    }

                    //
                    s = file.GetStream();

                    if (s.Length >= 4000000) // ogranicenje 4mb, setovano u webconfig-u apija
                    {
                        slika.Source = null;
                        await DisplayAlert("Greska !", "Velicina slike je veca od 4mb, izaberite manju sliku", "OK");
                    }
                    else
                    {
                        slika.Source = ImageSource.FromStream(() => file.GetStream()); // postavi sliku
                        slika.HeightRequest = 240;
                        dodajSlikuBtn.Text = "Ukloni sliku";
                    }
                    if (selected1 != -1) // dodano zbog androida 8.0 i 8.1 jer se nakon odabira slike resetuje odabir uredjaja
                    {
                        markaUredjajaPicker.SelectedIndex = selected1;
                    }
                    if (selected2 != -1)
                    {
                        modelUredjajaPicker.SelectedIndex = selected2;
                    }
                }
                else
                {
                    if (selected1 != -1) // dodano zbog androida 8.0 i 8.1 jer se nakon odabira slike resetuje odabir uredjaja
                    {
                        markaUredjajaPicker.SelectedIndex = selected1;
                    }
                    if (selected2 != -1)
                    {
                        modelUredjajaPicker.SelectedIndex = selected2;
                    }

                    dodajSlikuBtn.Text = "Dodaj sliku";
                    slika.Source = null;
                    slika.HeightRequest = 35;
                }
               
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

            if ((markaUredjajaPicker.SelectedItem as MarkeUredjaja) != null)
            {
                selected1 = (markaUredjajaPicker.SelectedIndex);

                HttpResponseMessage response2 = modeliUredjajaService.GetActionResponse("GetByMarkaId", ((markaUredjajaPicker.SelectedItem as MarkeUredjaja).MarkaUredjajaID).ToString());

                if (response2.IsSuccessStatusCode)
                {
                    var jsonObject = response2.Content.ReadAsStringAsync();
                    List<ModeliUredjaja> modeli = JsonConvert.DeserializeObject<List<ModeliUredjaja>>(jsonObject.Result);
                    modelUredjajaPicker.ItemsSource = modeli;

                    modelUredjajaPicker.ItemDisplayBinding = new Binding("Naziv");
                }
            }
        }

        private void modelUredjajaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((modelUredjajaPicker.SelectedItem as ModeliUredjaja) != null)
            {
                selected2 = (modelUredjajaPicker.SelectedIndex);
            }
        }

        private void posaljiBtn_Clicked(object sender, EventArgs e)
        {
            if (validacija())
            {
                Upiti u = new Upiti();

                u.OpisKvara = opisKvaraTxt.Text;

                u.ZeljeniDatumPrijemaOd = datumOd.Date;
                u.ZeljeniDatumPrijemaDo = datumDo.Date;
                u.Datum = DateTime.Now;
                u.KategorijaID = Global.izabranaKategorija.KategorijaID;

                u.KlijentID = Global.prijavljeniKlijent.KlijentID;
                u.ModelUredjajaID = (modelUredjajaPicker.SelectedItem as ModeliUredjaja).ModelUredjajaID;

                if (s != null)
                {
                    u.Slika = StreamToBytes(s);
                }
                else
                {
                    u.Slika = null;
                }

                HttpResponseMessage response = upitiService.PostResponse(u);
                if (response.IsSuccessStatusCode)
                {
                    HttpResponseMessage response2 = null;

                    HttpResponseMessage response3 = upitiService.GetActionResponse("GetZadnjiUpit", "");

                    if (response3.IsSuccessStatusCode)
                    {
                        var jsonObject = response.Content.ReadAsStringAsync();
                        Upiti upit = JsonConvert.DeserializeObject<Upiti>(jsonObject.Result);

                        foreach (var x in Global.izabraneKompanijeID)
                        {
                            KompanijeUpiti ku = new KompanijeUpiti();
                            ku.UpitID = upit.UpitID;
                            ku.Odgovoreno = false;
                            ku.KompanijaID = x;
                            response2 = kompanijeUpitiService.PostResponse(ku);
                        }

                        if (response2 != null)
                        {
                            if (response2.IsSuccessStatusCode)
                            {
                                DisplayAlert("", "Upit je uspjesno poslan", "OK");

                                //reset izbora
                                Global.izabraneKompanijeID = new List<int>();
                                Global.izabraneKompanije = new List<string>();
                                Global.izabraniGradIndex = -1;
                                Global.izabranaKategorijaIndex = -1;

                                this.Navigation.PopAsync();

                                //this.Navigation.PushAsync(new MainPage());
                            }
                            else
                            {
                                DisplayAlert("Greska!", "Doslo je do greske u komunikaciji", "OK");
                            }
                        }
                        else
                        {
                            DisplayAlert("Greska!", "Doslo je do greske u komunikaciji", "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Greska!", "Doslo je do greske u komunikaciji", "OK");
                    }
                }
            }
            else
            {
                porukaLbl.TextColor = Color.Red;
                porukaLbl.FontAttributes = FontAttributes.Bold;
            }
        }

        public static byte[] StreamToBytes(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private void dodajSlikuBtn_Clicked(object sender, EventArgs e)
        {
          

        }

        private bool validacija()
        {
            if (!(opisKvaraTxt.Text != null))
            {
                return false;
            }
            if ((markaUredjajaPicker.SelectedItem as MarkeUredjaja) == null)
            {
                return false;
            }
            if ((modelUredjajaPicker.SelectedItem as ModeliUredjaja) == null)
            {
                return false;
            }
            return true;
        }

    }
}
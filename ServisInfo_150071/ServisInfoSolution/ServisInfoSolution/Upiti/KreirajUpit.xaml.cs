﻿using Newtonsoft.Json;
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
        private WebAPIHelper upitiService = new WebAPIHelper("http://localhost:64158/", "api/Upiti");
        private WebAPIHelper kompanijeUpitiService = new WebAPIHelper("http://localhost:64158/", "api/Kompanijeupiti");



        private Stream s;

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


            //otvaranje galerije -->> xam.plugin.media nuget 
            dodajSlikuBtn.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("x", "upload slika nije podrzan", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                    return;

                slika.Source = ImageSource.FromStream(() => file.GetStream());
                s = file.GetStream();

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

                if (slika != null)
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
                    HttpResponseMessage response2 = response;

                    HttpResponseMessage response3 = upitiService.GetActionResponse("GetZadnjiUpit", "");
                    if (response3.IsSuccessStatusCode)
                    {
                        var jsonObject = response.Content.ReadAsStringAsync();
                        Upiti upit = JsonConvert.DeserializeObject<Upiti>(jsonObject.Result);

                        KompanijeUpiti ku = new KompanijeUpiti();
                        ku.UpitID = upit.UpitID;
                        ku.Odgovoreno = false;

                        foreach (var x in Global.izabraneKompanijeID)
                        {
                            ku.KompanijaID = x;
                            response2 = kompanijeUpitiService.PostResponse(ku);
                        }

                        if (response2.IsSuccessStatusCode)
                        {
                            DisplayAlert("", "Upit je uspjesno poslan", "OK");
                        }
                        else
                        {
                            DisplayAlert("Greska!", "Doslo je do greske u komunikaciji", "OK");
                        }
                    }
                }


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


            return true;

        }
    }
}
using Newtonsoft.Json;
using ServisInfo_PCL.Model;
using ServisInfo_PCL.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServisInfoSolution
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetaljiUpita : ContentPage
    {

        private WebAPIHelper upitiService = new WebAPIHelper(Global.APIAdress, "api/Upiti");
        private WebAPIHelper kompanijeUpitiService = new WebAPIHelper(Global.APIAdress, "api/KompanijeUpiti");
        private WebAPIHelper ponudeService = new WebAPIHelper(Global.APIAdress, "api/Ponude");

        bool zatvori;

        private int upitID;
        public DetaljiUpita(int upitID)
        {
            this.upitID = upitID;
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            zatvori = true;
            Fill();
        }

        private void Fill()
        {
            HttpResponseMessage response = upitiService.GetActionResponse("GetDetalji", upitID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                DetaljiUpita_Result upit = JsonConvert.DeserializeObject<DetaljiUpita_Result>(jsonObject.Result);

                upitIDLbl.Text = "Detalji o upitu ID: " + upit.UpitID.ToString();
                DatumLbl.Text = upit.Datum_upita.ToString();
                zeljeniOdLbl.Text = upit.ZeljeniDatumPrijemaOd.GetValueOrDefault().ToString("dd.MM.yyyy");
                zeljeniDoLbl.Text = upit.ZeljeniDatumPrijemaDo.GetValueOrDefault().ToString("dd.MM.yyyy");
                markaLBl.Text = upit.Marka_uredjaja;
                modelLbl.Text = upit.Model_uredjaja;
                KategorijaLbl.Text = upit.Naziv_kategorije;
                OpisLbl.Text = upit.Opis_kvara;

                HttpResponseMessage response2 = upitiService.GetActionResponse("GetKompanijeByUpitId", upitID.ToString());
                if (response2.IsSuccessStatusCode)
                {
                    var jsonObject2 = response2.Content.ReadAsStringAsync();
                    List<KompanijeUpitResult> kompanije = JsonConvert.DeserializeObject<List<KompanijeUpitResult>>(jsonObject2.Result);

                    string kompanijeString = "";
                    for (int x = 0; x < kompanije.Count() - 1; x++) {
                        kompanijeString += kompanije[x].Naziv + ",";
                    }
                    kompanijeString += kompanije[kompanije.Count() - 1].Naziv;

                    KompanijeListLbl.Text = kompanijeString;

                }



;                if (upit.Slika != null)
                {
                    Stream stream = new MemoryStream(upit.Slika);

                    slika.Source = ImageSource.FromStream(() => stream);
                }
                else
                {
                    slikaPct.IsVisible = false;
                    slika.IsVisible = false;
                }

            }
        }

        private async void IzbtisiBtn_Clicked(object sender, EventArgs e)
        {

            var answer = await DisplayAlert("Upozorenje", "Jeste li sigurni da zelite izbrisati upit?", "Da", "Ne");
            if (answer)
            {
                HttpResponseMessage provjera = ponudeService.GetActionResponse("provjeriOdgovor", upitID.ToString()); // da li je ijedna kompanija odgovorila na upit
                bool postoji = true;
                if (provjera.IsSuccessStatusCode)
                {
                    var jsonObject = provjera.Content.ReadAsStringAsync();
                    postoji = JsonConvert.DeserializeObject<bool>(jsonObject.Result);
                }


                if (!postoji)
                {
                    HttpResponseMessage response = kompanijeUpitiService.GetActionResponse("GetKU", upitID.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonObject = response.Content.ReadAsStringAsync();
                        List<KompanijeUpiti> ku = JsonConvert.DeserializeObject<List<KompanijeUpiti>>(jsonObject.Result);

                        foreach (var x in ku)
                        {
                            kompanijeUpitiService.DeleteResponse(x.KompanijaUpitID.ToString());
                        }

                        HttpResponseMessage response2 = upitiService.DeleteResponse(upitID.ToString());

                        if (response2.IsSuccessStatusCode)
                        {
                            DisplayAlert("", "Upit je uspjesno izbrisan", "OK");
                            this.Navigation.PopAsync();
                        }
                        else
                        {
                            DisplayAlert("Greska", "Doslo je do greske", "OK");
                        }

                    }
                }
                else
                {
                    DisplayAlert("Greska", "Upit nije moguce izbrisati jer je minimalno jedna kompanija kreirala upit", "OK");
                }

            }
        }


    }
}
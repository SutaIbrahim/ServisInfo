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
    public partial class DetaljiPonude : ContentPage
    {
        private WebAPIHelper ponudeService = new WebAPIHelper("http://localhost:64158/", "api/Ponude");
        private WebAPIHelper servisiService = new WebAPIHelper("http://localhost:64158/", "api/Servisi");


        private int ponudaID;
        private PonudaDetalji p;

        public DetaljiPonude(int ponudaID)
        {
            this.ponudaID = ponudaID;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Fill();
        }


        private void Fill()
        {
            HttpResponseMessage response = ponudeService.GetActionResponse("GetDetalji", ponudaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                PonudaDetalji ponuda = JsonConvert.DeserializeObject<PonudaDetalji>(jsonObject.Result);
                p = ponuda;

                ponudaIDLbl.Text = "Detalji o ponudi ID: " + ponuda.PonudaID.ToString();
                DatumLbl.Text = ponuda.DatumKreiranja.ToString();
                TrajanjeDaniLbl.Text = ponuda.TrajanjeDani.ToString();
                TrajanjeSatiLbl.Text = ponuda.TrajanjeSati.ToString();

                if (ponuda.Prihvacena == true)
                {
                    PrihvacenaLbl.Text = "DA";
                    prihvatiBtn.Opacity = 0;
                }
                else
                {
                    PrihvacenaLbl.Text = "NE";
                    prihvatiBtn.Opacity = 1;
                }

                KompanijaLbl.Text = ponuda.Naziv_kompanije;
                KategorijaLbl.Text = ponuda.Naziv;
                OdgovorLbl.Text = ponuda.Odgovor;
                CijenaLbl.Text = ponuda.Cijena.ToString();

            }


        }

        private void prihvatiBtn_Clicked(object sender, EventArgs e)
        {
            HttpResponseMessage response = ponudeService.GetResponse(ponudaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                Ponuda ponuda = JsonConvert.DeserializeObject<Ponuda>(jsonObject.Result);

                ponuda.Prihvacena = true;

                HttpResponseMessage response2 = ponudeService.PutResponse(ponudaID, ponuda);
                if (response2.IsSuccessStatusCode)
                {
                    Servisi servis = new Servisi();

                    servis.DatumPrihvatanja = DateTime.Now;
                    servis.KompanijaID = p.KompanijaID;
                    servis.PonudaID = ponudaID;

                    HttpResponseMessage response3 = servisiService.PostResponse(servis);
                    if (response3.IsSuccessStatusCode)
                    {
                        DisplayAlert("Uspjesno ste prihvatili ponudu", "Uredjaj mozete dostaviti prema dogovoru sa kompanijom", "OK");
                        Fill();
                    }

                }
            }
        }




    }
}
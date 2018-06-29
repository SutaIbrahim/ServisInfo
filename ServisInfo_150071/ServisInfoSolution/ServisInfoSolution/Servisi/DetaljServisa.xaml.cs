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
    public partial class DetaljServisa : ContentPage
    {
        private WebAPIHelper servisiService = new WebAPIHelper("http://localhost:64158/", "api/Servisi");
        private WebAPIHelper ocjeneService = new WebAPIHelper("http://localhost:64158/", "api/Ocjene");


        private int servisID;

        private ServisDetalji_Result ponuda;

        public DetaljServisa(int servisID)
        {
            this.servisID = servisID;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Fill();
        }

        private void Fill()
        {
            HttpResponseMessage response = servisiService.GetActionResponse("GetDetalji", servisID.ToString());
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                ServisDetalji_Result ponuda = JsonConvert.DeserializeObject<ServisDetalji_Result>(jsonObject.Result);
                this.ponuda = ponuda;

                DatumPrihvatanjaLbl.Text = ponuda.DatumPrihvatanja.ToString();
                servisIDLbl.Text = "Detalji o servisu ID: " + ponuda.ServisID.ToString();
                DatumPocetkaLBl.Text = ponuda.DatumPocetka.ToString();
                DatumZavrsetkaLbl.Text = ponuda.DatumZavršetka.ToString();
                TrajanjeLbl.Text = ponuda.TrajanjeDani.ToString();
                CijenaLbl.Text = ponuda.Završna_cijena.ToString();
                KompanijaLbl.Text = ponuda.Naziv_Kompanije;

                //ocjene layout
                if (ponuda.DatumPocetka == null)
                {
                    porukaLbl.Text = "Servis jos uvijek nije zapocet !";

                    BrzinaSlider.IsVisible = false;
                    KvalitetSlider.IsVisible = false;
                    KomunikacijaSlider.IsVisible = false;

                    BrzinaLbl.IsVisible = false;
                    KvalitetLbl.IsVisible = false;
                    KomunikacijaLbl.IsVisible = false;

                    ocjeniBtn.IsVisible = false;


                }
                else if (ponuda.Ocjenjen == true) // bool ocjenjen
                {
                    porukaLbl.Text = "Servis je uspjesno zavrsen i ocjenjen !";

                    BrzinaSlider.IsVisible = false;
                    KvalitetSlider.IsVisible = false;
                    KomunikacijaSlider.IsVisible = false;

                    BrzinaLbl.IsVisible = false;
                    KvalitetLbl.IsVisible = false;
                    KomunikacijaLbl.IsVisible = false;

                    ocjeniBtn.IsVisible = false;


                }
                else if (ponuda.DatumZavršetka == null)
                {
                    porukaLbl.Text = "Servis je u toku !";

                    BrzinaSlider.IsVisible = false;
                    KvalitetSlider.IsVisible = false;
                    KomunikacijaSlider.IsVisible = false;

                    BrzinaLbl.IsVisible = false;
                    KvalitetLbl.IsVisible = false;
                    KomunikacijaLbl.IsVisible = false;
                    ocjeniBtn.IsVisible = false;

                }
                else
                {
                    porukaLbl.Text = "Servis je zavrsen, molimo vas da ocijenite uslugu";

                    BrzinaSlider.IsVisible = true;
                    KvalitetSlider.IsVisible = true;
                    KomunikacijaSlider.IsVisible = true;

                    BrzinaLbl.IsVisible = true;
                    KvalitetLbl.IsVisible = true;
                    KomunikacijaLbl.IsVisible = true;

                    ocjeniBtn.IsVisible = true;

                }
            }


        }

        private void ocjeniBtn_Clicked(object sender, EventArgs e)
        {

            Ocjene o = new Ocjene();
            o.Datum = DateTime.Now;
            o.KlijentID = ponuda.KlijentID;
            o.ServisID = servisID;


            //3 ocjene

            o.Ocjena = Convert.ToDecimal(BrzinaSlider.Value);
            o.VrstaOcjeneID = 1;
            ocjeneService.PostResponse(o);

            o.Ocjena = Convert.ToDecimal(KvalitetSlider.Value);
            o.VrstaOcjeneID = 2;
            ocjeneService.PostResponse(o);

            o.Ocjena = Convert.ToDecimal(KomunikacijaSlider.Value);
            o.VrstaOcjeneID = 3;
            HttpResponseMessage response = ocjeneService.PostResponse(o);


            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Uspjesno ste ocijenili ovaj servis", "", "OK");
            }

            Fill();
        }


    }
}
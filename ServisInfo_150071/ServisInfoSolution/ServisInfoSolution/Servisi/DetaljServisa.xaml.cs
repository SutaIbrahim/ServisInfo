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

        private int servisID;

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

                DatumPrihvatanjaLbl.Text = ponuda.DatumPrihvatanja.ToString();
                servisIDLbl.Text = "Detalji o servisu ID: " + ponuda.ServisID.ToString();
                DatumPocetkaLBl.Text = ponuda.DatumPocetka.ToString();
                DatumZavrsetkaLbl.Text = ponuda.DatumZavršetka.ToString();
                TrajanjeLbl.Text = ponuda.TrajanjeDani.ToString();
                CijenaLbl.Text = ponuda.Završna_cijena.ToString();
                KompanijaLbl.Text = ponuda.Naziv_Kompanije;

                if (ponuda.DatumZavršetka == null)
                {
                    porukaLbl.Text = "Servis je jos uvijek u toku";
                    BrzinaSlider.IsVisible = false;
                    KvalitetSlider.IsVisible = false;
                    KomunikacijaSlider.IsVisible = false;
                    
                }
                else
                {
                    porukaLbl.Text = "Servis je zavrsen, molimo vas da ocijenite uslugu";

                    BrzinaSlider.IsVisible = true;
                    KvalitetSlider.IsVisible = true;
                    KomunikacijaSlider.IsVisible = true;
                }

            }


        }

        private void ocjeniBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
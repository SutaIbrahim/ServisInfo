﻿using Newtonsoft.Json;
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
        private WebAPIHelper servisiService = new WebAPIHelper(Global.APIAdress, "api/Servisi");
        private WebAPIHelper ocjeneService = new WebAPIHelper(Global.APIAdress, "api/Ocjene");


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
                ServisDetalji_Result servis = JsonConvert.DeserializeObject<ServisDetalji_Result>(jsonObject.Result);
                this.ponuda = servis;

                DatumPrihvatanjaLbl.Text = servis.DatumPrihvatanja.ToString("dd.MM.yyyy");
                servisIDLbl.Text = "Detalji o servisu ID: " + servis.ServisID.ToString();
                DatumPocetkaLBl.Text = servis.DatumPocetka.GetValueOrDefault().ToString("dd.MM.yyyy");
                DatumZavrsetkaLbl.Text = servis.DatumZavršetka.GetValueOrDefault().ToString("dd.MM.yyyy");
                TrajanjeLbl.Text = servis.TrajanjeDani.ToString();
                CijenaLbl.Text = servis.Završna_cijena.ToString() + " KM";
                KompanijaLbl.Text = servis.Naziv_Kompanije;
                KategorijaLbl.Text = servis.Kategorija;
                UredjajLbl.Text = servis.Uredjaj;

                //ocjene layout
                if (servis.DatumPocetka == null)
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
                else if (servis.Ocjenjen == true) // bool ocjenjen
                {
                    porukaLbl.Text = "Servis je uspjesno zavrsen i ocjenjen !";

                    BrzinaSlider.IsVisible = true;
                    KvalitetSlider.IsVisible = true;
                    KomunikacijaSlider.IsVisible = true;

                    BrzinaLbl.IsVisible = true;
                    KvalitetLbl.IsVisible = true;
                    KomunikacijaLbl.IsVisible = true;

                    ocjeniBtn.IsVisible = false;

                    PreuzmiOcjene(); /////////

                }
                else if (servis.DatumZavršetka == null)
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

                    BrzinaSlider.IsEnabled = true;
                    KvalitetSlider.IsEnabled = true;
                    KomunikacijaSlider.IsEnabled = true;

                }
            }


        }

        private void PreuzmiOcjene()
        {
            HttpResponseMessage response = ocjeneService.GetActionResponse("GetOcjeneList", servisID.ToString());


            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Ocjene> ocjene = JsonConvert.DeserializeObject<List<Ocjene>>(jsonObject.Result);

                foreach (var x in ocjene)
                {
                    if (x.VrstaOcjeneID == 1)
                    {
                        BrzinaSlider.Value = Convert.ToDouble(x.Ocjena);
                        BrzinaSlider.IsEnabled = false;
                    }
                    else if (x.VrstaOcjeneID == 2)
                    {
                        KvalitetSlider.Value = Convert.ToDouble(x.Ocjena);
                        KvalitetSlider.IsEnabled = false;
                    }
                    else if (x.VrstaOcjeneID == 3)
                    {
                        KomunikacijaSlider.Value = Convert.ToDouble(x.Ocjena);
                        KomunikacijaSlider.IsEnabled = false;
                    }

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
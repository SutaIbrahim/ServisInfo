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

namespace ServisInfoSolution.Kompanija
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetaljiKompanije : ContentPage
    {
        private WebAPIHelper kompanijeService = new WebAPIHelper(Global.APIAdress, "api/Kompanije");
        private WebAPIHelper ocjeneService = new WebAPIHelper(Global.APIAdress, "api/Ocjene");

        private int kompanijaID;
        private KompanijeDetalji_Result k;

        public DetaljiKompanije(int kompanijaID)
        {
            this.kompanijaID = kompanijaID;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            HttpResponseMessage response = kompanijeService.GetActionResponse("GetDetalji", kompanijaID.ToString());
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                KompanijeDetalji_Result kompanija = JsonConvert.DeserializeObject<KompanijeDetalji_Result>(jsonObject.Result);
                k = kompanija;

                kompanijaLbl.Text = kompanija.Naziv;
                adresaLbl.Text = kompanija.Adresa;
                GradLbl.Text = kompanija.Grad;
                emailLbl.Text = kompanija.Email;
                TelefonLbl.Text = kompanija.Telefon;

                IzracunajProsjecneOcjene();
            }
        }

        private void IzracunajProsjecneOcjene()
        {
            HttpResponseMessage response = ocjeneService.GetActionResponse("GetOcjeneKompanije", kompanijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<OcjeneKompanije_Result> ocjene = JsonConvert.DeserializeObject<List<OcjeneKompanije_Result>>(jsonObject.Result);


                if (ocjene.Count != 0)
                {
                    BrzinaSlider.IsVisible = true;
                    KvalitetSlider.IsVisible = true;
                    KomunikacijaSlider.IsVisible = true;

                    decimal suma = 0;
                    int brojac = 0;

                    //brzina
                    foreach (var x in ocjene)
                    {
                        if (x.VrstaOcjeneID == 1)
                        {
                            brojac++;
                            suma += x.Ocjena;
                        }
                    }
                    decimal prosjek = Math.Round(suma / brojac, 2);
                    BrzinaSlider.Value = Convert.ToInt32(prosjek);
                    BrzinaLbl.Text = "Brzina usluge (" + prosjek.ToString() + ")";

                    //kvalitet
                    suma = 0;
                    brojac = 0;
                    foreach (var x in ocjene)
                    {
                        if (x.VrstaOcjeneID == 2)
                        {
                            brojac++;
                            suma += x.Ocjena;
                        }
                    }
                    prosjek = Math.Round(suma / brojac, 2);
                    KvalitetSlider.Value = Convert.ToInt32(prosjek);
                    KvalitetLbl.Text = "Kvalitet usluge (" + prosjek.ToString() + ")";

                    //komunikacija
                    suma = 0;
                    brojac = 0;
                    foreach (var x in ocjene)
                    {
                        if (x.VrstaOcjeneID == 3)
                        {
                            brojac++;
                            suma += x.Ocjena;
                        }
                    }
                    prosjek = Math.Round(suma / brojac, 2);
                    KomunikacijaSlider.Value = Convert.ToInt32(prosjek);
                    KomunikacijaLbl.Text = "Komunikacija (" + prosjek.ToString() + ")";
                }
                else
                {
                    BrzinaLbl.Text = "Kompanija jos uvijek nema ocjena";
                    KvalitetLbl.Text = "";
                    KomunikacijaLbl.Text = "";

                    BrzinaSlider.IsVisible = false;
                    KvalitetSlider.IsVisible = false;
                    KomunikacijaSlider.IsVisible = false;
                }
            }
        }

    }
}
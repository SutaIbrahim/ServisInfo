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

                setButton();
                IzracunajProsjecneOcjene();

            }


            //recommender

            HttpResponseMessage response2 = kompanijeService.GetActionResponse("PreporuceneKompanije", kompanijaID.ToString(), Global.izabranaKategorija.KategorijaID.ToString());

            if (response2.IsSuccessStatusCode)
            {
                var jsonObject = response2.Content.ReadAsStringAsync();
                List<KompanijeDetalji_Result> preporuceneKompanije = JsonConvert.DeserializeObject<List<KompanijeDetalji_Result>>(jsonObject.Result);

                kompanijeList.ItemsSource = preporuceneKompanije;

            }


        }

        private void IzracunajProsjecneOcjene()
        {
            HttpResponseMessage response = ocjeneService.GetActionResponse("GetOcjeneKompanije", kompanijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Ocjene> ocjene = JsonConvert.DeserializeObject<List<Ocjene>>(jsonObject.Result);


                if (ocjene.Count() != 0)
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            bool postoji = false;

            foreach (var x in Global.izabraneKompanijeID)
            {
                if (x == kompanijaID)
                {
                    postoji = true;
                }
            }

            if (postoji)
            {
                Global.izabraneKompanijeID.Remove(kompanijaID);
                Global.izabraneKompanije.Remove(k.Naziv);
                setButton();

            }
            else
            {
                Global.izabraneKompanijeID.Add(kompanijaID);
                Global.izabraneKompanije.Add(k.Naziv);
                setButton();
            }
        }


        private void setButton()
        {
            bool postoji = false;

            foreach (var x in Global.izabraneKompanijeID)
            {
                if (x == kompanijaID)
                {
                    postoji = true;
                }
            }

            if (postoji)
            {
                Button.BackgroundColor = Color.Red;
                Button.Text = "Ukloni";
            }
            else
            {
                Button.BackgroundColor = Color.Green;
                Button.Text = "Dodaj";
            }
        }

        private void kompanijeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.Navigation.PushAsync(new DetaljiKompanije((e.Item as KompanijeDetalji_Result).KompanijaID));
        }
    }
}
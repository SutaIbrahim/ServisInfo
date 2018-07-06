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

namespace ServisInfoSolution.Klijent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UredjivanjeProfila : ContentPage
    {
        private WebAPIHelper klijentiService = new WebAPIHelper(Global.APIAdress, "api/Klijenti");
        private WebAPIHelper gradoviService = new WebAPIHelper(Global.APIAdress, "api/Gradovi");

        private Klijenti k;
        private Gradovi g;

        public UredjivanjeProfila()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Fill();

            base.OnAppearing();
        }

        private void Fill()
        {
            HttpResponseMessage response = gradoviService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Gradovi> vrste = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Gradovi>>(jsonObject.Result);

                gradList.ItemsSource = vrste;
                gradList.ItemDisplayBinding = new Binding("Naziv");
            }



            k = Global.prijavljeniKlijent;

            HttpResponseMessage response2 = gradoviService.GetResponse(k.GradID.ToString());

            if (response2.IsSuccessStatusCode)
            {
                var jsonObject = response2.Content.ReadAsStringAsync();
                g = Newtonsoft.Json.JsonConvert.DeserializeObject<Gradovi>(jsonObject.Result);
            }
            
            imeInput.Text = k.Ime;
            prezimeInput.Text = k.Prezime;
            adresaInput.Text = k.Adresa;
            telefonInput.Text = k.Telefon;
            emailInput.Text = k.Email;

            // gradList.SelectedItem = (g as Gradovi);
            korisnickoImeInput.Text = k.KorisickoIme;
        }

        private void Sacuvaj_Clicked(object sender, EventArgs e)
        {
            if (Validacija())
            {
                k.Ime = imeInput.Text;
                k.Prezime = prezimeInput.Text;
                k.Adresa = adresaInput.Text;
                k.Telefon = telefonInput.Text;
                k.Email = emailInput.Text;
                k.KorisickoIme = korisnickoImeInput.Text;
                k.GradID = (gradList.SelectedItem as Gradovi).GradID;

                if (lozinkaInput.Text != String.Empty)
                {
                    k.LozinkaSalt = UIHelper.GenerateSalt();
                    k.LozinkaHash = UIHelper.GenerateHash(k.LozinkaSalt, lozinkaInput.Text);
                }

                HttpResponseMessage response3 = klijentiService.PutResponse(k.KlijentID, k);

                if (response3.IsSuccessStatusCode)
                {
                    DisplayAlert("", "Uspjesno ste uredili profil", "OK");
                    this.Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Greska", "Doslo je do greske", "OK");
                }
                
                Fill();

            }
            else
            {
                porukaLbl.TextColor = Color.Red;
            }

        }

        private bool Validacija()
        {
            if (!(imeInput.Text != null))
            {
                return false;
            }
            else if (!(prezimeInput.Text != null))
            {
                return false;
            }
            else if (!(telefonInput.Text != null))
            {
                return false;
            }
            else if (!(emailInput.Text != null))
            {
                return false;
            }
            else if (!(korisnickoImeInput != null))
            {
                return false;
            }
            else if (gradList.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

    }
}
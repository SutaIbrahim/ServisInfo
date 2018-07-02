using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ServisInfo_PCL.Util;
using ServisInfo_PCL.Model;
using System.Net.Http;


namespace ServisInfoSolution
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registracija : ContentPage
    {

        private WebAPIHelper klijentiService = new WebAPIHelper(Global.APIAdress, "api/Klijenti");
        private WebAPIHelper gradoviService = new WebAPIHelper(Global.APIAdress, "api/Gradovi");


        public Registracija()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            HttpResponseMessage response = gradoviService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Gradovi> vrste = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Gradovi>>(jsonObject.Result);

                gradList.ItemsSource = vrste;
                gradList.ItemDisplayBinding = new Binding("Naziv");

                gradList.SelectedIndex = 1;
            }
           

            base.OnAppearing();
        }

        private void registrujSeButton_Clicked(object sender, EventArgs e)
        {
            if (Validacija())
            {
                Klijenti klijent = new Klijenti();
                klijent.Ime = imeInput.Text;
                klijent.Prezime = prezimeInput.Text;
                klijent.Email = emailInput.Text;
                klijent.KorisickoIme = korisnickoImeInput.Text;
                klijent.Telefon = telefonInput.Text;
                klijent.Adresa = adresaInput.Text;

                int gradID = (gradList.SelectedItem as Gradovi).GradID;
                klijent.GradID = gradID;

                klijent.LozinkaSalt = UIHelper.GenerateSalt();
                klijent.LozinkaHash = UIHelper.GenerateHash(klijent.LozinkaSalt, lozinkaInput.Text);

                HttpResponseMessage response = klijentiService.PostResponse(klijent);
                if (response.IsSuccessStatusCode)
                {
                    DisplayAlert("Uspjesna registracija", "Uspjesno ste se registrovali", "OK");
                    this.Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Greska", "Korisnicko ime vec postoji", "Ok");
                }
            }
            else
            {
                porukaLbl.TextColor = Color.Red;
                porukaLbl.FontAttributes = FontAttributes.Bold;
            }
        }

        private bool Validacija()
        {
            if (!(imeInput.Text!=null))
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
            else if (!(lozinkaInput.Text != null))
            {
                return false;
            }
            return true;
        }
    }

}
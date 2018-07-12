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
    public partial class Prijava : ContentPage
    {

        private WebAPIHelper klijentiService = new WebAPIHelper(Global.APIAdress, "api/Klijenti");
        public Prijava()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
        
            Global.prijavljeniKlijent = null;

            if (Global.prvoPokretanje == true) // dodano jer pri prvim pokretanjem pojavi se sidebar
            {
                this.Navigation.PushAsync(new MainPage());
            }

            NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            HttpResponseMessage response = klijentiService.GetActionResponse("GetByUsername", korisnickoImeInput.Text);

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                Klijenti klijent = JsonConvert.DeserializeObject<Klijenti>(jsonObject.Result);

                if (klijent.LozinkaHash == UIHelper.GenerateHash
                    (klijent.LozinkaSalt, lozinkaInput.Text))
                {
                    Global.prijavljeniKlijent = klijent;


                    //var page = (Page)Activator.CreateInstance(typeof(MainPage));
                    //page.Title = "ge";
                    //MasterDetailPage m = new MasterDetailPage();
                    //m.Detail = new NavigationPage(page);
                    //m.IsPresented = true;


                  this.Navigation.PushAsync(new MainPage());

                }
                else
                {
                    DisplayAlert("Greska!", "Pogresni korisnicki podaci", "OK");
                    lozinkaInput.Text = "";
                    korisnickoImeInput.Text = "";
                }
            }
            else
            {
                DisplayAlert("Greska!", "Korisnicko ime ne postoji", "OK");
                lozinkaInput.Text = "";
                korisnickoImeInput.Text = "";
            }

        }

        private void registerButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Registracija());
        }
    }
}
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

        private WebAPIHelper klijentiService = new WebAPIHelper("http://localhost:64158/", "api/Klijenti");

        public Prijava()
        {
            InitializeComponent();
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
                    this.Navigation.PushAsync(new MainPage());
                }
            }

        }

        private void registerButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Registracija());
        }
    }
}
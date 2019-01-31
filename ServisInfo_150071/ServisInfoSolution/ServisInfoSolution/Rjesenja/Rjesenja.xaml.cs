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

namespace ServisInfoSolution.Rjesenja
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Rjesenja : ContentPage
	{
        private WebAPIHelper kategorijeService = new WebAPIHelper(Global.APIAdress, "api/Kategorije");
        public Rjesenja ()
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            Fill();
        }

        public void Fill()
        {
   
            HttpResponseMessage response = kategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Kategorije> kategorije = JsonConvert.DeserializeObject<List<Kategorije>>(jsonObject.Result);
                kategorijePicker.ItemsSource = kategorije;

                kategorijePicker.ItemDisplayBinding = new Binding("Naziv");

            }

        }

        private void kategorijePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((kategorijePicker.SelectedItem as Kategorije) != null)
            {
               


            }
        }

        private void pronadjiBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
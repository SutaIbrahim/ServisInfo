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

        int kId = 0;
        public Rjesenja ()
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            Fill();
        }

        public void Fill()
        {
            hideAll();
       

            HttpResponseMessage response = kategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Kategorije> kategorije = JsonConvert.DeserializeObject<List<Kategorije>>(jsonObject.Result);
                kategorijePicker.ItemsSource = kategorije;

                kategorijePicker.ItemDisplayBinding = new Binding("Naziv");

            }

        }

        private void hideAll()
        {
            prvi.IsVisible = false;
            drugi.IsVisible = false;
            treci.IsVisible = false;
            cetvrti.IsVisible = false;
            peti.IsVisible = false;
            editor.IsVisible = false;

            prviTxt.IsVisible = false;
            drugiTxt.IsVisible = false;
            treciTxt.IsVisible = false;
            cetvrtiTxt.IsVisible = false;
            petiTxt.IsVisible = false;

            pronadjiBtn.IsVisible = false;

            editor.IsVisible = false;
            moguca.IsVisible = false;

            link.IsVisible = false;

            izaberiteLbl.IsVisible = true;
        }

        private void kategorijePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideAll();

            Kategorije k = (kategorijePicker.SelectedItem as Kategorije);

            if (k!= null)
            {
                kId = k.KategorijaID;

                izaberiteLbl.IsVisible = false;

                pronadjiBtn.IsVisible = true;

             
                if (k.KategorijaID == 2)
                {
                    pronadjiBtn.IsVisible = true;
                    editor.IsVisible = true;

                    prvi.IsVisible = true;
                    prviTxt.IsVisible = true;
                    prviTxt.Text = "Uređaj se gasi i kada je baterija preko 10 %";

                    drugi.IsVisible = true;
                    drugiTxt.IsVisible = true;
                    drugiTxt.Text = "Baterija se lagano \"napuhala\"";

                    treci.IsVisible = true;
                    treciTxt.IsVisible = true;
                    treciTxt.Text = "Postoje nagli padovi u postotcima napunjenosti baterije (npr. pad sa 50 na 20% za jednu minutu)";

                    cetvrti.IsVisible = true;
                    cetvrtiTxt.IsVisible = true;
                    cetvrtiTxt.Text = "Baterija se sporo puni";

                    peti.IsVisible = true;
                    petiTxt.IsVisible = true;
                    petiTxt.Text = "Ne reaguje na punjenje";
                }


            }
            else
            {
                kId = 0;
            }
            
        }

        private void pronadjiBtn_Clicked(object sender, EventArgs e)
        {
            if (kId > 0)
            {
                editor.IsVisible = true;
                moguca.IsVisible = true;

                if (kId == 2)
                {
                    if(peti.IsToggled || drugi.IsToggled)
                    {
                        editor.Text = " - Nažalost bateriju je potrebno zamijeniti";
                    }
                    else if(prvi.IsToggled || cetvrti.IsToggled || treci.IsToggled)
                    {

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) => {
                            Device.OpenUri(new Uri("https://balkanandroid.com/kako-kalibrirati-podesiti-bateriju-na-vasem-androidu"));
                        };

                        editor.Text = " - Bateriju je potrebno kalibrirati (ispraznite bateriju na 0% te je napunite do kraja)";

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = " - Kliknite ovde u slučaju neuspjeha za napredniju kalibraciju";
                    }



                }





            }
        }
    }
}
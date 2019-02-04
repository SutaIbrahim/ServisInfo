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
        public Rjesenja()
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
            nemaLbl.IsVisible = false;

            izaberiteLbl.IsVisible = true;
        }

        private void kategorijePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideAll();

            Kategorije k = (kategorijePicker.SelectedItem as Kategorije);

            if (k != null)
            {
                kId = k.KategorijaID;

                izaberiteLbl.IsVisible = false;

                pronadjiBtn.IsVisible = true;

                if (k.KategorijaID == 2) //baterija
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
                else if (k.KategorijaID == 10) //punjenje
                {

                    pronadjiBtn.IsVisible = true;
                    editor.IsVisible = true;

                    prvi.IsVisible = true;
                    prviTxt.IsVisible = true;
                    prviTxt.Text = "Uređaj ne reaguje na punjač";

                    drugi.IsVisible = true;
                    drugiTxt.IsVisible = true;
                    drugiTxt.Text = "Konektor punjenja je klimav";

                    treci.IsVisible = true;
                    treciTxt.IsVisible = true;
                    treciTxt.Text = "Uređaj se puni ali vrlo sporo ";

                    cetvrti.IsVisible = true;
                    cetvrtiTxt.IsVisible = true;
                    cetvrtiTxt.Text = "Punjenje se prekida";

                    peti.IsVisible = true;
                    petiTxt.IsVisible = true;
                    petiTxt.Text = "Uređaj prepoznaje punjač ali ne puni mobitel";

                }
                else if (k.KategorijaID == 11) //displey
                {

                    pronadjiBtn.IsVisible = true;
                    editor.IsVisible = true;

                    prvi.IsVisible = true;
                    prviTxt.IsVisible = true;
                    prviTxt.Text = "Ekran uopšte ne daje sliku";

                    drugi.IsVisible = true;
                    drugiTxt.IsVisible = true;
                    drugiTxt.Text = "Bijela svjetlost bez slike";

                    treci.IsVisible = true;
                    treciTxt.IsVisible = true;
                    treciTxt.Text = "Linije raznih boja po ekranu ";

                    cetvrti.IsVisible = true;
                    cetvrtiTxt.IsVisible = true;
                    cetvrtiTxt.Text = "Samo dio slike se prikazuje";

                    peti.IsVisible = true;
                    petiTxt.IsVisible = true;
                    petiTxt.Text = "Slika se prikazuje ali touch ne radi";

                }
                else if (k.KategorijaID == 13) //boot loop
                {

                    pronadjiBtn.IsVisible = true;
                    editor.IsVisible = true;

                    prvi.IsVisible = true;
                    prviTxt.IsVisible = true;
                    prviTxt.Text = "Uređaj se u kontiniutetu resetuje";

                    drugi.IsVisible = true;
                    drugiTxt.IsVisible = true;
                    drugiTxt.Text = "Uređaj se ugasi tokom rada";

                    treci.IsVisible = true;
                    treciTxt.IsVisible = true;
                    treciTxt.Text = "Uređaj se vrlo dugo pali ";

                }
                else
                {
                    nemaLbl.IsVisible = true;
                    pronadjiBtn.IsVisible = false;
                }



            }
            else
            {
                kId = 0;
                izaberiteLbl.IsVisible = true;
            }

        }

        private void pronadjiBtn_Clicked(object sender, EventArgs e)
        {
            if (kId > 0)
            {
                editor.IsVisible = true;
                moguca.IsVisible = true;

                if (kId == 2) //baterija
                {
                    if (drugi.IsToggled)
                    {
                        editor.Text = "- Nažalost bateriju je potrebno zamijeniti";
                    }
                    else if (peti.IsToggled && drugi.IsToggled)
                    {
                        editor.Text = "- Nažalost bateriju je potrebno zamijeniti";
                    }
                    else if (cetvrti.IsToggled && peti.IsToggled)
                    {
                        editor.Text = "- Moguć problem u konektoru punjenja, pokušaje očistiti prašinu\n" +
                            "- Provjerite adapter za punjenje, uvjerite se u njegovu ispravtnost \n" +
                            "- Provjerite USB kabal\n" +
                            "- Bateriju je potrebno kalibrirati (ispraznite bateriju na 0% te je napunite do kraja, u tom procesu uređaj nemojte koristiti)";

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://balkanandroid.com/kako-kalibrirati-podesiti-bateriju-na-vasem-androidu"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Kliknite ovde u slučaju neuspjeha za napredniju kalibraciju";
                    }
                    else if (prvi.IsToggled || cetvrti.IsToggled || treci.IsToggled)
                    {

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://balkanandroid.com/kako-kalibrirati-podesiti-bateriju-na-vasem-androidu"));
                        };

                        editor.Text = "- Bateriju je potrebno kalibrirati (ispraznite bateriju na 0% te je napunite do kraja, u tom procesu uređaj nemojte koristiti)";

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Kliknite ovde u slučaju neuspjeha za napredniju kalibraciju";
                    }



                }
                else if (kId == 10) //punjenje
                {
                    if (drugi.IsToggled)
                    {
                        editor.Text = "- Konektor je potrebno zamijenuti, javite se nekom od naših servisa";
                    }
                   else if (prvi.IsToggled)
                    {
                        editor.Text = "- Pokušaje očistiti prašinu\n" +
                            "- Provjerite adapter za punjenje, uvjerite se u njegovu ispravtnost \n" +
                            "- Provjerite USB kabal";

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://www.youtube.com/watch?v=POfGKKxFoas"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Kliknite ovde za video upustvo čiščenja konektora punjenja";
                    }
                    else
                    if (treci.IsToggled)
                    {
                        editor.Text = "- Pokušaje očistiti prašinu\n" +
                            "- Provjerite adapter za punjenje, uvjerite se u njegovu ispravtnost \n" +
                            "- Provjerite USB kabal\n" +
                            "- Provjerite stanje baterije";

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://www.youtube.com/watch?v=POfGKKxFoas"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Kliknite ovde za video upustvo čiščenja konektora punjenja";
                    }else
                    if (cetvrti.IsToggled)
                    {
                        editor.Text = "- Pokušaje očistiti prašinu\n" +
                            "- Provjerite adapter za punjenje, uvjerite se u njegovu ispravtnost \n" +
                            "- Provjerite USB kabal";

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://www.youtube.com/watch?v=POfGKKxFoas"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Kliknite ovde za video upustvo čiščenja konektora punjenja";
                    }else
                    if (peti.IsToggled)
                    {
                        editor.Text = "- Pokušaje očistiti prašinu\n" +
                            "- Provjerite adapter za punjenje, uvjerite se u njegovu ispravtnost \n" +
                             "- Provjerite USB kabal\n" +
                            "- Provjerite stanje baterije";

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://www.youtube.com/watch?v=POfGKKxFoas"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Kliknite ovde za video upustvo čiščenja konektora punjenja";
                    }



                }

                else if (kId == 11) //displey
                {
                    if (drugi.IsToggled)
                    {
                        editor.Text = "- Potrebno je zamijeniti flat kabal ili cijeli displey, javite se nekom od naših servisa";
                    }
                    else if (prvi.IsToggled)
                    {
                        editor.Text = "- Provjerite ispravnost i napunjenost baterije\n" +
                            "- Provjerite ispravnost uređaja, da li se uopšte uključuje\n";

                    }
                    else
                     if (treci.IsToggled)
                    {
                        editor.Text = "- Potrebno je zamijeniti flat kabal ili cijeli displey, javite se nekom od naših servisa";

                    }
                    else
                    if (cetvrti.IsToggled)
                    {
                        editor.Text = "- Potrebno je zamijeniti flat kabal ili cijeli displey, javite se nekom od naših servisa";

                    }
                    else
                    if (peti.IsToggled)
                    {
                        editor.Text = "- Potrebno je zamijeniti flat kabal toucha ili cijeli displey, javite se nekom od naših servisa";
                    }

                }

                else if (kId == 13) //displey
                {

                    if (treci.IsToggled)
                    {
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://www.hardreset.info/"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Potrebno je da uradite hard reset mobilnog uređaja, upustva možete pronaći klikom na ovaj link";

                        editor.Text = "- Provjerite ispravnost i stanje baterije\n" +
                            "- Provjerite stanje sa memorijom, oslobodite prostor ukoliko je memorija puna";
                    }
                    else if (drugi.IsToggled)
                    {
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://www.hardreset.info/"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Potrebno je da uradite hard reset mobilnog uređaja, upustva možete pronaći klikom na ovaj link";

                        editor.Text = "- Provjerite ispravnost i stanje baterije";


                    }
                    else if (prvi.IsToggled)
                    {
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, ea) =>
                        {
                            Device.OpenUri(new Uri("https://www.hardreset.info/"));
                        };

                        link.IsVisible = true;
                        link.GestureRecognizers.Add(tapGestureRecognizer);
                        link.Text = "- Potrebno je da uradite hard reset mobilnog uređaja, upustva možete pronaći klikom na ovaj link";

                        editor.Text = "- Izvadite bateriju iz uređaja 10 min te onda pokušajte upaliti";

                    }

                }



            }
        }
    }
}
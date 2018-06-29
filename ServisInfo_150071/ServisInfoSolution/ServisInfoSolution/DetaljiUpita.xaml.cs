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
	public partial class DetaljiUpita : ContentPage
	{

        private WebAPIHelper upitiService = new WebAPIHelper("http://localhost:64158/", "api/Upiti");

        private int upitID;
		public DetaljiUpita (int upitID)
		{
            this.upitID = upitID;
			InitializeComponent ();
		}


        protected override void OnAppearing()
        {
            Fill();
        }


        private void Fill()
        {
            HttpResponseMessage response = upitiService.GetActionResponse("GetDetalji", upitID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                DetaljiUpita_Result upit = JsonConvert.DeserializeObject<DetaljiUpita_Result>(jsonObject.Result);

                DatumLbl.Text = upit.Datum_upita.ToString();
                zeljeniOdLbl.Text = upit.ZeljeniDatumPrijemaOd.ToString();
                zeljeniDoLbl.Text = upit.ZeljeniDatumPrijemaDo.ToString();
                markaLBl.Text = upit.Marka_uredjaja;
                modelLbl.Text = upit.Model_uredjaja;
                KategorijaLbl.Text = upit.Naziv_kategorije;
                OpisLbl.Text = upit.Opis_kvara;
            }


        }

    }
}
using ServisInfo_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ServisInfo_API.Models;
using System.Net.Http;
using System.Resources;
using System.Configuration;
using System.IO;

namespace ServisInfo_UI.Upiti
{
    public partial class DetaljiUpita : Form
    {

        private WebAPIHelper UpitiService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.UpitiRoute);


        private DetaljiUpita_Result u { get; set; }
        private int UID { get; set; }

        public DetaljiUpita(int upitID)
        {
            UID = upitID;
            InitializeComponent();

            HttpResponseMessage response = UpitiService.GetActionResponse("GetDetalji", upitID.ToString(),Global.prijavljenaKompanija.KompanijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    u = null;
                else if (response.IsSuccessStatusCode)
                {
                    u = response.Content.ReadAsAsync<DetaljiUpita_Result>().Result;
                    FillForm();
                }
            }
        }


        private void FillForm()
        {
            DatumLbl.Text = u.Datum_upita.ToString();
            MarkaLbl.Text = u.Marka_uredjaja;
            ModelLbl.Text = u.Model_uredjaja;
            OdLbl.Text = u.ZeljeniDatumPrijemaOd.ToString();
            DoLbl.Text = u.ZeljeniDatumPrijemaDo.ToString();
            KlijentLbl.Text = u.NazivKlijenta;
            OpisTxt.Text = u.Opis_kvara;
            UpitIDLbl.Text = UID.ToString();
            KategorijaLbl.Text = u.Naziv_kategorije;

            UcitajSliku();


            if (u.Odgovoreno == true)
            {
                KreirajPonuduBtn.Hide();
                DaLbl.Text = "DA";
                NeLbl.Hide();
            }
            else
            {
                PregledajPonuduBtn.Hide();
                DaLbl.Hide();
                NeLbl.Text = "NE";
            }

        }

        private void UcitajSliku()
        {

            if (u.Slika != null)
            {
                Image orgImg = (Bitmap)((new ImageConverter()).ConvertFrom(u.Slika));

                //Bitmap orgImg = GetImageFromByteArray(u.Slika);

                int resizedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgWidth"]);
                int resizedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgHeight"]);
                int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
                int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

                pictureBox.Image = orgImg;

                if (orgImg.Width > resizedImgWidth)
                {
                    Image resizedImg = UIHelper.ResizeImage(orgImg, new Size(resizedImgWidth, resizedImgHeight));

                    if (resizedImg.Width > croppedImgWidth && resizedImg.Height > croppedImgHeight)
                    {
                        int croppedXPosition = (resizedImg.Width - croppedImgWidth) / 2;
                        int croppedYPosition = (resizedImg.Height - croppedImgHeight) / 2;

                        Image croppedImg = UIHelper.CropImage(resizedImg, new Rectangle(croppedXPosition, croppedYPosition, croppedImgWidth, croppedImgHeight));

                        ////From Image to byte[]
                        //MemoryStream ms = new MemoryStream();
                        //croppedImg.Save(ms, orgImg.RawFormat);

                        pictureBox.Image = resizedImg;
                    }
                    else
                    {
                        MessageBox.Show(Messages.picture_war + " " + resizedImgWidth + "x" + resizedImgHeight + ".", Messages.warning,
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }

        }
        ////private static readonly ImageConverter _imageConverter = new ImageConverter();
        //public static Bitmap GetImageFromByteArray(byte[] byteArray)
        //{
        //    Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

        //    if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
        //                       bm.VerticalResolution != (int)bm.VerticalResolution))
        //    {
        //        // Correct a strange glitch that has been observed in the test program when converting 
        //        //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
        //        //  slightly away from the nominal integer value
        //        bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
        //                         (int)(bm.VerticalResolution + 0.5f));
        //    }

        //    return bm;
        //}



        private void KreirajPonuduBtn_Click(object sender, EventArgs e)
        {
            Ponude.KreirajPonudu frm = new Ponude.KreirajPonudu(UID, u.KlijentID, Convert.ToInt32(u.KompanijaUpitID), OdLbl.Text, DoLbl.Text, u.Opis_kvara, ".");
            frm.ShowDialog();
            this.Close();
        }

        private void NazadBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PregledajPonuduBtn_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = UpitiService.GetActionResponse("GetPonudaID", Global.prijavljenaKompanija.KompanijaID.ToString(), UID.ToString());

            if (response.IsSuccessStatusCode)
            {
                Ponude.DetaljiPonude frm = new Ponude.DetaljiPonude(response.Content.ReadAsAsync<int>().Result);
                frm.ShowDialog();
            }
        }

        private void KategorijaLbl_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_UI.Util
{
    public class UIHelper
    {
        #region Prijedlog kvara
        public static List<string> EventualniKvar(List<ServisInfo_API.Models.Ponude> p, string text)
        {
            var returnText = new List<string>();

            #region Predefined 
            if (text.Contains("bater"))
            {
                returnText.Add("Problem sa baterijom - Potrebno zamijeniti bateriju ukoliko je stara preko 2 godine ili je fizički oštećena");
            }
            if (text.Contains("ekr") || text.Contains("disp"))
            {
                returnText.Add("Problem sa ekranom - Provjerite konektore");
            }
            if (text.Contains("punjenj") || text.Contains("punit"))
            {
                returnText.Add("Problem sa micro USB konektorom ili kabelom za punjenje");
            }
            if (text.Contains("USB"))
            {
                returnText.Add("Zamijeniti USB kabal ili USB konektor");
            }
            #endregion

            if (returnText.Count() < 3)
            {
                foreach (var x in p.Take(3))
                {
                    returnText.Add(x.Odgovor.Replace("Postovani,", ""));
                }
            }



            return returnText;
        }
        #endregion

        #region Korisnici
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        #endregion

        #region Slike

        public static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        #endregion
    }
}

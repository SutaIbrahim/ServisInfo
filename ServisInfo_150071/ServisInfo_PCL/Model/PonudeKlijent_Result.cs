using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
   public class PonudeKlijent_Result // ponudeResult
    {
        public int PonudaID { get; set; }
        public int KategorijaID { get; set; }
        public int KompanijaID { get; set; }
        public int UpitID { get; set; }
        public string NazivServisa { get; set; }
        public string NazivKategorije { get; set; }
        public string Cijena { get; set; }
        public decimal TrajanjeDani { get; set; }
        public decimal TrajanjeSati { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
    public class KompanijeDetalji_Result
    {
        public int KompanijaID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Grad { get; set; }
    }
}

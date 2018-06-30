using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
   public class OcjeneKompanije_Result
    {
        public int OcjenaID { get; set; }
        public decimal Ocjena { get; set; }
        public int VrstaOcjeneID { get; set; }
        public System.DateTime Datum { get; set; }
        public int KlijentID { get; set; }
        public int ServisID { get; set; }
    }
}

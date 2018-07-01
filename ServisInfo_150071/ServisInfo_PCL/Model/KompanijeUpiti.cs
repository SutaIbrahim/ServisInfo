using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_PCL.Model
{
    public class KompanijeUpiti
    {
        public int KompanijaUpitID { get; set; }
        public int KompanijaID { get; set; }
        public int UpitID { get; set; }
        public bool Odgovoreno { get; set; }
    }
}

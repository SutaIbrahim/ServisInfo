using ServisInfo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfo_UI
{
    public static class Global
    {
        public static Kompanije prijavljenaKompanija { get; set; }

        #region API Routes 

        public const string KompanijeRoute = "api/Kompanije";
        public const string UpitiRoute = "api/Upiti";
        public const string GradoviRoute = "api/Gradovi";
        public const string PonudeRoute = "api/Ponude";
        public const string KlijentiRoute = "api/Klijenti";
        public const string KompanijeUpitiRoute = "api/KompanijeUpiti";
        public const string ServisiRoute = "api/Servisi";
        public const string KategorijeRoute = "api/Kategorije";
        public const string OcjeneRoute = "api/Ocjene";











        #endregion
    }
}

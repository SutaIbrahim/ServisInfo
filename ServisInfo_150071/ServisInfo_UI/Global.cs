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





        #endregion
    }
}

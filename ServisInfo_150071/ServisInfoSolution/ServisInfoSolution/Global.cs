using ServisInfo_PCL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisInfoSolution
{
    public class Global
    {

        public static string APIAdress { get; set; } // setovanje unutar App.xaml.cs


        //

        public static Klijenti prijavljeniKlijent { get; set; }

        public static List<int> izabraneKompanijeID { get; set; }

        public static List<string>  izabraneKompanije { get; set; }

        public static Kategorije izabranaKategorija { get; set; }

        public static bool prvoPokretanje { get; set; }
        public static int izabraniGradIndex { get; set; }
        public static int izabranaKategorijaIndex { get; set; }


    }
}

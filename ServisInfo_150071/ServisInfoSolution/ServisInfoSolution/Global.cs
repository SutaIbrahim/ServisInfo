﻿using ServisInfo_PCL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisInfoSolution
{
    public class Global
    {
        public static Klijenti prijavljeniKlijent { get; set; }

        public static List<int> izabraneKompanijeID { get; set; }

        public static List<string>  izabraneKompanije { get; set; }

        public static Kategorije izabranaKategorija { get; set; }



    }
}
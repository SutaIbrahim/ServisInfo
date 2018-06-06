using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServisInfo_API.Models
{
    public partial class Kompanije
    {
        public List<Kategorije> kategorije { get; set; }
    }
}
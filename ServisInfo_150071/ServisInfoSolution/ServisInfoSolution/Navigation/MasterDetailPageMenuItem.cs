using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisInfoSolution.Navigation
{

    public class MasterDetailPageMenuItem
    {
        public MasterDetailPageMenuItem()
        {
            TargetType = typeof(Prijava);
        }
        public string ImageSource { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
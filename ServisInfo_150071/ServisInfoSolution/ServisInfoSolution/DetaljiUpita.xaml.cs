using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServisInfoSolution
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetaljiUpita : ContentPage
	{


        private int upitID;
		public DetaljiUpita (int upitID)
		{
            this.upitID = upitID;
			InitializeComponent ();
		}
	}
}
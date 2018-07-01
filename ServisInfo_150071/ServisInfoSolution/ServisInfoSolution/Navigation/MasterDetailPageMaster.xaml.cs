using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServisInfoSolution.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

            public MasterDetailPageMasterViewModel()
            {

                MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
                {
                    new MasterDetailPageMenuItem { Title = " Pretraga kompanija", ImageSource="pretraga.png", TargetType=typeof(MainPage)},
                    new MasterDetailPageMenuItem { Title = " Upiti", ImageSource="upiti.png", TargetType=typeof(PregledUpita)},
                    new MasterDetailPageMenuItem { Title = " Ponude", ImageSource="ponude.png", TargetType=typeof(PregledPonuda)},
                    new MasterDetailPageMenuItem { Title = " Servisi", ImageSource="servisi.png", TargetType=typeof(PregledServisa)},
                    new MasterDetailPageMenuItem { Title = " Odjava", ImageSource="odjava.png", TargetType=typeof(Prijava)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
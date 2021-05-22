using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Equipmensts : ContentPage
    {
        public Equipmensts()
        {
            InitializeComponent();
            BindingContext = new EquipmentVM(new DataService(), new DialogService(), new PageService());
        }
        private async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = await (BindingContext as EquipmentVM).GetEqipmentsSearch(e.NewTextValue);
        }
    }
}
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
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Locations : ContentPage
    {
        public Locations()
        {
            InitializeComponent();
            BindingContext = new LocationVM(new DataService(),new DialogService(),new PageService());
        }

        private async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = await (BindingContext as LocationVM).GetLocationsSearch(e.NewTextValue);
        }
    }
}
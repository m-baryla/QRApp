using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEmailPage : ContentPage
    {
        public NewEmailPage()
        {
            InitializeComponent();
            BindingContext = new AdressEmailVM(new DataService(),new DialogService());
        }
        private async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = await (BindingContext as AdressEmailVM).GetAdressesEmailsSearch(e.NewTextValue);
        }
    }
}
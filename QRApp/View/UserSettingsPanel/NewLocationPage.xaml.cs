using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewLocationPage : ContentPage
    {
        public NewLocationPage()
        {
            InitializeComponent();
            BindingContext = new NewLocationVM(new DataService(), new DialogService());

        }
    }
}
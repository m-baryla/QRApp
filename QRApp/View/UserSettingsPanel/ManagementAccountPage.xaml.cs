using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagementAccountPage : ContentPage
    {
        public ManagementAccountPage()
        {
            InitializeComponent();
            BindingContext = new ManagementAccountVM(new DataService());
        }
    }
}
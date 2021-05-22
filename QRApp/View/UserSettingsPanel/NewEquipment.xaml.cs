using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEquipment : ContentPage
    {
        public NewEquipment()
        {
            InitializeComponent();
            //BindingContext = new LocationVM(new DataService(),new DialogService());
        }
    }
}
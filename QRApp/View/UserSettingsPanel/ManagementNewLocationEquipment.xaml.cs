using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagementNewLocationEquipment : ContentPage
    {
        public ManagementNewLocationEquipment()
        {
            InitializeComponent();
            BindingContext = new ManagementNewLocationEquipmentVM(new DataService(),new DialogService());
        }
    }
}
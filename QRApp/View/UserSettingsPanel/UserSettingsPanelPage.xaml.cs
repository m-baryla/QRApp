using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserSettingsPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSettingsPanelPage : TabbedPage
    {
        public UserSettingsPanelPage()
        {
            BindingContext = new UserSettingsPanelVM(new PageService());
            InitializeComponent();
        }
    }
}
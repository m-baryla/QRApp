using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.AdminPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPanelPage : TabbedPage
    {
        public AdminPanelPage()
        {
            BindingContext = new AdminPanelVM(new PageService());
            InitializeComponent();
        }
    }
}
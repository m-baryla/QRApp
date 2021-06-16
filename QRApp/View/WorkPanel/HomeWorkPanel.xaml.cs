using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.WorkPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeWorkPanel : ContentPage
    {
        public HomeWorkPanel()
        {

            InitializeComponent();
            BindingContext = new HomeWorkPanelVM(new DataService(), new PageService());

        }
    }
}
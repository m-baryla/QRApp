using QRApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.WorkPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanServicePage : ContentPage
    {
        public ScanServicePage()
        {
            BindingContext = new ScanService(new DialogService(), new PageService());

            InitializeComponent();
        }
    }
}
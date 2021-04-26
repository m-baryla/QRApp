using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.MainPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModulesPage : ContentPage
    {
        public ModulesPage()
        {
            BindingContext = new ModulesPageVM(new PageService());
            InitializeComponent();
        }
    }
}
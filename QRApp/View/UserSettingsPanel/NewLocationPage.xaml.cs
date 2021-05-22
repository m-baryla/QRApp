using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
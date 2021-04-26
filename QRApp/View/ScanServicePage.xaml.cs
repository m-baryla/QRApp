using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanServicePage : ContentPage
    {
        public ScanServicePage()
        {
            BindingContext = new ScanService(new PageService(),new DialogService());

            InitializeComponent();
        }
    }
}
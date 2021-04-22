using QRApp.ViewModel;
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
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            BindingContext = new MasterPageVM(new PageService());
            InitializeComponent();
        }

    }
}
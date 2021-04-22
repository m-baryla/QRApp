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
    public partial class ModulesPage : ContentPage
    {
        public ModulesPage()
        {
            BindingContext = new ModulesPageVM(new PageService());
            InitializeComponent();
        }
    }
}
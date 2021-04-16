using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedPage : ContentPage
    {
        public SelectedPage()
        {
            BindingContext = new WorkPanelVM(new PageService());
            InitializeComponent();
        }
    }
}
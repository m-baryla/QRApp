using QRApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View
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
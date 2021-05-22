using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using QRApp.Service;
using QRApp.ViewModel;
using SkiaSharp;
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
            BindingContext = new HomeWorkPanelVM(new DataService(),new PageService());

            Breakdowns.Chart = new DonutChart { Entries = (BindingContext as HomeWorkPanelVM)._Breakdowns, HoleRadius = 0.5f };
            Repairs.Chart = new DonutChart { Entries = (BindingContext as HomeWorkPanelVM)._Repairs, HoleRadius = 0.5f };
            Maintenance.Chart = new DonutChart { Entries = (BindingContext as HomeWorkPanelVM)._Maintenance, HoleRadius = 0.5f };
            Inspection.Chart = new DonutChart { Entries = (BindingContext as HomeWorkPanelVM)._Breakdowns, HoleRadius = 0.5f };
            Cleaning.Chart = new DonutChart { Entries = (BindingContext as HomeWorkPanelVM)._Repairs, HoleRadius = 0.5f };
            All.Chart = new DonutChart { Entries = (BindingContext as HomeWorkPanelVM)._All, HoleRadius = 0.5f };

        }
    }
}
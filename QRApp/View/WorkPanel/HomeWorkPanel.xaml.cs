using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using Microsoft.Identity.Client;
using QRApp.Interface;
using QRApp.Model;
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
            BindingContext = new HomeWorkPanelVM(new DataService(), new PageService());

        }
    }
}
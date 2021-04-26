using QRApp.View;
using System;
using QRApp.View.MainPanel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MasterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

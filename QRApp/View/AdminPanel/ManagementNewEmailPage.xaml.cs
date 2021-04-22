using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using QRApp.Model;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.AdminPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagementNewEmailPage : ContentPage
    {
        public ManagementNewEmailPage()
        {
            InitializeComponent();
            BindingContext = new AdressEmailVM(new PageService());
        }
        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = (BindingContext as AdressEmailVM).ListOfEmailAdress(e.NewTextValue);
        }
        private async void RefreshView_OnRefreshing(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            RefreshView.IsRefreshing = false;
            //update
        }
    }
}
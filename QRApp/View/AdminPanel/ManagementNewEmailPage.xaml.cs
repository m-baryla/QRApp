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
            BindingContext = new AdressEmailVM(new DataService());
        }
        private async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = await (BindingContext as AdressEmailVM).GetAdressesEmailsSearch(e.NewTextValue);
        }

    }
}
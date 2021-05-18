using Microsoft.Identity.Client;
using QRApp.Model;
using QRApp.Service;
using QRApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.MainPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            BindingContext = new MasterPageVM(new PageService());
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

                if (accounts.Count() >= 1)
                {
                    AuthenticationResult result = await App.AuthenticationClient
                    .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();

                    await Navigation.PushAsync(new ModulesPage(result));
                }
            }
            catch
            {
            }
            base.OnAppearing();
        }
    }
}
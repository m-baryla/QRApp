using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;

namespace QRApp.View.MainPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModulesPage : ContentPage
    {
        public AuthenticationResult authenticatioResult;
        public ModulesPage(AuthenticationResult _authenticatioResult)
        {
            authenticatioResult = _authenticatioResult;

            BindingContext = new ModulesPageVM(new PageService());
            InitializeComponent();

            //var aaa = authenticatioResult.IdToken;

            Application.Current.Properties["userName"] = authenticatioResult.Account.Username;
            Application.Current.Properties["AccessToken"] = authenticatioResult.AccessToken;
            Application.Current.SavePropertiesAsync();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await App.AuthenticationClient.RemoveAsync(authenticatioResult.Account);
            await Navigation.PushAsync(new MasterPage());
        }
    }
}
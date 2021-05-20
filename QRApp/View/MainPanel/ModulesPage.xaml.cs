﻿using Microsoft.Identity.Client;
using QRApp.Service;
using QRApp.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.MainPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModulesPage : ContentPage
    {
        public AuthenticationResult authenticatioResult;
        public ModulesPage(AuthenticationResult _authenticatioResult)
        {
            authenticatioResult = _authenticatioResult;

            var userName = authenticatioResult.Account.Username;

            Application.Current.Properties["userName"] = userName;
            Application.Current.SavePropertiesAsync();

            BindingContext = new ModulesPageVM(new PageService());
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await App.AuthenticationClient.RemoveAsync(authenticatioResult.Account);
            await Navigation.PushAsync(new MasterPage());
        }
    }
}
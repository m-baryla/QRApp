using QRApp.View;
using System;
using QRApp.View.MainPanel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Identity.Client;
using QRApp.Model;

namespace QRApp
{
    public partial class App : Application
    {
        public static IPublicClientApplication AuthenticationClient { get; private set; }

        public static object UIParent { get; set; } = null;

        public App()
        {
            InitializeComponent();

            AuthenticationClient = PublicClientApplicationBuilder
                            .Create(Constants.ClientId)
                            .WithRedirectUri(Constants.RedirectUri)
                            .WithAuthority(AadAuthorityAudience.AzureAdMyOrg)
                            .WithTenantId(Constants.TenantId)
                            .WithIosKeychainSecurityGroup(Constants.IosKeychainSecurityGroups)
                            .Build();

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

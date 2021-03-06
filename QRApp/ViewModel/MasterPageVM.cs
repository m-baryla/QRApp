using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View.MainPanel;
using Xamarin.Forms;
using Microsoft.Identity.Client;

namespace QRApp.ViewModel
{
    public class MasterPageVM : BaseVM
    {
        public ICommand _Login { get; private set; }
        private readonly IPageService _pageService;

        public MasterPageVM(IPageService pageService)
        {
            _Login = new Command(async _ => await LoginUser());
            _pageService = pageService;
        }

        private async Task LoginUser()
        {
            try
            {
                var result = await App.AuthenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithPrompt(Prompt.ForceLogin)
                    .WithParentActivityOrWindow(App.UIParent)
                    .WithUseEmbeddedWebView(true)
                    .ExecuteAsync();

                await _pageService.PushAsync(new ModulesPage(result));
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}

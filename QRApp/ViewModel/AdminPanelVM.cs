using QRApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class AdminPanelVM
    {
        public ICommand _GoToHome { get; private set; }
        private readonly IPageService _pageService;

        public AdminPanelVM(IPageService pageService)
        {
            _GoToHome = new Command(_ => GoToHome());
            _pageService = pageService;
        }

        private async void GoToHome()
        {
            await _pageService.PushModalAsync(new ModulesPage());
        }
    }
}

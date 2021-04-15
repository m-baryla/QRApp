using QRApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class ModulesPageVM : BaseVM
    {
        public ICommand _GoToAdminPanel { get; private set; }
        private readonly IPageService _pageService;

        public ModulesPageVM(IPageService pageService)
        {
            _GoToAdminPanel = new Command(_ => GoToAdminPanel());
            _pageService = pageService;
        }

        private async void GoToAdminPanel()
        {
            await _pageService.PushModalAsync(new AdminPanelPage());
        }
    }
}

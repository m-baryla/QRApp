using QRApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.View.AdminPanel;
using QRApp.View.UserPanel;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class ModulesPageVM : BaseVM
    {
        public ICommand _GoToAdminPanel { get; private set; }
        public ICommand _GoToUserPanel { get; private set; }
        private readonly IPageService _pageService;

        public ModulesPageVM(IPageService pageService)
        {
            _GoToAdminPanel = new Command(_ => GoToAdminPanel());
            _GoToUserPanel = new Command(_ => GoToUserPanel());
            _pageService = pageService;
        }

        private async void GoToAdminPanel()
        {
            await _pageService.PushModalAsync(new AdminPanelPage());
        }
        private async void GoToUserPanel()
        {
            await _pageService.PushModalAsync(new SelectedPage());
        }
    }
}

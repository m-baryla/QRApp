using QRApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.View.UserSettingsPanel;
using QRApp.View.WorkPanel;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class ModulesPageVM : BaseVM
    {
        public ICommand _GoToUserSettingsPanel { get; private set; }
        public ICommand _GoToUserPanel { get; private set; }
        private readonly IPageService _pageService;

        public ModulesPageVM(IPageService pageService)
        {
            _GoToUserSettingsPanel = new Command(_ => GoToUserSettingsPanel());
            _GoToUserPanel = new Command(_ => GoToUserPanel());
            _pageService = pageService;
        }

        private async void GoToUserSettingsPanel()
        {
            await _pageService.PushModalAsync(new UserSettingsPanelPage());
        }
        private async void GoToUserPanel()
        {
            await _pageService.PushModalAsync(new WorkPanelPage());
        }
    }
}

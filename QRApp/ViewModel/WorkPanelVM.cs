using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.View;
using QRApp.View.UserPanel;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class WorkPanelVM : BaseVM
    {
        public ICommand _GoToAction { get; private set; }
        private readonly IPageService _pageService;

        public WorkPanelVM(IPageService pageService)
        {
            _GoToAction = new Command(_ => GoToAction());
            _pageService = pageService;
        }

        private async void GoToAction()
        {
            await _pageService.PushModalAsync(new WorkPanelPage());
        }
    }
}

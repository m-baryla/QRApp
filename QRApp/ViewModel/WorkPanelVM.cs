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
        private readonly IPageService _pageService;

        public WorkPanelVM(IPageService pageService)
        {
            _pageService = pageService;
        }
    }
}

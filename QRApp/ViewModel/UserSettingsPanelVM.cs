﻿using QRApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.View.MainPanel;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class UserSettingsPanelVM
    {
        public ICommand _GoToHome { get; private set; }
        private readonly IPageService _pageService;

        public UserSettingsPanelVM(IPageService pageService)
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

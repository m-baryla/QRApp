﻿using QRApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class MasterPageVM: BaseVM
    {
        public ICommand _LoginUser { get; private set; }
        private readonly IPageService _pageService;

        public MasterPageVM(IPageService pageService)
        {
            _LoginUser = new Command(_ => LoginUser());
            _pageService = pageService;
        }

        private async void LoginUser()
        {
           await _pageService.PushAsync(new ModulesPage());
        }
    }
}

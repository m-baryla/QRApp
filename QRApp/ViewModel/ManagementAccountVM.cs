﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    class ManagementAccountVM : BaseVM
    {
        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;

        private User _user;
        public User User { get => _user; set => SetValue(ref _user, value); }
        public ICommand _AddNewAccount { get; private set; }

        public ManagementAccountVM(IDataService dataService,IDialogService dialogService)
        {
            _AddNewAccount = new Command(async _ => await  AddNewAccount());

            _dataService = dataService;
            _dialogService = dialogService;
            _user = new User();
        }
        private async Task AddNewAccount()
        {
            _user.Password_1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_user.Password_1));
            _user.Password_2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_user.Password_2));

            if (await _dataService.PostNewAccount(_user))
            {
                await _dialogService.DisplayAlert("Info", "Add New Account successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Add New Account failed", "OK", "Cancel");
            }
        }
    }
}

using QRApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View.MainPanel;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class MasterPageVM : BaseVM
    {
        public ICommand _Login { get; private set; }
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        private User _user;
        public User User { get { return _user; } set { SetValue(ref _user, value); } }
        public string Login { get; set; }
        public string Password { get; set; }

        public MasterPageVM(IPageService pageService,IDataService dataService,IDialogService dialogService)
        {
            _Login = new Command(_ => LoginUser());
            _pageService = pageService;
            _dataService = dataService;
            _dialogService = dialogService;
            User = new User();
        }

        private async void LoginUser()
        {
            if (await _dataService.LoginAuth(User))
            {
                await _dialogService.DisplayAlert("Login info", "Login sucesfull", "OK","Cancel");
                await _pageService.PushModalAsync(new ModulesPage());
            }
            else
            {
                await _dialogService.DisplayAlert("Login info", "Login failed", "OK", "Cancel");
            }

        }
    }
}

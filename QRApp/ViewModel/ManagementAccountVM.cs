using System;
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

        private User _user;
        public User User { get { return _user; } set { SetValue(ref _user, value); } }
        public ICommand _AddNewAccount { get; private set; }

        public ManagementAccountVM(IDataService dataService)
        {
            _AddNewAccount = new Command(_ => AddNewAccount());

            _dataService = dataService;
            _user = new User();
        }
        private Task AddNewAccount()
        {
            _user.Password_1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_user.Password_1));
            _user.Password_2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_user.Password_2));
            return _dataService.PostNewAccount(_user);
        }
    }
}

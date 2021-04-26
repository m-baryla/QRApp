using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class AdressEmailVM : BaseVM
    {
        private ObservableCollection<EmailAdress> _emailAdressesList;
        public ObservableCollection<EmailAdress> EmailAdressesList {get { return _emailAdressesList; } set { SetValue(ref _emailAdressesList, value); } }

        private bool _isRefreshing;
        public bool IsRefreshing
        { get { return _isRefreshing; } set { SetValue(ref _isRefreshing, value); } }

        public ICommand _AddNewAdressEmail { get; private set; }
        public ICommand _RefereshAdressEmail { get; private set; }
        public ICommand _GetAdressesEmailsSearch { get; private set; }

        public readonly IDataService _dataService;

        public AdressEmailVM(IDataService dataService)
        {
            _AddNewAdressEmail = new Command(_ => AddNewAdressEmail());
            _RefereshAdressEmail = new Command(_ => GetAdressEmails());
            _GetAdressesEmailsSearch = new Command(_ => GetAdressesEmailsSearch());

            _dataService = dataService;

            GetAdressEmails();
        }

        private void AddNewAdressEmail()
        {
            _emailAdressesList.Add(new EmailAdress { Email = "aaaa@op.pl" });
        }

        private async Task GetAdressEmails()
        {
            IsRefreshing = true;
            EmailAdressesList =  _dataService.EmailAdressesList();
            IsRefreshing = false;
        }

        public IEnumerable<EmailAdress> GetAdressesEmailsSearch(string searchString = null)
        {
            _emailAdressesList = _dataService.EmailAdressesList();

            if (String.IsNullOrWhiteSpace(searchString))
                return _emailAdressesList;

            return _emailAdressesList.Where(c => c.Email.StartsWith(searchString));
        }

    }
}


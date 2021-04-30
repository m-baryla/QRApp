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
        private List<DictEmailAdress> _emailAdressesList;
        public List<DictEmailAdress> EmailAdressesList {get { return _emailAdressesList; } set { SetValue(ref _emailAdressesList, value); } }

        private bool _isRefreshing;
        public bool IsRefreshing
        { get { return _isRefreshing; } set { SetValue(ref _isRefreshing, value); } }

        public ICommand _AddNewAdressEmail { get; private set; }
        public ICommand _RefereshAdressEmail { get; private set; }

        public readonly IDataService _dataService;

        public AdressEmailVM(IDataService dataService)
        {
            _AddNewAdressEmail = new Command(_ => AddNewAdressEmail());
            _RefereshAdressEmail = new Command(async _ =>await GetAdressEmails());

            _dataService = dataService;

            GetAdressEmails();
        }

        private void AddNewAdressEmail()
        {
            _emailAdressesList.Add(new DictEmailAdress { EmailAdressNotify = "aaaa@op.pl" });
        }

        private async Task GetAdressEmails()
        {
            EmailAdressesList =  await _dataService.GetEmailAdressesList();
            IsRefreshing = false;
        }

        public async Task<IEnumerable<DictEmailAdress>> GetAdressesEmailsSearch(string searchString = null)
        {
            _emailAdressesList = await _dataService.GetEmailAdressesList();

            if (String.IsNullOrWhiteSpace(searchString))
                return _emailAdressesList;

            return _emailAdressesList.Where(c => c.EmailAdressNotify.StartsWith(searchString));
        }

    }
}


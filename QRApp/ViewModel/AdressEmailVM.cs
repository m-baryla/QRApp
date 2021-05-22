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
        public List<DictEmailAdress> EmailAdressesList {get => _emailAdressesList;
            set => SetValue(ref _emailAdressesList, value); }

        private DictEmailAdress _emailAdresses;
        public DictEmailAdress EmailAdresses { get => _emailAdresses;
            set => SetValue(ref _emailAdresses, value); }

        private bool _isRefreshing;
        public bool IsRefreshing { get => _isRefreshing;
            set => SetValue(ref _isRefreshing, value); }

        public ICommand _AddNewAdressEmail { get; private set; }
        public ICommand _RefereshAdressEmail { get; private set; }

        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;

        public AdressEmailVM(IDataService dataService, IDialogService dialogService)
        {
            _AddNewAdressEmail = new Command(async _ => await  AddNewAdressEmail());
            _RefereshAdressEmail = new Command(async _ =>await GetAdressEmails());

            _dialogService = dialogService;
            _dataService = dataService;
            _emailAdresses = new DictEmailAdress();

            _ = GetAdressEmails();
        }

        private async Task AddNewAdressEmail()
        {
            if (await _dataService.PostNewEmail(_emailAdresses))
            {
                await _dialogService.DisplayAlert("Info", "Add New AdressEmail successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Add New AdressEmail failed", "OK", "Cancel");
            }
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


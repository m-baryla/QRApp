using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    class NewLocationVM : BaseVM
    {
        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;
        public ICommand _AddNewLocation { get; private set; }

        private DictLocation _dictLocation = null;

        public DictLocation DictLocation
        {
            get => _dictLocation;
            set => SetValue(ref _dictLocation, value);
        }
        public NewLocationVM(IDataService dataService, IDialogService dialogService)
        {
            _AddNewLocation = new Command(async _ => await AddNewLocation());

            _dataService = dataService;
            _dialogService = dialogService;

            _dictLocation = new DictLocation();

        }

        private async Task AddNewLocation()
        {
            if (await _dataService.PostNewLocation(_dictLocation, new HttpClient()))
            {
                await _dialogService.DisplayAlert("Info", "Add New Location successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Add New Location failed", "OK", "Cancel");
            }
        }
    }
}

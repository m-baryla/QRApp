using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View.UserSettingsPanel;
using QRApp.View.WorkPanel;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    class LocationVM : BaseVM
    {
        private DictLocation _dictLocation = null;

        public DictLocation DictLocation
        {
            get { return _dictLocation; }
            set => SetValue(ref _dictLocation, value);
        }

        private List<DictLocation> _locationsList;

        public List<DictLocation> LocationsList
        {
            get { return _locationsList; }
            set => SetValue(ref _locationsList, value);
        }

        public ICommand _AddNewLocation { get; private set; }
        public ICommand _RefereshLocations { get; private set; }
        public ICommand _GoToNewLocationPage { get; private set; }

        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;
        private readonly IPageService _pageService;


        private bool _isRefreshing;
        public bool IsRefreshing { get { return _isRefreshing; } set => SetValue(ref _isRefreshing, value); }

        public LocationVM(IDataService dataService, IDialogService dialogService, IPageService pageService)
        {
            _AddNewLocation = new Command(async _ => await AddNewLocation());
            _RefereshLocations = new Command(async _ => await GetLocationsList());
            _GoToNewLocationPage = new Command(async _ => await GoToNewLocationPage());
            _dataService = dataService;
            _dialogService = dialogService;
            _pageService = pageService;
            _dictLocation = new DictLocation();

            _ = ListLocations();
            _ = GetLocationsList();
        }

        private async Task AddNewLocation()
        {
            if (await _dataService.PostNewLocation(_dictLocation))
            {
                await _dialogService.DisplayAlert("Info", "Add New Location successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Add New Location failed", "OK", "Cancel");
            }
        }
        private async Task GoToNewLocationPage()
        {

            await _pageService.PushModalAsync(new NewLocationPage());
        }
        private async Task ListLocations()
        {
            LocationsList = await _dataService.GetLocationsList();
        }
        private async Task GetLocationsList()
        {
            LocationsList = await _dataService.GetLocationsList();
            IsRefreshing = false;
        }
        public async Task<IEnumerable<DictLocation>> GetHistoryTicketsSearch(string searchString = null)
        {
            _locationsList = await _dataService.GetLocationsList();

            if (String.IsNullOrWhiteSpace(searchString))
                return _locationsList;

            return _locationsList.Where(c => c.LocationName.StartsWith(searchString) ||
                                                        c.Description.StartsWith(searchString));
        }
    }
}

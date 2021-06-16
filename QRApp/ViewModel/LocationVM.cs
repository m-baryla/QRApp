using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        
        private List<DictLocation> _locationsList;

        public List<DictLocation> LocationsList
        {
            get => _locationsList;
            set => SetValue(ref _locationsList, value);
        }

        public ICommand _RefereshLocations { get; private set; }
        public ICommand _GoToNewLocationPage { get; private set; }

        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;
        private readonly IPageService _pageService;


        private bool _isRefreshing;
        public bool IsRefreshing { get => _isRefreshing;
            set => SetValue(ref _isRefreshing, value); }

        public LocationVM(IDataService dataService, IDialogService dialogService, IPageService pageService)
        {
            _RefereshLocations = new Command(async _ => await GetLocationsList());
            _GoToNewLocationPage = new Command(async _ => await GoToNewLocationPage());

            _dataService = dataService;
            _dialogService = dialogService;
            _pageService = pageService;

            _ = GetLocationsList();
        }

        private async Task GoToNewLocationPage()
        {

            await _pageService.PushModalAsync(new NewLocationPage());
        }

        private async Task GetLocationsList()
        {
            //LocationsList = await _dataService.GetLocationsList(new HttpClient());
            LocationsList = await _dataService.GetAsync<DictLocation>(new HttpClient(), Constants.GetLocationsList);

            IsRefreshing = false;
        }
        public async Task<IEnumerable<DictLocation>> GetLocationsSearch(string searchString = null)
        {
            //_locationsList = await _dataService.GetLocationsList(new HttpClient());
            _locationsList = await _dataService.GetAsync<DictLocation>(new HttpClient(), Constants.GetLocationsList);


            if (String.IsNullOrWhiteSpace(searchString))
                return _locationsList;

            return _locationsList.Where(c => c.LocationName.StartsWith(searchString) ||
                                                        c.Description.StartsWith(searchString));
        }
    }
}

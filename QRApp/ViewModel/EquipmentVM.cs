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
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    class EquipmentVM : BaseVM
    {
        private List<DictEquipment> _euipmentsList;

        public List<DictEquipment> EquipmentsList
        {
            get => _euipmentsList;
            set => SetValue(ref _euipmentsList, value);
        }
        public ICommand _RefereshEquipments { get; private set; }
        public ICommand _GoToNewEquipmentsPage { get; private set; }

        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;
        private readonly IPageService _pageService;

        private bool _isRefreshing;
        public bool IsRefreshing { get => _isRefreshing;
            set => SetValue(ref _isRefreshing, value); }

        public EquipmentVM(IDataService dataService, IDialogService dialogService, IPageService pageService)
        {
            _RefereshEquipments = new Command(async _ => await GetEqipmentsList());
            _GoToNewEquipmentsPage = new Command(async _ => await GoToNewEquipmentsPage());

            _dataService = dataService;
            _dialogService = dialogService;
            _pageService = pageService;

            _ = GetEqipmentsList();
        }
        private async Task GoToNewEquipmentsPage()
        {

            await _pageService.PushModalAsync(new NewEquipment());
        }
       
        private async Task GetEqipmentsList()
        {
            //EquipmentsList = await _dataService.GetEquipmentList(new HttpClient());
            EquipmentsList = await _dataService.GetAsync<DictEquipment>(new HttpClient(), Constants.GetEquipmentList);

            IsRefreshing = false;
        }

        public async Task<IEnumerable<DictEquipment>> GetEqipmentsSearch(string searchString = null)
        {
            //_euipmentsList = await _dataService.GetEquipmentList(new HttpClient());
            _euipmentsList = await _dataService.GetAsync<DictEquipment>(new HttpClient(), Constants.GetEquipmentList);


            if (String.IsNullOrWhiteSpace(searchString))
                return _euipmentsList;

            return _euipmentsList.Where(c => c.EquipmentName.StartsWith(searchString) ||
                                             c.Description.StartsWith(searchString));
        }
    }
}

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
    class ManagementNewLocationEquipmentVM : BaseVM
    {
        private DictLocation _dictLocation = null;
        public DictLocation DictLocation { get { return _dictLocation; } set => SetValue(ref _dictLocation, value); }

        private DictEquipment _dictEquipments = null;
        public DictEquipment DictEquipments { get { return _dictEquipments; } set => SetValue(ref _dictEquipments, value); }
        
        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get { return _locations; } set => SetValue(ref _locations, value); }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set => SetValue(ref _euipments, value); }
        public ICommand _AddNewLocation { get; private set; }
        public ICommand _AddNewEquipment { get; private set; }

        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;


        public ManagementNewLocationEquipmentVM(IDataService dataService, IDialogService dialogService)
        {
            _AddNewLocation = new Command(async _ => await AddNewLocation());
            _AddNewEquipment = new Command(async _ => await AddNewEquipment());

            _dataService = dataService;
            _dialogService = dialogService;
            _dictLocation = new DictLocation();
            _dictEquipments = new DictEquipment();

            _ = ListLocations();
            _ = ListEquipment();
        }

        private async Task AddNewEquipment()
        {
            if (await _dataService.PostNewEquipment(_dictEquipments))
            {
                await _dialogService.DisplayAlert("Info", "Add New Equipment successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Add New Equipment failed", "OK", "Cancel");
            }
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

        private async Task ListLocations()
        {
            Locations = await _dataService.GetLocationsList();
        }

        private async Task ListEquipment()
        {
            Equipments = await _dataService.GetEquipmentList();
        }
    }
}

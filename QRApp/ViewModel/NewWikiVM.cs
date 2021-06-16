using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using QRApp.Interface;
using QRApp.Model;
using QRApp.Service;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;

namespace QRApp.ViewModel
{
    public class NewWikiVM : BaseVM
    {

        private Wiki _wikisDetails;
        public Wiki WikisDetails { get => _wikisDetails;
            set => SetValue(ref _wikisDetails, value); }

        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get => _locations;
            set => SetValue(ref _locations, value); }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get => _euipments;
            set => SetValue(ref _euipments, value); }

        private DictLocation _selecteDictLocation = null;
        public DictLocation SelecteDictLocation { get => _selecteDictLocation;
            set => SetValue(ref _selecteDictLocation, value); }

        private DictEquipment _selecteDictEquipments = null;
        public DictEquipment SelecteDictEquipments { get => _selecteDictEquipments;
            set => SetValue(ref _selecteDictEquipments, value); }

        private readonly ICameraService _cameraService;
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        public ICommand _CreatePhotoAsync { get; private set; }
        public byte[] PhotoBytes => _cameraService.PhotoBytes;

        public ICommand _SendNewWiki { get; private set; }

        private string _scanResul;
        public string ScanResul
        {
            get => _scanResul;
            set => SetValue(ref _scanResul, value);
        }

        private string _locationValue;
        public string LocationValue
        {
            get => _locationValue;
            set => SetValue(ref _locationValue, value);
        }

        private string _equipmentValue;

        public string EquipmentValue
        {
            get => _equipmentValue;
            set => SetValue(ref _equipmentValue, value);
        }

        private bool _isEnableLocation;
        public bool IsEnableLocation
        {
            get => _isEnableLocation;
            set => SetValue(ref _isEnableLocation, value);
        }

        private bool _isEnableEquippment;
        public bool IsEnableEquippment
        {
            get => _isEnableEquippment;
            set => SetValue(ref _isEnableEquippment, value);
        }

        private bool _isVisibleLocation;
        public bool IsVisibleLocation
        {
            get => _isVisibleLocation;
            set => SetValue(ref _isVisibleLocation, value);
        }

        private bool _isVisibleEquippment;
        public bool IsVisibleEquippment
        {
            get => _isVisibleEquippment;
            set => SetValue(ref _isVisibleEquippment, value);
        }

        public NewWikiVM(ICameraService cameraService, IDataService dataService, IDialogService dialogService, string resultScan)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SendNewWiki = new Command(async _ => await SendNewWiki());

            _cameraService = cameraService;
            _dialogService = dialogService;
            _dataService = dataService;

            _wikisDetails = new Wiki();

            _ = ListLocations();
            _ = ListEquipment();

            IsEnableLocation = true;
            IsVisibleLocation = true;
            IsEnableEquippment = true;
            IsVisibleEquippment = true;

            ScanResult(resultScan);

        }
        private void ScanResult(string resultScan)
        {

            var SplitResult = resultScan;

            if (SplitResult != "")
            {
                var tempSplit = SplitResult.Split(':');

                LocationValue = tempSplit[0];
                EquipmentValue = tempSplit[1];

                if (LocationValue != null)
                {
                    IsEnableLocation = false;
                    IsVisibleLocation = false;
                }
                else
                {
                    LocationValue = null;
                    IsEnableLocation = true;
                    IsVisibleLocation = true;
                }

                if (EquipmentValue != null)
                {
                    IsEnableEquippment = false;
                    IsVisibleEquippment = false;
                }
                else
                {
                    EquipmentValue = null;
                    IsEnableEquippment = true;
                    IsVisibleEquippment = true;
                }
            }

        }

        private async Task ListLocations()
        {
            Locations = await _dataService.GetLocationsList(new HttpClient());
        }

        private async Task ListEquipment()
        {
            Equipments = await _dataService.GetEquipmentList(new HttpClient());
        }
        private Task<ImageSource> CreatePhotoAsync()
        {
            return _cameraService.CreatePhotoAsync();
        }

        private async Task SendNewWiki()
        {
            if (LocationValue == null)
            {
                _wikisDetails.LocationName = SelecteDictLocation.LocationName;
            }
            else
            {
                _wikisDetails.LocationName = LocationValue;
            }

            if (EquipmentValue == null)
            {
                _wikisDetails.EquipmentName = SelecteDictEquipments.EquipmentName;
            }
            else
            {
                _wikisDetails.EquipmentName = EquipmentValue;
            }

            //_wikisDetails.LocationName = SelecteDictLocation.LocationName;
            //_wikisDetails.EquipmentName = SelecteDictEquipments.EquipmentName;
            _wikisDetails.Photo = _cameraService.PhotoBytes;

            if (await _dataService.PostNewWiki(_wikisDetails, new HttpClient()))
            {
                await _dialogService.DisplayAlert("Info", "Send New Wiki successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Send New Wiki failed", "OK", "Cancel");
            }
        }
    }
}

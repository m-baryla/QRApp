using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using QRApp.Service;
using QRApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace QRApp.ViewModel
{
    public class NewTicketVM : BaseVM
    {
        private DictEmailAdress _dictEmailAdressNotify;
        public DictEmailAdress DictEmailAdressNotify { get { return _dictEmailAdressNotify; } set => SetValue(ref _dictEmailAdressNotify, value); }

        private Ticket _ticketsDetails;
        public Ticket TicketsDetails { get { return _ticketsDetails; } set => SetValue(ref _ticketsDetails, value); }

        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get { return _locations; } set => SetValue(ref _locations, value); }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set => SetValue(ref _euipments, value); }

        private DictLocation _selecteDictLocation = null;
        public DictLocation SelecteDictLocation { get { return _selecteDictLocation; } set => SetValue(ref _selecteDictLocation, value); }

        private DictEquipment _selecteDictEquipments = null;
        public DictEquipment SelecteDictEquipments { get { return _selecteDictEquipments; } set => SetValue(ref _selecteDictEquipments, value); }

        private List<DictEmailAdress> _emailAdresses;
        public List<DictEmailAdress> EmailAdresses { get { return _emailAdresses; } set => SetValue(ref _emailAdresses, value); }
        
        private DictEmailAdress _selecteDictEmailAdress = null;
        public DictEmailAdress SelecteDictEmailAdress { get { return _selecteDictEmailAdress; } set => SetValue(ref _selecteDictEmailAdress, value); }

        private readonly ICameraService _cameraService;
        private readonly IPageService _pageService;
        private readonly IDialogService _dialogService;
        private readonly IDataService _dataService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ICommand _SendNewTicket { get; private set; }

        private string _scanResul;
        public string ScanResul { get { return _scanResul; } set => SetValue(ref _scanResul, value); }

        public byte[] PhotoBytes { get { return _cameraService.PhotoBytes; } }

        private string _locationValue;
        public string LocationValue { get { return _locationValue; } set => SetValue(ref _locationValue, value); }

        private string _equipmentValue;
        public string EquipmentValue { get { return _equipmentValue; } set => SetValue(ref _equipmentValue, value); }

        private bool _isEnableLocation;
        public bool IsEnableLocation { get { return _isEnableLocation; } set => SetValue(ref _isEnableLocation, value); }

        private bool _isEnableEquippment;
        public bool IsEnableEquippment { get { return _isEnableEquippment; } set => SetValue(ref _isEnableEquippment, value); }

         private bool _isVisibleLocation;
        public bool IsVisibleLocation { get { return _isVisibleLocation; } set => SetValue(ref _isVisibleLocation, value); }

        private bool _isVisibleEquippment;
        public bool IsVisibleEquippment { get { return _isVisibleEquippment; } set => SetValue(ref _isVisibleEquippment, value); }

        public NewTicketVM(IPageService pageService,ICameraService cameraService, IDataService dataService, IDialogService dialogService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SendNewTicket = new Command(async _=> await SendNewTicket());

            _cameraService = cameraService;
            _dataService = dataService;
            _dialogService = dialogService;
            _pageService = pageService;
            _ticketsDetails = new Ticket();
            SelecteDictEquipments = new DictEquipment();
            SelecteDictLocation = new DictLocation();
            _dictEmailAdressNotify = new DictEmailAdress();
            _ = ListLocations();
            _ = ListEquipment();
            _ = ListEmailAdress();
            IsEnableLocation = true;
            IsVisibleLocation = true;
            IsEnableEquippment = true;
            IsVisibleEquippment = true;

            MessagingCenter.Subscribe<ScanService, string>(this, "ResultScanSender", (sender, args) =>
            {
                ScanResul = args;

                var SplitResult = ScanResul.Split(':');

                LocationValue = SplitResult[0];
                EquipmentValue = SplitResult[1];

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

            });

        }

        private async Task ListLocations()
        {
            Locations = await _dataService.GetLocationsList();
        }

        private async Task ListEquipment()
        {
            Equipments = await _dataService.GetEquipmentList();
        }
        private async Task ListEmailAdress()
        {
            EmailAdresses = await _dataService.GetEmailAdressesList();
        }

        private Task<ImageSource> CreatePhotoAsync()
        {
            return _cameraService.CreatePhotoAsync();
        }

        private async Task SendNewTicket()
        {
            if (LocationValue == null)
            {
                _ticketsDetails.LocationName = SelecteDictLocation.LocationName;
            }
            else
            {
                _ticketsDetails.LocationName = LocationValue;
            }

            if (EquipmentValue == null)
            {
                _ticketsDetails.EquipmentName = SelecteDictEquipments.EquipmentName;
            }
            else
            {
                _ticketsDetails.EquipmentName = EquipmentValue;
            }


            _ticketsDetails.EmailAdress = SelecteDictEmailAdress.EmailAdressNotify;
            _ticketsDetails.Status = "Active";
            _ticketsDetails.UserName = "testlogin";
            _ticketsDetails.Photo = _cameraService.PhotoBytes;

            
            _dictEmailAdressNotify.EmailAdressNotify = SelecteDictEmailAdress.EmailAdressNotify;
            _dictEmailAdressNotify.Subject = _ticketsDetails.Topic;
            _dictEmailAdressNotify.Content_part1 = "LocationName: " + _ticketsDetails.LocationName;
            _dictEmailAdressNotify.Content_part2 = "EquipmentName: " + _ticketsDetails.EquipmentName;
            _dictEmailAdressNotify.Content_part3 = "Description: " + _ticketsDetails.Description;

            if (await _dataService.PostNewTicket(_ticketsDetails))
            {
                await _dialogService.DisplayAlert("Info", "Send New Ticket successful", "OK", "Cancel");

                if (await _dataService.PostEmailAdressNotify(_dictEmailAdressNotify))
                {
                    await _dialogService.DisplayAlert("Info", "Email Adress Notifyt successful", "OK", "Cancel");
                }
                else
                {
                    await _dialogService.DisplayAlert("Info", "Email Adress Notifyt failed", "OK", "Cancel");
                }
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Send New Ticket failed", "OK", "Cancel");
            }

        }
    }
}

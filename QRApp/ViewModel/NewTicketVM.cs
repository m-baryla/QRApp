using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using Xamarin.Forms;


namespace QRApp.ViewModel
{
    public class NewTicketVM : BaseVM
    {
        private DictEmailAdress _dictEmailAdressNotify;
        public DictEmailAdress DictEmailAdressNotify { get => _dictEmailAdressNotify; set => SetValue(ref _dictEmailAdressNotify, value); }

        private Ticket _ticketsDetails;
        public Ticket TicketsDetails { get => _ticketsDetails; set => SetValue(ref _ticketsDetails, value); }

        private List<DictPriority> _priority;
        public List<DictPriority> Priority { get => _priority; set => SetValue(ref _priority, value); }

        private List<DictTicketType> _ticketType;
        public List<DictTicketType> TicketType { get => _ticketType; set => SetValue(ref _ticketType, value); }

        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get => _locations; set => SetValue(ref _locations, value); }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get => _euipments; set => SetValue(ref _euipments, value); }

        private DictTicketType _selecteDictTicketType ;
        public DictTicketType SelecteDictTicketType { get => _selecteDictTicketType; set => SetValue(ref _selecteDictTicketType, value); }
        private DictPriority _selecteDictPriority;
        public DictPriority SelecteDictPriority { get => _selecteDictPriority; set => SetValue(ref _selecteDictPriority, value); }

        private DictLocation _selecteDictLocation ;
        public DictLocation SelecteDictLocation { get => _selecteDictLocation; set => SetValue(ref _selecteDictLocation, value); }

        private DictEquipment _selecteDictEquipments;
        public DictEquipment SelecteDictEquipments { get => _selecteDictEquipments; set => SetValue(ref _selecteDictEquipments, value); }

        private List<DictEmailAdress> _emailAdresses;
        public List<DictEmailAdress> EmailAdresses { get => _emailAdresses; set => SetValue(ref _emailAdresses, value); }
        
        private DictEmailAdress _selecteDictEmailAdress;
        public DictEmailAdress SelecteDictEmailAdress { get => _selecteDictEmailAdress; set => SetValue(ref _selecteDictEmailAdress, value); }


        private readonly ICameraService _cameraService;
        private readonly IDialogService _dialogService;
        private readonly IDataService _dataService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ICommand _SendNewTicket { get; private set; }

        public byte[] PhotoBytes => _cameraService.PhotoBytes;

        private string _locationValue;
        public string LocationValue { get => _locationValue; set => SetValue(ref _locationValue, value); }

        private string _equipmentValue;
        public string EquipmentValue { get => _equipmentValue; set => SetValue(ref _equipmentValue, value); }

        private bool _isEnableLocation;
        public bool IsEnableLocation { get => _isEnableLocation; set => SetValue(ref _isEnableLocation, value); }

        private bool _isEnableEquippment;
        public bool IsEnableEquippment { get => _isEnableEquippment; set => SetValue(ref _isEnableEquippment, value); }

         private bool _isVisibleLocation;
        public bool IsVisibleLocation { get => _isVisibleLocation; set => SetValue(ref _isVisibleLocation, value); }

        private bool _isVisibleEquippment;
        public bool IsVisibleEquippment { get => _isVisibleEquippment; set => SetValue(ref _isVisibleEquippment, value); }

        public NewTicketVM(ICameraService cameraService, IDataService dataService, IDialogService dialogService,string resultScan)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SendNewTicket = new Command(async _=> await SendNewTicket());

            _cameraService = cameraService;
            _dataService = dataService;
            _dialogService = dialogService;

            _ticketsDetails = new Ticket();
            SelecteDictEquipments = new DictEquipment();
            SelecteDictLocation = new DictLocation();
            SelecteDictPriority = new DictPriority();
            SelecteDictTicketType = new DictTicketType();
            _dictEmailAdressNotify = new DictEmailAdress();

            _ = ListLocations();
            _ = ListEquipment();
            _ = ListEmailAdress();
            _ = ListPrioritie();
            _ = ListTicketType();

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

        private async Task ListTicketType()
        {
            TicketType = await _dataService.GetDictTicketTypeList();
        }
        private async Task ListPrioritie()
        {
            Priority = await _dataService.GetDictPrioritieList();
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

            _ticketsDetails.UserName = Application.Current.Properties["userName"].ToString();

            _ticketsDetails.Photo = _cameraService.PhotoBytes;
            _ticketsDetails.Priority = SelecteDictPriority.PriorityType;
            _ticketsDetails.TicketType = SelecteDictTicketType.Type;
            
            _dictEmailAdressNotify.EmailAdressNotify = SelecteDictEmailAdress.EmailAdressNotify;
            _dictEmailAdressNotify.Subject = _ticketsDetails.Topic;
            _dictEmailAdressNotify.Content_part1 = "LocationName: " + _ticketsDetails.LocationName;
            _dictEmailAdressNotify.Content_part2 = "EquipmentName: " + _ticketsDetails.EquipmentName;
            _dictEmailAdressNotify.Content_part3 = "Description: " + _ticketsDetails.Description;
            _dictEmailAdressNotify.UserSender = "UserSender: " + _ticketsDetails.UserName;

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

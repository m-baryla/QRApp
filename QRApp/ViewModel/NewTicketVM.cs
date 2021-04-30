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
using QRApp.View.UserPanel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace QRApp.ViewModel
{
    public class NewTicketVM : BaseVM
    {

        private TicketsDetails _ticketsDetails;
        public TicketsDetails TicketsDetails { get { return _ticketsDetails; } set { SetValue(ref _ticketsDetails, value); } }

        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get { return _locations; } set { SetValue(ref _locations, value); } }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set { SetValue(ref _euipments, value); } }

        private DictLocation _selecteDictLocation = null;
        public DictLocation SelecteDictLocation { get{ return _selecteDictLocation; } set { SetValue(ref _selecteDictLocation, value); } }

        private DictEquipment _selecteDictEquipments = null;
        public DictEquipment SelecteDictEquipments { get { return _selecteDictEquipments; } set { SetValue(ref _selecteDictEquipments, value); } }

        //public string SelecteDictEquipments;
        //public string SelecteDictLocation;

        private readonly ICameraService _cameraService;
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ICommand _SelectFromList { get; private set; }
        public ICommand _SendNewTicket { get; private set; }

        public ImageSource PhotoSource { get { return _cameraService.PhotoSource; } }

        private string _scanResul;
        public string ScanResul
        { get { return _scanResul; } set { SetValue(ref _scanResul, value); } }

        public NewTicketVM(IPageService pageService,ICameraService cameraService, IDataService dataService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SelectFromList = new Command(_ => SelectFromList());
            _SendNewTicket = new Command(_ => SendNewTicket());

            _cameraService = cameraService;
            _dataService = dataService;
            _pageService = pageService;
            
            ListLocations();
            ListEquipment();

            _ticketsDetails = new TicketsDetails();

            //_ticketsDetails.Topic = "";
            //_ticketsDetails.Description = "";
            ////_ticketsDetails.LocationName = SelecteDictEquipments;
            ////_ticketsDetails.EquipmentName = SelecteDictLocation;
            //_ticketsDetails.EmailAdress = "test@op.pl";
            //_ticketsDetails.Status = "Status1";
            //_ticketsDetails.IsAnonymous = true;
            //_ticketsDetails.Photo = new byte[1];
            //_ticketsDetails.UserName = "testlogin";

            MessagingCenter.Subscribe<ScanService, string>(this, "ResultScanSender", (sender, args) =>
            {
                ScanResul = args;
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

        private Task<ImageSource> CreatePhotoAsync()
        {
            return _cameraService.CreatePhotoAsync();
        }
        private async void SelectFromList()
        {
            await _pageService.PushModalAsync(new WorkPanelPage());
        }

        private Task SendNewTicket()
        {
            _ticketsDetails.LocationName = SelecteDictLocation.LocationName;
            _ticketsDetails.EquipmentName = SelecteDictEquipments.EquipmentName;
            _ticketsDetails.EmailAdress = "test@op.pl";
            _ticketsDetails.Status = "Status1";
            _ticketsDetails.UserName = "testlogin";
            _ticketsDetails.Photo = new byte[1];


            if (_ticketsDetails.UserName == null)
                _ticketsDetails.IsAnonymous = true;
            else
                _ticketsDetails.IsAnonymous = false;

            return _dataService.PostNewTicket(_ticketsDetails);
        }
    }
}

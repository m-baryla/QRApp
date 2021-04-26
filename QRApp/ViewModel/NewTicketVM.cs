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
        public ObservableCollection<Location> Locations { get; set; } = new ObservableCollection<Location>();
        public ObservableCollection<Maschine> Maschines { get; set; } = new ObservableCollection<Maschine>();

        private readonly ICameraService _cameraService;
        private readonly IPageService _pageService;
        private readonly IScanService _scanService;
        private readonly IDataService _dataService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ICommand _SelectFromList { get; private set; }
        public ICommand _SelectFromQR { get; private set; }
        public ImageSource PhotoSource { get { return _cameraService.PhotoSource; } }

        private string _scanResult;
        public string ScanResul
        {
            get
            {
                return _scanResult;
            }
            set
            {
                SetValue(ref _scanResult, value);
            }
        }

        public NewTicketVM(IPageService pageService, IScanService scanService,ICameraService cameraService, IDataService dataService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SelectFromList = new Command(_ => SelectFromList());
            _SelectFromQR = new Command(_ => SelectFromQR());
            _cameraService = cameraService;
            _dataService = dataService;
            _pageService = pageService;
            _scanService = scanService;

            ListLocations();
            ListMaschines();
        }
        private IEnumerable<Location> ListLocations()
        {
            Locations = _dataService.ListLocations();
            return Locations;
        }
        private IEnumerable<Maschine> ListMaschines()
        {
            Maschines = _dataService.ListMaschines();
            return Maschines;
        }
        private Task<ImageSource> CreatePhotoAsync()
        {
            return _cameraService.CreatePhotoAsync();
        }
        private async void SelectFromList()
        {
            await _pageService.PushModalAsync(new WorkPanelPage());
        }

        private async void SelectFromQR()
        {
            //_scanService.ScanQR(new WorkPanelPage());
            await _pageService.PushModalAsync(new ScanServicePage());
            MessagingCenter.Subscribe<ScanService, string>(this, "ResultScanSender", (sender, args) =>
            { 
                _scanResult = args;
            });
        }

    }
}

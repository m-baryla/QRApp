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
        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get { return _locations; } set { SetValue(ref _locations, value); } }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set { SetValue(ref _euipments, value); } }

        private readonly ICameraService _cameraService;
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ICommand _SelectFromList { get; private set; }

        public ImageSource PhotoSource { get { return _cameraService.PhotoSource; } }

        private string _scanResul;
        public string ScanResul
        { get { return _scanResul; } set { SetValue(ref _scanResul, value); } }

        public NewTicketVM(IPageService pageService,ICameraService cameraService, IDataService dataService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SelectFromList = new Command(_ => SelectFromList());

            _cameraService = cameraService;
            _dataService = dataService;
            _pageService = pageService;
            
            ListLocations();
            ListEquipment();

            MessagingCenter.Subscribe<ScanService, string>(this, "ResultScanSender", (sender, args) =>
            {
                ScanResul = args;
            });
        }

        private async Task ListLocations()
        {
            Locations = await _dataService.LocationsList();
        }

        private async Task ListEquipment()
        {
            Equipments = await _dataService.EquipmentList();
        }


        private Task<ImageSource> CreatePhotoAsync()
        {
            return _cameraService.CreatePhotoAsync();
        }
        private async void SelectFromList()
        {
            await _pageService.PushModalAsync(new WorkPanelPage());
        }
    }
}

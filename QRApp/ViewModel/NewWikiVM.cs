using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class NewWikiVM : BaseVM
    {

        private Wiki _wikisDetails;
        public Wiki WikisDetails { get { return _wikisDetails; } set { SetValue(ref _wikisDetails, value); } }

        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get { return _locations; } set { SetValue(ref _locations, value); } }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set { SetValue(ref _euipments, value); } }

        private DictLocation _selecteDictLocation = null;
        public DictLocation SelecteDictLocation { get { return _selecteDictLocation; } set { SetValue(ref _selecteDictLocation, value); } }

        private DictEquipment _selecteDictEquipments = null;
        public DictEquipment SelecteDictEquipments { get { return _selecteDictEquipments; } set { SetValue(ref _selecteDictEquipments, value); } }

        private readonly ICameraService _cameraService;
        private readonly IDataService _dataService;

        public ICommand _CreatePhotoAsync { get; private set; }
        public ImageSource PhotoSource { get { return _cameraService.PhotoSource; } }

        public ICommand _SendNewWiki { get; private set; }

        public NewWikiVM(ICameraService cameraService, IDataService dataService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SendNewWiki = new Command(_ => SendNewWiki());

            _cameraService = cameraService;
            _dataService = dataService;
            _wikisDetails = new Wiki();

            ListLocations();
            ListEquipment();
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

        private Task SendNewWiki()
        {
            _wikisDetails.LocationName = SelecteDictLocation.LocationName;
            _wikisDetails.EquipmentName = SelecteDictEquipments.EquipmentName;
            _wikisDetails.Photo = new byte[1];

            return _dataService.PostNewWiki(_wikisDetails);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public Wiki WikisDetails { get { return _wikisDetails; } set => SetValue(ref _wikisDetails, value); }

        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get { return _locations; } set => SetValue(ref _locations, value); }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set => SetValue(ref _euipments, value); }

        private DictLocation _selecteDictLocation = null;
        public DictLocation SelecteDictLocation { get { return _selecteDictLocation; } set => SetValue(ref _selecteDictLocation, value); }

        private DictEquipment _selecteDictEquipments = null;
        public DictEquipment SelecteDictEquipments { get { return _selecteDictEquipments; } set => SetValue(ref _selecteDictEquipments, value); }

        private readonly ICameraService _cameraService;
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        public ICommand _CreatePhotoAsync { get; private set; }
        public byte[] PhotoBytes { get { return _cameraService.PhotoBytes; } }

        public ICommand _SendNewWiki { get; private set; }

        public NewWikiVM(ICameraService cameraService, IDataService dataService, IDialogService dialogService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _SendNewWiki = new Command(async _ => await SendNewWiki());

            _cameraService = cameraService;
            _dialogService = dialogService;
            _dataService = dataService;
            _wikisDetails = new Wiki();

            _ = ListLocations();
            _ = ListEquipment();
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

        private async Task SendNewWiki()
        {
            _wikisDetails.LocationName = SelecteDictLocation.LocationName;
            _wikisDetails.EquipmentName = SelecteDictEquipments.EquipmentName;
            _wikisDetails.Photo = _cameraService.PhotoBytes;

            
            if (await _dataService.PostNewWiki(_wikisDetails))
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

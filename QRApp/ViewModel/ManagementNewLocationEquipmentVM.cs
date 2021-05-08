﻿using System;
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
        public DictLocation DictLocation { get { return _dictLocation; } set { SetValue(ref _dictLocation, value); } }

        private DictEquipment _dictEquipments = null;
        public DictEquipment DictEquipments { get { return _dictEquipments; } set { SetValue(ref _dictEquipments, value); } }
        
        private List<DictLocation> _locations;
        public List<DictLocation> Locations { get { return _locations; } set { SetValue(ref _locations, value); } }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set { SetValue(ref _euipments, value); } }
        public ICommand _AddNewLocation { get; private set; }
        public ICommand _AddNewEquipment { get; private set; }

        public readonly IDataService _dataService;


        public ManagementNewLocationEquipmentVM(IDataService dataService)
        {
            _AddNewLocation = new Command(_ => AddNewLocation());
            _AddNewEquipment = new Command(_ => AddNewEquipment());

            _dataService = dataService;
            _dictLocation = new DictLocation();
            _dictEquipments = new DictEquipment();

            ListLocations();
            ListEquipment();
        }

        private Task AddNewEquipment()
        {
            return _dataService.PostNewEquipment(_dictEquipments);
        }

        private Task AddNewLocation()
        {
            return _dataService.PostNewLocation(_dictLocation);
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

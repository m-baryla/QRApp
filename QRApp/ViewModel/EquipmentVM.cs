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
    class EquipmentVM : BaseVM
    {

        private DictEquipment _dictEquipments = null;
        public DictEquipment DictEquipments { get { return _dictEquipments; } set => SetValue(ref _dictEquipments, value); }

        private List<DictEquipment> _euipments;
        public List<DictEquipment> Equipments { get { return _euipments; } set => SetValue(ref _euipments, value); }
        public ICommand _AddNewEquipment { get; private set; }

        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;


        public EquipmentVM(IDataService dataService, IDialogService dialogService)
        {
            _AddNewEquipment = new Command(async _ => await AddNewEquipment());

            _dataService = dataService;
            _dialogService = dialogService;
            _dictEquipments = new DictEquipment();

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

        private async Task ListEquipment()
        {
            Equipments = await _dataService.GetEquipmentList();
        }
    }
}

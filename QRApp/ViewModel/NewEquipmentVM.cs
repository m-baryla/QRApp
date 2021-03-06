using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    class NewEquipmentVM : BaseVM
    {
        public readonly IDataService _dataService;
        public readonly IDialogService _dialogService;
        public ICommand _AddNewEquipment { get; private set; }


        private DictEquipment _dictEquipments = null;
        public DictEquipment DictEquipments
        {
            get => _dictEquipments;
            set => SetValue(ref _dictEquipments, value);
        }

        public NewEquipmentVM(IDataService dataService, IDialogService dialogService)
        {
            _AddNewEquipment = new Command(async _ => await AddNewEquipment());
            
            _dataService = dataService;
            _dialogService = dialogService;

            _dictEquipments = new DictEquipment();

        }
        private async Task AddNewEquipment()
        {
            if (await _dataService.PostAsync(new HttpClient(), Constants.PostNewEquipment, _dictEquipments))
            {
                await _dialogService.DisplayAlert("Info", "Add New Equipment successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Add New Equipment failed", "OK", "Cancel");
            }
        }
    }
}

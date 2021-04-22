using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Service;
using QRApp.View;
using QRApp.View.UserPanel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.ViewModel
{
    public class NewTicketVM : BaseVM
    {
        private readonly ICameraService _cameraService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ICommand _TEST { get; private set; }
        public ImageSource PhotoSource { get { return _cameraService.PhotoSource; } }

        private string _scanResult;
        public string ScanResul { get { return _scanResult; } set { SetValue(ref _scanResult, value); } }

        public NewTicketVM(ICameraService cameraService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _TEST = new Command( _ =>  aaaa());

            _cameraService = cameraService;
        }

        private Task<ImageSource> CreatePhotoAsync()
        {
            return _cameraService.CreatePhotoAsync();
        }

        private void aaaa()
        {
            MessagingCenter.Subscribe<ScanService, string>(this, "ResultScanSender", (sender, args) =>
            {
                _scanResult = args;
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.ViewModel
{
    public class NewTicketVM : BaseVM
    {
        private readonly ICameraService _cameraService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ImageSource PhotoSource { get { return _cameraService.PhotoSource; } }

        public NewTicketVM(ICameraService cameraService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());

            _cameraService = cameraService;
        }

        private Task<ImageSource> CreatePhotoAsync()
        {
            return _cameraService.CreatePhotoAsync();
        }
    }
}

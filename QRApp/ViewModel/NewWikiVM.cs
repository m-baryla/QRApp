using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class NewWikiVM : BaseVM
    {
        private readonly ICameraService _cameraService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ImageSource PhotoSource { get { return _cameraService.PhotoSource; } }

        public NewWikiVM(ICameraService cameraService)
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

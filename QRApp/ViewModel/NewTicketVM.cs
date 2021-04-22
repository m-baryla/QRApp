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
        private readonly IPageService _pageService;
        public ICommand _CreatePhotoAsync { get; private set; }

        private ImageSource _photoSource;
        public ImageSource PhotoSource { get { return _photoSource;} set { SetValue(ref _photoSource,value);} }

        public NewTicketVM(IPageService pageService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());

            _pageService = pageService;
        }

        private async Task<ImageSource> CreatePhotoAsync()
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    _photoSource = ImageSource.FromStream(() => stream);
                    return _photoSource;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

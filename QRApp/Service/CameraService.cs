using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QRApp.Interface;
using QRApp.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QRApp.Service
{
    public class CameraService : BaseVM, ICameraService
    {
        public ImageSource PhotoSource { get; set; }

        public async Task<ImageSource> CreatePhotoAsync()
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    PhotoSource = ImageSource.FromStream(() => stream);
                    return PhotoSource;
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

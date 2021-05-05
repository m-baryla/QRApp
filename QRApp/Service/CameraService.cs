using System;
using System.Collections.Generic;
using System.IO;
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

        private byte[] _photoBytes;
        public byte[] PhotoBytes { get { return _photoBytes; } set { SetValue(ref _photoBytes, value); } }
        public async Task<ImageSource> CreatePhotoAsync()
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();
                var ms = new MemoryStream();

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    PhotoSource = ImageSource.FromStream(() => stream);

                    stream.CopyTo(ms);
                    PhotoBytes = ms.ToArray();

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

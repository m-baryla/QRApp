using System;
using System.IO;
using System.Threading.Tasks;
using QRApp.Interface;
using QRApp.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QRApp.Service
{
    public class CameraService : BaseVM, ICameraService
    {

        private ImageSource _photoSource;
        public ImageSource PhotoSource { get => _photoSource;
            set => SetValue(ref _photoSource, value);
        }

        private Image _photo;
        public Image Photo { get => _photo;
            set => SetValue(ref _photo, value);
        }

        private byte[] _photoBytes;
        public byte[] PhotoBytes { get => _photoBytes;
            set => SetValue(ref _photoBytes, value);
        }


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

                return PhotoSource;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ByteToImage(Image resultImage,byte[] photo)
        {
            resultImage.Source = ImageSource.FromStream(() => new MemoryStream(photo));
        }
    }
}

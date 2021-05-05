using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QRApp.Interface
{
    public interface ICameraService
    {
        Task<ImageSource> CreatePhotoAsync();
        ImageSource PhotoSource { get; set; }
        byte[] PhotoBytes { get; set; }
        void ByteToImage(Image resultImage, byte[] photo);

    }
}

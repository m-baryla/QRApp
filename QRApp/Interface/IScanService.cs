using Xamarin.Forms;

namespace QRApp.Interface
{
    public interface IScanService
    {
        void ScanQR(Page pushPage); 
        string ScanResult { get; set; }
    }
}

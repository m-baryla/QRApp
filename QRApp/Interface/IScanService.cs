using System.ComponentModel;
using Xamarin.Forms;
using ZXing;

namespace QRApp.Interface
{
    public interface IScanService
    {
        //void ScanQR(Page pushPage); 
        //string ScanResult { get; set; }
        string Barcode { get; set; }
        bool IsAnalyzing { get; set; }
        bool IsScanning { get; set; }
        Command ScanCommand { get; }
        Result Result { get; set; }
        event PropertyChangedEventHandler PropertyChanged;

    }
}

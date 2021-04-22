using QRApp.Interface;
using QRApp.ViewModel;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QRApp.Service
{
    public class ScanService : BaseVM, IScanService
    {
        private ZXingScannerPage scannerPage;
        private readonly IPageService _pageService;
        private readonly IDialogService _dialogService;
        private string _scanResult;
        public string ScanResult { get { return _scanResult; } set { SetValue(ref _scanResult, value); } }
        public ScanService(IPageService pageService, IDialogService dialogService)
        {
            _pageService = pageService;
            _dialogService = dialogService;

            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                TryHarder = true,
            };
            var overlay = new ZXingDefaultOverlay
            {
                TopText = "Please scan QR code",
                BottomText = "Align the QR code within the frame"
            };
            scannerPage = new ZXingScannerPage(options, overlay)
            {
                DefaultOverlayTopText = "Align the barcode within the frame",
                DefaultOverlayBottomText = string.Empty,
                DefaultOverlayShowFlashButton = true,
                IsScanning = true,
                IsAnalyzing = true
            };
        }
        public async void ScanQR(Page pushPage)
        {
            await _pageService.PushModalAsync(scannerPage);

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsAnalyzing = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    scannerPage.IsScanning = false;
                    //send resultm media center 
                    _scanResult = result.Text;
                    await _pageService.PushModalAsync(pushPage);
                    await _dialogService.DisplayAlert("Scan", result.Text, "OK", "Cancel");

                });
            };
        }
    }
}

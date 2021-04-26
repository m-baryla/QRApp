using System;
using System.ComponentModel;
using QRApp.Interface;
using QRApp.View.UserPanel;
using QRApp.ViewModel;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QRApp.Service
{
    public class ScanService : BaseVM, IScanService
    {

        private readonly IDialogService _dialogService;
        private readonly IPageService _navigationService;

        private string barcode = string.Empty;
        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;
            }
        }

        private bool _isAnalyzing = true;
        public bool IsAnalyzing
        {
            get { return _isAnalyzing; }
            set
            {
                if (!Equals(_isAnalyzing, value))
                {
                    _isAnalyzing = value;
                }
            }
        }

        private bool _isScanning = true;
        public bool IsScanning
        {
            get { return _isScanning; }
            set
            {
                if (!Equals(_isScanning, value))
                {
                    _isScanning = value;
                }
            }
        }

        public Command ScanCommand
        {
            get
            {
                return new Command(() =>

                {
                    IsAnalyzing = false;
                    IsScanning = false;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        Barcode = Result.Text; 
                        MessagingCenter.Send(this, "ResultScanSender", Barcode);
                        await _dialogService.DisplayAlert("Scanned Item", Result.Text, "Ok","Cancel");
                    });

                    IsAnalyzing = true;
                    IsScanning = true;
                });
            }
        }
        public Result Result { get; set; }
        public ScanService(IDialogService dialogService, IPageService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;

            PropertyChanged += ScanningViewModel_PropertyChanged;
        }

        private void ScanningViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _navigationService.PopAsync();
        }
        //private ZXingScannerPage scannerPage;
        //private readonly IPageService _pageService;
        //private readonly IDialogService _dialogService;
        //private string _scanResult;
        //public string ScanResult { get { return _scanResult; } set { SetValue(ref _scanResult, value); } }
        //public ScanService(IPageService pageService, IDialogService dialogService)
        //{
        //    _pageService = pageService;
        //    _dialogService = dialogService;

        //    var options = new MobileBarcodeScanningOptions
        //    {
        //        AutoRotate = false,
        //        UseFrontCameraIfAvailable = false,
        //        TryHarder = true,
        //    };
        //    var overlay = new ZXingDefaultOverlay
        //    {
        //        TopText = "Please scan QR code",
        //        BottomText = "Align the QR code within the frame"
        //    };
        //    scannerPage = new ZXingScannerPage(options, overlay)
        //    {
        //        DefaultOverlayTopText = "Align the barcode within the frame",
        //        DefaultOverlayBottomText = string.Empty,
        //        DefaultOverlayShowFlashButton = true,
        //        IsScanning = true,
        //        IsAnalyzing = true
        //    };
        //}
        //public async void ScanQR(Page pushPage)
        //{
        //    await _pageService.PushModalAsync(scannerPage);

        //    scannerPage.OnScanResult += (result) =>
        //    {
        //        scannerPage.IsAnalyzing = false;

        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            scannerPage.IsScanning = false;
        //            MessagingCenter.Send(this, "ResultScanSender",result.Text);
        //            _scanResult = result.Text;
        //            //await _pageService.PushModalAsync(pushPage);
        //            Application.Current.MainPage = new NavigationPage(new WorkPanelPage());
        //            await _pageService.PopAsync();
        //            await _dialogService.DisplayAlert("Scan", result.Text, "OK", "Cancel");
        //        });
        //    };
        //}
    }
}

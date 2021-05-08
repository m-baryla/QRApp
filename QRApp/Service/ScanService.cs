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
        private readonly IPageService _pageService;

        private string barcode = string.Empty;
        public string Barcode { get { return barcode; } set { barcode = value; } }

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
        public ScanService(IDialogService dialogService, IPageService pageService)
        {
            _dialogService = dialogService;
            _pageService = pageService;

        }
    }
}

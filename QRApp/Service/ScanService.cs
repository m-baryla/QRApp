using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.View.UserSettingsPanel;
using QRApp.View.WorkPanel;
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
        public ICommand _AddNewManual { get; private set; }

        private string barcode = string.Empty;
        public string Barcode { get => barcode;
            set => barcode = value;
        }

        private bool _isAnalyzing = true;
        public bool IsAnalyzing
        { 
            get => _isAnalyzing;
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
            get => _isScanning;
            set
            {
                if (!Equals(_isScanning, value))
                {
                    _isScanning = value;
                }
            }
        }

        public Result Result { get; set; }
        public ScanService(IDialogService dialogService, IPageService pageService)
        {
            _AddNewManual = new Command(async _ => await AddNewManual());

            _dialogService = dialogService;
            _pageService = pageService;
        }
        private async Task AddNewManual()
        {
            var navigate = await _dialogService.DisplayAlert("Create new...", "Select manual type form", "Ticket", "Wiki");

            if (navigate)
            {
                await _pageService.PushModalAsync(new NewTicketsPage(Barcode));
            }
            else
            {
                await _pageService.PushModalAsync(new NewWikiPage(Barcode));
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

                        var navigate = await _dialogService.DisplayAlert("Create new...", Result.Text, "Ticket", "Wiki");

                        if (navigate)
                        {
                            await _pageService.PushModalAsync(new NewTicketsPage(Barcode));

                        }
                        else
                        {
                            await _pageService.PushModalAsync(new NewWikiPage(Barcode));
                        }
                    });

                    IsAnalyzing = true;
                    IsScanning = true;
                });

            }
        }

    }
}

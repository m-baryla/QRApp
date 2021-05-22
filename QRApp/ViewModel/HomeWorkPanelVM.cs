using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microcharts;
using QRApp.Interface;
using QRApp.View.WorkPanel;
using SkiaSharp;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    class HomeWorkPanelVM
    {
        private readonly IDataService _dataService;
        private readonly IPageService _pageService;
        public ICommand _GoToNew { get; private set; }


        public HomeWorkPanelVM(IDataService dataService,IPageService pageService)
        {
            _dataService = dataService;
            _pageService = pageService;
            _GoToNew = new Command(async _ => await GoToNew());


        }
        public readonly ChartEntry[] _Breakdowns = new[]
      {
            new ChartEntry(212)
            {
                Label = "Active",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Not Active",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            }
        };
        public readonly ChartEntry[] _Repairs = new[]
        {
            new ChartEntry(212)
            {
                Label = "Active",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Not Active",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            }
        };
        public readonly ChartEntry[] _Maintenance = new[]
        {
            new ChartEntry(212)
            {
                Label = "Active",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Not Active",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            }
        };
        public readonly ChartEntry[] _Inspection = new[]
        {
            new ChartEntry(212)
            {
                Label = "Active",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Not Active",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            }
        };
        public readonly ChartEntry[] _Cleaning = new[]
        {
            new ChartEntry(212)
            {
                Label = "Active",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Not Active",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            }
        };
        public readonly ChartEntry[] _All = new[]
        {
            new ChartEntry(212)
            {
                Label = "Active",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Not Active",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            }
        };

        private async Task GoToNew()
        {
            await _pageService.PushModalAsync(new CreateFromScan());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microcharts;
using Microcharts.Forms;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View.WorkPanel;
using SkiaSharp;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    class HomeWorkPanelVM : BaseVM
    {
        private readonly IDataService _dataService;
        private readonly IPageService _pageService;
        public ICommand _GoToNew { get; private set; }
        public static List<DictTicketType> TicketTypeListActive { get; set; }
        public static List<DictTicketType> TicketTypeListNotActive { get; set; }
        public static List<DictTicketType> TicketTypeListNotActiveAll { get; set; }
        public static List<DictTicketType> TicketTypeListActiveAll { get; set; }

        private DonutChart _chartBreakdowns;
        public DonutChart ChartBreakdowns { get => _chartBreakdowns; set => SetValue(ref _chartBreakdowns, value); }

        private DonutChart _chartRepairs;
        public DonutChart ChartRepairs { get => _chartRepairs; set => SetValue(ref _chartRepairs, value); }

        private DonutChart _chartMaintenance;
        public DonutChart ChartMaintenance { get => _chartMaintenance; set => SetValue(ref _chartMaintenance, value); }

        private DonutChart _chartInspection;
        public DonutChart ChartInspection { get => _chartInspection; set => SetValue(ref _chartInspection, value); }

        private DonutChart _chartCleaning;
        public DonutChart ChartCleaning { get => _chartCleaning; set => SetValue(ref _chartCleaning, value); }

        private DonutChart _chartAll;
        public DonutChart ChartAll { get => _chartAll; set => SetValue(ref _chartAll, value); }

        public static string BreakdownsActiveCount { get; set; }
        public static string BreakdownsNotActiveCount { get; set; }
        public static string RepairsActiveCount { get; private set; }
        public static string RepairsNotActiveCount { get; private set; }
        public static string MaintenanceActiveCount { get; private set; }
        public static string MaintenanceNotActiveCount { get; private set; }
        public static string InspectionActiveCount { get; private set; }
        public static string InspectionNotActiveCount { get; private set; }
        public static string CleaningActiveCount { get; private set; }
        public static string CleaningNotActiveCount { get; private set; }
        public static string AllActiveCount { get; private set; }
        public static string AllNotActiveCount { get; private set; }

        public HomeWorkPanelVM(IDataService dataService,IPageService pageService)
        {
            _dataService = dataService;
            _pageService = pageService;
            _GoToNew = new Command(async _ => await GoToNew());

            _ = GetCountTicketType();
        }
        
        private async Task GoToNew()
        {
            await _pageService.PushModalAsync(new CreateFromScan());
        }

        public async Task GetCountTicketType()
        {
            TicketTypeListActive = await _dataService.GetDictTicketTypesActive();
            TicketTypeListNotActive = await _dataService.GetDictTicketTypesNotActive();
            TicketTypeListActiveAll = await _dataService.GetDictTicketTypesAllActive();
            TicketTypeListNotActiveAll = await _dataService.GetDictTicketTypesAllNotActive();

            BreakdownsActiveCount = TicketTypeListActive.Where(t => t.Type == "Breakdowns").Select(t => t.Count).FirstOrDefault().ToString();
            RepairsActiveCount = TicketTypeListActive.Where(t => t.Type == "Repairs").Select(t => t.Count).FirstOrDefault().ToString();
            MaintenanceActiveCount = TicketTypeListActive.Where(t => t.Type == "Maintenance").Select(t => t.Count).FirstOrDefault().ToString();
            InspectionActiveCount = TicketTypeListActive.Where(t => t.Type == "Inspection").Select(t => t.Count).FirstOrDefault().ToString();
            CleaningActiveCount = TicketTypeListActive.Where(t => t.Type == "Cleaning").Select(t => t.Count).FirstOrDefault().ToString();

            BreakdownsNotActiveCount = TicketTypeListNotActive.Where(t => t.Type == "Breakdowns").Select(t => t.Count).FirstOrDefault().ToString();
            RepairsNotActiveCount = TicketTypeListNotActive.Where(t => t.Type == "Repairs").Select(t => t.Count).FirstOrDefault().ToString();
            MaintenanceNotActiveCount = TicketTypeListNotActive.Where(t => t.Type == "Maintenance").Select(t => t.Count).FirstOrDefault().ToString();
            InspectionNotActiveCount = TicketTypeListNotActive.Where(t => t.Type == "Inspection").Select(t => t.Count).FirstOrDefault().ToString();
            CleaningNotActiveCount = TicketTypeListNotActive.Where(t => t.Type == "Cleaning").Select(t => t.Count).FirstOrDefault().ToString();

            AllActiveCount = TicketTypeListActiveAll.Where(t => t.Type == "Active").Select(t => t.Count).FirstOrDefault().ToString();
            AllNotActiveCount = TicketTypeListNotActiveAll.Where(t => t.Type == "Not Active").Select(t => t.Count).FirstOrDefault().ToString();

            var _Breakdowns = new List<ChartEntry>
            {
                new ChartEntry(Convert.ToInt32(BreakdownsActiveCount))
                {
                    Label = "Active",
                    ValueLabel = BreakdownsActiveCount,
                    Color = SKColor.Parse("#2c3e50")
                },
                new ChartEntry(Convert.ToInt32(BreakdownsNotActiveCount))
                {
                    Label = "Not Active",
                    ValueLabel = BreakdownsNotActiveCount,
                    Color = SKColor.Parse("#77d065")
                }
            };
            var _Repairs = new List<ChartEntry>
            {
                new ChartEntry(Convert.ToInt32(RepairsActiveCount))
                {
                    Label = "Active",
                    ValueLabel = RepairsActiveCount,
                    Color = SKColor.Parse("#2c3e50")
                },
                new ChartEntry(Convert.ToInt32(RepairsNotActiveCount))
                {
                    Label = "Not Active",
                    ValueLabel = RepairsNotActiveCount,
                    Color = SKColor.Parse("#77d065")
                }
            };
            var _Maintenance = new List<ChartEntry>
            {
                new ChartEntry(Convert.ToInt32(MaintenanceActiveCount))
                {
                    Label = "Active",
                    ValueLabel = MaintenanceActiveCount,
                    Color = SKColor.Parse("#2c3e50")
                },
                new ChartEntry(Convert.ToInt32(MaintenanceNotActiveCount))
                {
                    Label = "Not Active",
                    ValueLabel = MaintenanceNotActiveCount,
                    Color = SKColor.Parse("#77d065")
                }
            };
            var _Inspection = new List<ChartEntry>
            {
                new ChartEntry(Convert.ToInt32(InspectionActiveCount))
                {
                    Label = "Active",
                    ValueLabel = InspectionActiveCount,
                    Color = SKColor.Parse("#2c3e50")
                },
                new ChartEntry(Convert.ToInt32(InspectionNotActiveCount))
                {
                    Label = "Not Active",
                    ValueLabel = InspectionNotActiveCount,
                    Color = SKColor.Parse("#77d065")
                }
            };
            var _Cleaning = new List<ChartEntry>
            {
                new ChartEntry(Convert.ToInt32(CleaningActiveCount))
                {
                    Label = "Active",
                    ValueLabel = CleaningActiveCount,
                    Color = SKColor.Parse("#2c3e50")
                },
                new ChartEntry(Convert.ToInt32(CleaningNotActiveCount))
                {
                    Label = "Not Active",
                    ValueLabel = CleaningNotActiveCount,
                    Color = SKColor.Parse("#77d065")
                }
            };
            var _All = new List<ChartEntry>
            {
                new ChartEntry(Convert.ToInt32(AllActiveCount))
                {
                    Label = "Active",
                    ValueLabel = AllActiveCount,
                    Color = SKColor.Parse("#42DFD1")
                },
                new ChartEntry(Convert.ToInt32(AllNotActiveCount))
                {
                    Label = "Not Active",
                    ValueLabel = AllNotActiveCount,
                    Color = SKColor.Parse("#426DDF")
                }
            };


            ChartBreakdowns = new DonutChart { Entries = _Breakdowns, HoleRadius = 0.5f };
            ChartRepairs = new DonutChart { Entries = _Repairs, HoleRadius = 0.5f };
            ChartMaintenance = new DonutChart { Entries = _Maintenance, HoleRadius = 0.5f };
            ChartInspection = new DonutChart { Entries = _Inspection, HoleRadius = 0.5f };
            ChartCleaning = new DonutChart { Entries = _Cleaning, HoleRadius = 0.5f };
            ChartAll = new DonutChart { Entries = _All, HoleRadius = 0.5f };
        }
    }
}

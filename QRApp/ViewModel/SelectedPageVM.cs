using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View;
using QRApp.View.UserPanel;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QRApp.ViewModel
{
    public class SelectedPageVM : BaseVM
    {
        public ObservableCollection<Location> Locations { get; set; } = new ObservableCollection<Location>();

        public ObservableCollection<Maschine> Maschines { get; set; } = new ObservableCollection<Maschine>();

        private readonly IPageService _pageService;
        private readonly IScanService _scanService;
        public ICommand _SelectFromList { get; private set; }
        public ICommand _SelectFromQR { get; private set; }

        public SelectedPageVM(IPageService pageService, IScanService scanService)
        {
            _SelectFromList = new Command(_ => SelectFromList());
            _SelectFromQR = new Command(_ => SelectFromQR());
            _pageService = pageService;
            _scanService = scanService;
            ListLocations();
            ListMaschines();
        }

        private IEnumerable<Location> ListLocations()
        {
            Locations = new ObservableCollection<Location>
            {
                new Location { LocationName = "Location1"},
                new Location { LocationName = "Location2"},
                new Location { LocationName = "Location3"},
                new Location { LocationName = "Location4"},
                new Location { LocationName = "Location5"},
                new Location { LocationName = "Location6"},
                new Location { LocationName = "Location7"},
                new Location { LocationName = "Location8"},
                new Location { LocationName = "Location9"},
                new Location { LocationName = "Location10"},
                new Location { LocationName = "Location11"}
            };

            return Locations;
        }
        private IEnumerable<Maschine> ListMaschines()
        {
            Maschines = new ObservableCollection<Maschine>
            {
                new Maschine { MaschineName = "Maschine1"},
                new Maschine { MaschineName = "Maschine2"},
                new Maschine { MaschineName = "Maschine3"},
                new Maschine { MaschineName = "Maschine4"},
                new Maschine { MaschineName = "Maschine5"},
                new Maschine { MaschineName = "Maschine6"},
                new Maschine { MaschineName = "Maschine7"},
                new Maschine { MaschineName = "Maschine8"},
                new Maschine { MaschineName = "Maschine9"},
                new Maschine { MaschineName = "Maschine10"},
                new Maschine { MaschineName = "Maschine11"}
            };

            return Maschines;
        }
        private async void SelectFromList()
        {
            await _pageService.PushModalAsync(new WorkPanelPage());
        }

        private void SelectFromQR()
        {
             _scanService.ScanQR(new WorkPanelPage());
        }
    }
}

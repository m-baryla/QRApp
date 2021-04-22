using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.Model;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedPage : ContentPage
    {
        public SelectedPage()
        {
            InitializeComponent();
            PageService service = new PageService();
            BindingContext = new SelectedPageVM(service, new ScanService(service));

            foreach (var p in (BindingContext as SelectedPageVM).Locations)
            {
                pickerLocation.Items.Add(p.LocationName);
            }
            foreach (var p in (BindingContext as SelectedPageVM).Maschines)
            {
                pickerMaschine.Items.Add(p.MaschineName);
            }
        }

        private void PickerLocation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var loca = pickerLocation.Items[pickerLocation.SelectedIndex];
            DisplayAlert("Selection", loca, "OK");
        }

        private void PickerMaschine_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var mach = pickerMaschine.Items[pickerMaschine.SelectedIndex];
            DisplayAlert("Selection", mach, "OK");
        }
    }
}
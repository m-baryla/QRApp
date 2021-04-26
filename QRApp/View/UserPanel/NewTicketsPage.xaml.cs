using System;
using System.Runtime.CompilerServices;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTicketsPage : ContentPage
    {
        public NewTicketsPage()
        { 
            InitializeComponent();
            BindingContext = new NewTicketVM(new PageService(),new ScanService(new DialogService(),new PageService()),new CameraService(),new DataService());

            foreach (var p in (BindingContext as NewTicketVM).Locations)
            {
                pickerLocation.Items.Add(p.LocationName);
            }
            foreach (var p in (BindingContext as NewTicketVM).Maschines)
            {
                pickerMaschine.Items.Add(p.MaschineName);
            }
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var photo = (BindingContext as NewTicketVM).PhotoSource;

            try
            {
                if (photo != null)
                    resultImage.Source = photo;
                else
                    resultImage.Source = null;
            }
            catch (Exception)
            {
                throw;
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

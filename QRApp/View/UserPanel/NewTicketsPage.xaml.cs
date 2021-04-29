using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using QRApp.Model;
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
            BindingContext = new NewTicketVM(new PageService(),new CameraService(),new DataService());

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
            //var loca = pickerLocation.Items[pickerLocation.SelectedIndex];
        }

        private void PickerMaschine_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //var mach = pickerMaschine.Items[pickerMaschine.SelectedIndex];
        }

    }
}

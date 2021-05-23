using System;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.WorkPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTicketsPage : ContentPage
    {
        public NewTicketsPage(string resultScan)
        { 
            InitializeComponent();
            BindingContext = new NewTicketVM(new CameraService(),new DataService(),new DialogService(),resultScan);
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var photo = (BindingContext as NewTicketVM).PhotoBytes;
            CameraService cameraService = new CameraService();
            cameraService.ByteToImage(resultImage, photo);
        }
    }
}

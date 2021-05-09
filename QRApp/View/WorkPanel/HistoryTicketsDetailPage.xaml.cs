using System;
using QRApp.Model;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.WorkPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryTicketsDetailPage : ContentPage
    {
        public HistoryTicketsDetailPage(Ticket _ticketsHistoryDetails)
        {

            if (_ticketsHistoryDetails == null)
                throw new ArgumentNullException();

            BindingContext = new TicketHistoryVM(new DataService(),_ticketsHistoryDetails, new DialogService());

            InitializeComponent();

            var photo = (BindingContext as TicketHistoryVM).PhotoBytes;
            CameraService cameraService = new CameraService();
            cameraService.ByteToImage(resultImage, photo);

        }
    }
}
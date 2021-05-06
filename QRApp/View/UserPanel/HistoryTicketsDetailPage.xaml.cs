using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.Model;
using QRApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryTicketsDetailPage : ContentPage
    {
        public HistoryTicketsDetailPage(Ticket _ticketsHistoryDetails)
        {
            if (_ticketsHistoryDetails == null)
                throw new ArgumentNullException();

            BindingContext = _ticketsHistoryDetails;
            
            InitializeComponent();

            var photo = _ticketsHistoryDetails.Photo;
            CameraService cameraService = new CameraService();
            cameraService.ByteToImage(resultImage, photo);

        }
    }
}
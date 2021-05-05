using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWikiPage : ContentPage
    {
        public NewWikiPage()
        {
            InitializeComponent();
            BindingContext = new NewWikiVM(new CameraService(),new DataService());
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            //var photo = (BindingContext as NewWikiVM).PhotoSource;

            //try
            //{
            //    if (photo != null)
            //        resultImage.Source = photo;
            //    else
            //        resultImage.Source = null;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            var photo = (BindingContext as NewWikiVM).PhotoBytes;
            CameraService cameraService = new CameraService();
            cameraService.ByteToImage(resultImage, photo);
        }
    }
}
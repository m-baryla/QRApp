using System;
using QRApp.Model;
using QRApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.WorkPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiDetailPage : ContentPage
    {
		public WikiDetailPage(Wiki _wikiDetail)
        {
            if (_wikiDetail == null)
                throw new ArgumentNullException();

            BindingContext = _wikiDetail;

            InitializeComponent();

            var photo = _wikiDetail.Photo;
            CameraService cameraService = new CameraService();
            cameraService.ByteToImage(resultImage,photo);

        }
	}
}
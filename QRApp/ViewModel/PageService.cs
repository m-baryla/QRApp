using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
	public class PageService: IPageService
	{
		public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
		{
			return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
		}

        public async Task PopAsync()
        {
			await Application.Current.MainPage.Navigation.PopAsync();
		}

        public async Task PushAsync(Page page)
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(page);
		}

		public async Task PopModalAsync()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}

		public async Task PushModalAsync(Page page)
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(page);
		}
        public async Task<ImageSource> CreatePhotoAsync()
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync(); 
                var photo = ImageSource.FromStream(() => stream);
                return photo;
            }
            return null;
        }
        public async Task<ImageSource> PickPhotoAsync()
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                var pic = ImageSource.FromStream(() => stream);
                return pic;
            }
            return null;
        }
    }
}

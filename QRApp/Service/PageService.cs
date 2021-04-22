using System.Threading.Tasks;
using QRApp.Interface;
using Xamarin.Forms;

namespace QRApp.Service
{
	public class PageService: IPageService
	{
		//public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
		//{
		//	return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
		//}

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
    }
}

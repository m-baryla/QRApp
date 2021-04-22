using System.Threading.Tasks;
using QRApp.Interface;
using Xamarin.Forms;

namespace QRApp.Service
{
    public class DialogService : IDialogService
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }
    }
}

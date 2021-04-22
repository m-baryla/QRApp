using System.Threading.Tasks;

namespace QRApp.Interface
{
    interface IDialogService
    {
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
    }
}

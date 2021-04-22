using System.Threading.Tasks;

namespace QRApp.Interface
{
    public interface IDialogService
    {
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
    }
}

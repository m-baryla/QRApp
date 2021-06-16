using System.Threading.Tasks;
using Xamarin.Forms;

namespace QRApp.Interface
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopAsync();
        Task PushModalAsync(Page page);
        Task PopModalAsync();
    }
}

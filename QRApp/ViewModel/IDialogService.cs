using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QRApp.ViewModel
{
    interface IDialogService
    {
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
    }
}

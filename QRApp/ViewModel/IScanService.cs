using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public interface IScanService
    {
        void ScanQR(Page pushPage); 
        string ScanResult { get; set; }
    }
}

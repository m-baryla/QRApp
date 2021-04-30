using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryTicketsDetailPage : ContentPage
    {
        public HistoryTicketsDetailPage(TicketsHistory _ticketsHistoryDetails)
        {
            if (_ticketsHistoryDetails == null)
                throw new ArgumentNullException();

            BindingContext = _ticketsHistoryDetails;

            InitializeComponent();
        }
    }
}
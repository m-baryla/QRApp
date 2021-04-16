using System.Collections.Generic;
using QRApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryTicketsPage : ContentPage
    {
      
        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as HistoryDetail;
            await Navigation.PushAsync(new HistoryTicketsDetailPage(contact));
            listView.SelectedItem = null;
        }

        public HistoryTicketsPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<HistoryDetail> {
                new HistoryDetail { Name = "1", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "2", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "3", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "4", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "5", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "1", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "2", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "3", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "4", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "5", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "1", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "2", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "3", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "4", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "5", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "1", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "2", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "3", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "4", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "5", Detail = "detail_test99999999" }
            };
        }
    }
}
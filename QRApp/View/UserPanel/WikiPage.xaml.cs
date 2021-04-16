using System.Collections.Generic;
using QRApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiPage : ContentPage
    {
		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as WikiDetail;
            await Navigation.PushAsync(new WikiDetailPage(contact));
            listView.SelectedItem = null;
        }

        public WikiPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<WikiDetail> {
                new WikiDetail { Name = "1", Detail = "detail_test99999999" },
                new WikiDetail { Name = "2", Detail = "detail_test99999999" },
                new WikiDetail { Name = "3", Detail = "detail_test99999999" },
                new WikiDetail { Name = "4", Detail = "detail_test99999999" },
                new WikiDetail { Name = "5", Detail = "detail_test99999999" },
                new WikiDetail { Name = "1", Detail = "detail_test99999999" },
                new WikiDetail { Name = "2", Detail = "detail_test99999999" },
                new WikiDetail { Name = "3", Detail = "detail_test99999999" },
                new WikiDetail { Name = "4", Detail = "detail_test99999999" },
                new WikiDetail { Name = "5", Detail = "detail_test99999999" },
                new WikiDetail { Name = "1", Detail = "detail_test99999999" },
                new WikiDetail { Name = "2", Detail = "detail_test99999999" },
                new WikiDetail { Name = "3", Detail = "detail_test99999999" },
                new WikiDetail { Name = "4", Detail = "detail_test99999999" },
                new WikiDetail { Name = "5", Detail = "detail_test99999999" },
                new WikiDetail { Name = "1", Detail = "detail_test99999999" },
                new WikiDetail { Name = "2", Detail = "detail_test99999999" },
                new WikiDetail { Name = "3", Detail = "detail_test99999999" },
                new WikiDetail { Name = "4", Detail = "detail_test99999999" },
                new WikiDetail { Name = "5", Detail = "detail_test99999999" }
            };
        }
	}
}
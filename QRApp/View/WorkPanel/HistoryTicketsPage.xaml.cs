using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.WorkPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryTicketsPage : ContentPage
    {
        public HistoryTicketsPage()
        {
            InitializeComponent();
            BindingContext = new TicketHistoryVM(new PageService(),new DataService(),new DialogService());
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as TicketHistoryVM)._GoToDetailPage.Execute(e.SelectedItem);
        }

        private async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = await (BindingContext as TicketHistoryVM).GetHistoryTicketsSearch(e.NewTextValue);
        }
    }
}
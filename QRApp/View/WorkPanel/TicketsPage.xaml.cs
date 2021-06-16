using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.WorkPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketsPage : ContentPage
    {
        public TicketsPage()
        {
            InitializeComponent();
            BindingContext = new TicketVM(new PageService(),new DataService());
        }


        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as TicketVM)._GoToDetailPage.Execute(e.SelectedItem);
        }

        private async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = await (BindingContext as TicketVM).GetHistoryTicketsSearch(e.NewTextValue);
        }
    }
}
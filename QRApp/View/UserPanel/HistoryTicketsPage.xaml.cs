using System.Collections.Generic;
using QRApp.Model;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryTicketsPage : ContentPage
    {
        public HistoryTicketsPage()
        {
            BindingContext = new HistoryVM(new PageService());
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as HistoryVM)._GoToDetailPage.Execute(e.SelectedItem);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            InitializeComponent();
            BindingContext = new HistoryVM(new PageService());
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as HistoryVM)._GoToDetailPage.Execute(e.SelectedItem);
        }

        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = (BindingContext as HistoryVM).ListOfHistoryDetail(e.NewTextValue);
        }

        private async void RefreshView_OnRefreshing(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            RefreshView.IsRefreshing = false;
            //update
        }
    }
}
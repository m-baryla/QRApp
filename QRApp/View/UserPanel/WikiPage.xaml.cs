using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QRApp.Model;
using QRApp.Service;
using QRApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiPage : ContentPage
    {

        public WikiPage()
        {
            InitializeComponent();
            BindingContext = new WikiVM(new PageService(), new DataService());
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as WikiVM)._GoToDetailPage.Execute(e.SelectedItem);
        }

        private async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = await (BindingContext as WikiVM).GetWikiSearch(e.NewTextValue);
        }
    }
}
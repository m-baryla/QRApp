using System.Collections.Generic;
using QRApp.Model;
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
            BindingContext = new WikiVM(new PageService());
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as WikiVM)._GoToDetailPage.Execute(e.SelectedItem);
        }

        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = (BindingContext as WikiVM).ListOfWikiDetail(e.NewTextValue);
        }
    }
}
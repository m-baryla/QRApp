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
            BindingContext = new WikiVM(new PageService());
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as WikiVM)._GoToDetailPage.Execute(e.SelectedItem);

        }
    }
}
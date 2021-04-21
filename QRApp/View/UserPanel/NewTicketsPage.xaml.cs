using System;
using System.Runtime.CompilerServices;
using QRApp.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTicketsPage : ContentPage
    {
        public NewTicketsPage()
        {
            InitializeComponent();
            BindingContext = new NewTicketVM(new PageService());
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var photo = (BindingContext as NewTicketVM).PhotoSource;

            try
            {
                if (photo != null)
                    resultImage.Source = photo;
                else
                    resultImage.Source = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

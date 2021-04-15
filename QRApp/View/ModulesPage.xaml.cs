using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModulesPage : ContentPage
    {
        public ModulesPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }
    }
}
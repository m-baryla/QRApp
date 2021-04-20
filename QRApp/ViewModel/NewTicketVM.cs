using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QRApp.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.ViewModel
{
    public class NewTicketVM : BaseVM
    {
        private readonly IPageService _pageService;
        public ICommand _CreatePhotoAsync { get; private set; }
        public ICommand _PickPhotoAsync { get; private set; }

        private ImageSource _photoSource;
        public ImageSource PhotoSource { get { return _photoSource;} set { SetValue(ref _photoSource,value);} }

        private ImageSource _pickSource;
        public ImageSource PickSource { get { return _pickSource; } set { SetValue(ref _pickSource, value); } }

        public NewTicketVM(IPageService pageService)
        {
            _CreatePhotoAsync = new Command(async _ => await CreatePhotoAsync());
            _PickPhotoAsync = new Command(async _ => await PickPhotoAsync());

            _pageService = pageService;
        }

        private async Task CreatePhotoAsync()
        {
             _photoSource = await _pageService.CreatePhotoAsync();
        }
        private async Task PickPhotoAsync()
        {
            _pickSource = await _pageService.PickPhotoAsync();
        }
    }
}

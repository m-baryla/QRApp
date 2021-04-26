using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View;
using QRApp.View.UserPanel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class WikiVM : BaseVM
    {
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;
        public ObservableCollection<WikiDetail> WikiDetailsList { get; set; } = new ObservableCollection<WikiDetail>();

        public ICommand _GoToDetailPage { get; private set; }
        public ICommand _GoToNewWikiPage { get; private set; }

        private WikiDetail _selectedWikiDetail;
        public WikiDetail SelectedWikiDetail
        {
            get { return _selectedWikiDetail; }
            set { SetValue(ref _selectedWikiDetail, value); }
        }

        public WikiVM(IPageService pageService, IDataService dataService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());
            _GoToNewWikiPage = new Command(_ => GoToNewWikiPage());

            _pageService = pageService;
            _dataService = dataService;

            ListOfWikiDetail();
        }

        private async void GoToNewWikiPage()
        {
            await _pageService.PushModalAsync(new NewWikiPage());
        }
        private async void GoToDetailPage()
        {
            if (SelectedWikiDetail == null)
                return;

            await _pageService.PushModalAsync(new WikiDetailPage(SelectedWikiDetail));

            SelectedWikiDetail = null;
        }

        public IEnumerable<WikiDetail> ListOfWikiDetail(string searchString = null)
        {
            WikiDetailsList = _dataService.ListOfWikiDetail();

            if (String.IsNullOrWhiteSpace(searchString))
                return WikiDetailsList;

            return WikiDetailsList.Where(c => c.Name.StartsWith(searchString));

        }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private bool _isRefreshing;
        public bool IsRefreshing
        { get { return _isRefreshing; } set { SetValue(ref _isRefreshing, value); } }

        private ObservableCollection<WikiDetail> _wikiDetailsList;
        public ObservableCollection<WikiDetail> WikiDetailsList { get { return _wikiDetailsList; } set { SetValue(ref _wikiDetailsList, value); } }
        public ICommand _GoToDetailPage { get; private set; }
        public ICommand _GoToNewWikiPage { get; private set; }
        public ICommand _RefereshWikis { get; private set; }

        private WikiDetail _selectedWikiDetail;
        public WikiDetail SelectedWikiDetail {get { return _selectedWikiDetail; } set { SetValue(ref _selectedWikiDetail, value); } }

        public WikiVM(IPageService pageService, IDataService dataService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());
            _GoToNewWikiPage = new Command(_ => GoToNewWikiPage());
            _RefereshWikis = new Command(_ => GetWikis());

            _pageService = pageService;
            _dataService = dataService;

            GetWikis();
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
        private async Task GetWikis()
        {
            IsRefreshing = true;
            WikiDetailsList = _dataService.ListOfWikiDetail();
            IsRefreshing = false;
        }
        public IEnumerable<WikiDetail> GetWikiSearch(string searchString = null)
        {
            _wikiDetailsList = _dataService.ListOfWikiDetail();

            if (String.IsNullOrWhiteSpace(searchString))
                return _wikiDetailsList;

            return _wikiDetailsList.Where(c => c.Name.StartsWith(searchString));
        }
    }
}


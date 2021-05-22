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
using QRApp.View.WorkPanel;
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
        { get => _isRefreshing;
            set => SetValue(ref _isRefreshing, value); }

        private List<Wiki> _wikiDetailsList;
        public List<Wiki> WikiDetailsList { get => _wikiDetailsList;
            set => SetValue(ref _wikiDetailsList, value); }
        public ICommand _GoToDetailPage { get; private set; }
        public ICommand _GoToNewWikiPage { get; private set; }
        public ICommand _RefereshWikis { get; private set; }

        private Wiki _selectedWikiDetail;
        public Wiki SelectedWikiDetail {get => _selectedWikiDetail;
            set => SetValue(ref _selectedWikiDetail, value); }

        public WikiVM(IPageService pageService, IDataService dataService)
        {
            _GoToDetailPage = new Command(async _ => await GoToDetailPage());
            _GoToNewWikiPage = new Command(async _ => await GoToNewWikiPage());
            _RefereshWikis = new Command(async _ => await GetWikis());

            _pageService = pageService;
            _dataService = dataService;

            _ = GetWikis();
        }
        private async Task GoToNewWikiPage()
        {
            await _pageService.PushModalAsync(new WikisCreate());
        }
        private async Task GoToDetailPage()
        {
            if (SelectedWikiDetail == null)
                return;

            await _pageService.PushModalAsync(new WikiDetailPage(SelectedWikiDetail));

            SelectedWikiDetail = null;
        }
        private async Task GetWikis()
        {
            WikiDetailsList = await _dataService.GetWikiDetailList();
            IsRefreshing = false;
        }
        public async Task<IEnumerable<Wiki>> GetWikiSearch(string searchString = null)
        {
            _wikiDetailsList = await _dataService.GetWikiDetailList();

            if (String.IsNullOrWhiteSpace(searchString))
                return _wikiDetailsList;

            return _wikiDetailsList.Where(c => c.Topic.StartsWith(searchString) ||
                                                c.LocationName.StartsWith(searchString) ||
                                                c.EquipmentName.StartsWith(searchString) ||
                                                c.Description.StartsWith(searchString));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
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
        public ObservableCollection<WikiDetail> WikiDetailsList { get; set; } = new ObservableCollection<WikiDetail>();

        public ICommand _GoToDetailPage { get; private set; }

        private WikiDetail _selectedWikiDetail;
        public WikiDetail SelectedWikiDetail
        {
            get { return _selectedWikiDetail; }
            set { SetValue(ref _selectedWikiDetail, value); }
        }

        public WikiVM(IPageService pageService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());

            _pageService = pageService;

            ListOfWikiDetail();
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
            WikiDetailsList = new ObservableCollection<WikiDetail>
            {
                new WikiDetail {Name = "aaa1", Detail = "detail_test99999999"},
                new WikiDetail {Name = "bbb2", Detail = "detail_test99999999"},
                new WikiDetail {Name = "ccc3", Detail = "detail_test99999999"},
                new WikiDetail {Name = "ddd4", Detail = "detail_test99999999"},
                new WikiDetail {Name = "abc5", Detail = "detail_test99999999"},
                new WikiDetail {Name = "bca6", Detail = "detail_test99999999"},
                new WikiDetail {Name = "cab7", Detail = "detail_test99999999"},
                new WikiDetail {Name = "qqq", Detail = "detail_test99999999"},
                new WikiDetail {Name = "a8b", Detail = "detail_test99999999"},
                new WikiDetail {Name = "b9a", Detail = "detail_test99999999"},
                new WikiDetail {Name = "c0c", Detail = "detail_test99999999"}
            };

            if (String.IsNullOrWhiteSpace(searchString))
                return WikiDetailsList;

            return WikiDetailsList.Where(c => c.Name.StartsWith(searchString));

        }
    }
}


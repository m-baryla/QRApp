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

        private WikiDetail _selectedWikiDetail;
        public ObservableCollection<WikiDetail> WikiDetailsList { get; private set; } = new ObservableCollection<WikiDetail>();
        public ICommand _GoToDetailPage { get; private set; }

        public WikiDetail SelectedWikiDetail
        {
            get { return _selectedWikiDetail; }
            set { SetValue(ref _selectedWikiDetail, value); }
        }

        public WikiVM(IPageService pageService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());

            _pageService = pageService;

            WikiDetailsList.Add(new WikiDetail { Name = "1", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "2", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "3", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "4", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "5", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "6", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "7", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "7", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "8", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "9", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "0", Detail = "detail_test99999999" });
            WikiDetailsList.Add(new WikiDetail { Name = "11", Detail = "detail_test99999999" });
        }

        private async void GoToDetailPage()
        {
            if (SelectedWikiDetail == null)
                return;

            await _pageService.PushModalAsync(new WikiDetailPage(SelectedWikiDetail));

            SelectedWikiDetail = null;
        }
    }
}


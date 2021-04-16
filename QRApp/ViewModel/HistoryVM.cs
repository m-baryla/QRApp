using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Model;
using QRApp.View.UserPanel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace QRApp.ViewModel
{
    public class HistoryVM : BaseVM
    {
        private readonly IPageService _pageService;

        public ObservableCollection<HistoryDetail> HistoryDetailsList { get; set; } = new ObservableCollection<HistoryDetail>();
        public ICommand _GoToDetailPage { get; private set; }

        private HistoryDetail _selectedHistoryDetail;

        public HistoryDetail SelectedHistoryDetail
        {
            get { return _selectedHistoryDetail; }
            set { SetValue(ref _selectedHistoryDetail, value); }
        }

        public HistoryVM(IPageService pageService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());

            _pageService = pageService;

            ListOfHistoryDetail();
        }

        private async void GoToDetailPage()
        {
            if (SelectedHistoryDetail == null)
                return;

            await _pageService.PushModalAsync(new HistoryTicketsDetailPage(SelectedHistoryDetail));

            SelectedHistoryDetail = null;
        }

        public IEnumerable<HistoryDetail> ListOfHistoryDetail(string searchString = null)
        {
            HistoryDetailsList = new ObservableCollection<HistoryDetail>
            {
                new HistoryDetail { Name = "aaa1", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "bbb2", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "ccc3", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "ddd4", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "abc5", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "bca6", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "cab7", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "c7", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "a8b", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "b9a", Detail = "detail_test99999999" },
                new HistoryDetail { Name = "c0c", Detail = "detail_test99999999" }
            };

            if (String.IsNullOrWhiteSpace(searchString))
                return HistoryDetailsList;

            return HistoryDetailsList.Where(c => c.Name.StartsWith(searchString));
        }
    }
}

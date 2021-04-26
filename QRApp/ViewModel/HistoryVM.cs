using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Model;
using QRApp.View.UserPanel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using QRApp.Interface;

namespace QRApp.ViewModel
{
    public class HistoryVM : BaseVM
    {
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;
        private bool _isRefreshing;
        public bool IsRefreshing { get { return _isRefreshing; } set { SetValue(ref _isRefreshing, value); } }

        private ObservableCollection<HistoryDetail> _historyDetailsList;
        public ObservableCollection<HistoryDetail> HistoryDetailsList { get { return _historyDetailsList; } set { SetValue(ref _historyDetailsList, value); } }
        public ICommand _GoToDetailPage { get; private set; }
        public ICommand _RefereshHistoryTickets { get; private set; }

        private HistoryDetail _selectedHistoryDetail;
        public HistoryDetail SelectedHistoryDetail { get { return _selectedHistoryDetail; } set { SetValue(ref _selectedHistoryDetail, value); }}

        public HistoryVM(IPageService pageService, IDataService dataService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());
            _RefereshHistoryTickets = new Command(_ => GetHistoryTickets());

            _pageService = pageService;
            _dataService = dataService;

            GetHistoryTickets();
        }
        private async void GoToDetailPage()
        {
            if (SelectedHistoryDetail == null)
                return;

            await _pageService.PushModalAsync(new HistoryTicketsDetailPage(SelectedHistoryDetail));

            SelectedHistoryDetail = null;
        }
        private async Task GetHistoryTickets()
        {
            IsRefreshing = true;
            HistoryDetailsList = _dataService.HistoryDetailsList();
            IsRefreshing = false;
        }
        public IEnumerable<HistoryDetail> GetHistoryTicketsSearch(string searchString = null)
        {
            _historyDetailsList = _dataService.HistoryDetailsList();

            if (String.IsNullOrWhiteSpace(searchString))
                return _historyDetailsList;

            return _historyDetailsList.Where(c => c.Name.StartsWith(searchString));
        }
    }
}

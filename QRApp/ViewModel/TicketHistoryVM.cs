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
    public class TicketHistoryVM : BaseVM
    {
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;
        private bool _isRefreshing;
        public bool IsRefreshing { get { return _isRefreshing; } set { SetValue(ref _isRefreshing, value); } }

        private List<Ticket> _historyDetailsList;
        public List<Ticket> HistoryDetailsList { get { return _historyDetailsList; } set { SetValue(ref _historyDetailsList, value); } }
        public ICommand _GoToDetailPage { get; private set; }
        public ICommand _RefereshHistoryTickets { get; private set; }

        private Ticket _selectedHistoryDetail;
        public Ticket SelectedHistoryDetail { get { return _selectedHistoryDetail; } set { SetValue(ref _selectedHistoryDetail, value); }}

        public TicketHistoryVM(IPageService pageService, IDataService dataService)
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
            HistoryDetailsList = await _dataService.GetTicketHistoryDetailsList();
            IsRefreshing = false;
        }
        public async Task<IEnumerable<Ticket>> GetHistoryTicketsSearch(string searchString = null)
        {
            _historyDetailsList = await _dataService.GetTicketHistoryDetailsList();

            if (String.IsNullOrWhiteSpace(searchString))
                return _historyDetailsList;

            return _historyDetailsList.Where(c => c.Topic.StartsWith(searchString));
        }
    }
}

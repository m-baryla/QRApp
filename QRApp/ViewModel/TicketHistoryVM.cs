using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using QRApp.Interface;
using QRApp.Service;
using QRApp.View.WorkPanel;

namespace QRApp.ViewModel
{
    public class TicketHistoryVM : BaseVM
    {
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;
        public ICommand _GoToDetailPage { get; private set; }
        public ICommand _RefereshHistoryTickets { get; private set; }
        public ICommand _UpdateStatusTicket { get; private set; }
        public Ticket Ticket { get; set; }
        private Ticket _putTicket { get; set; }
        public byte[] PhotoBytes { get; set; }

        private bool _isRefreshing;
        public bool IsRefreshing { get { return _isRefreshing; } set => SetValue(ref _isRefreshing, value); }

        private List<Ticket> _historyDetailsList;
        public List<Ticket> HistoryDetailsList { get { return _historyDetailsList; } set => SetValue(ref _historyDetailsList, value); }

        private Ticket _selectedHistoryDetail;
        public Ticket SelectedHistoryDetail { get { return _selectedHistoryDetail; } set => SetValue(ref _selectedHistoryDetail, value); }

        private List<DictStatu> _status;
        public List<DictStatu> StatusList { get { return _status; } set => SetValue(ref _status, value); }

        private DictStatu _selecteDictStatu;
        public DictStatu SelecteDictStatu { get { return _selecteDictStatu; } set => SetValue(ref _selecteDictStatu, value); }

        public TicketHistoryVM(IPageService pageService, IDataService dataService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());
            _RefereshHistoryTickets = new Command(async _ => await GetHistoryTickets());

            _pageService = pageService;
            _dataService = dataService;

            _ = GetHistoryTickets();
        }

        public TicketHistoryVM(IDataService dataService,Ticket _ticket, IDialogService dialogService)
        {
            _UpdateStatusTicket = new Command(async _ => await UpdateStatusTicket());

            _putTicket = new Ticket();

            Ticket = _ticket;

            _dataService = dataService;
            _dialogService = dialogService;

            _selecteDictStatu = new DictStatu();

            PhotoBytes = Ticket.Photo;

            _ = ListStatus();
        }

        private async Task UpdateStatusTicket()
        {
            _putTicket.Id = Ticket.Id;
            _putTicket.UserName = Application.Current.Properties["userName"].ToString();
            _putTicket.Description = Ticket.Description;
            _putTicket.Topic = Ticket.Topic;
            _putTicket.Photo = Ticket.Photo;
            _putTicket.LocationName = Ticket.LocationName;
            _putTicket.EquipmentName = Ticket.EquipmentName;
            _putTicket.Status = SelecteDictStatu.Status;
            _putTicket.EmailAdress = Ticket.EmailAdress;

            if (await _dataService.PutTicket(Ticket.Id, _putTicket))
            {
                await _dialogService.DisplayAlert("Info", "Update Status successful", "OK", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Info", "Update Status failed", "OK", "Cancel");
            }
        }

        private async Task GoToDetailPage()
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
        private async Task ListStatus()
        {
            StatusList = await _dataService.GetStatusList();
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

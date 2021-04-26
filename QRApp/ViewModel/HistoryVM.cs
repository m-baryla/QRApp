using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Model;
using QRApp.View.UserPanel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using QRApp.Interface;

namespace QRApp.ViewModel
{
    public class HistoryVM : BaseVM
    {
        private readonly IPageService _pageService;
        private readonly IDataService _dataService;

        public ObservableCollection<HistoryDetail> HistoryDetailsList { get; set; } = new ObservableCollection<HistoryDetail>();
        public ICommand _GoToDetailPage { get; private set; }

        private HistoryDetail _selectedHistoryDetail;

        public HistoryDetail SelectedHistoryDetail
        {
            get { return _selectedHistoryDetail; }
            set { SetValue(ref _selectedHistoryDetail, value); }
        }

        public HistoryVM(IPageService pageService, IDataService dataService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());

            _pageService = pageService;
            _dataService = dataService;

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
            HistoryDetailsList = _dataService.HistoryDetailsList();

            if (String.IsNullOrWhiteSpace(searchString))
                return HistoryDetailsList;

            return HistoryDetailsList.Where(c => c.Name.StartsWith(searchString));
        }
    }
}

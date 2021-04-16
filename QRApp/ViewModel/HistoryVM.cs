using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QRApp.Model;
using QRApp.View.UserPanel;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace QRApp.ViewModel
{
    public class HistoryVM : BaseVM
    {
        private readonly IPageService _pageService;

        private HistoryDetail _selectedHistoryDetail;
        public ObservableCollection<HistoryDetail> HistoryDetailsList { get; private set; } = new ObservableCollection<HistoryDetail>();
        public ICommand _GoToDetailPage { get; private set; }

        public HistoryDetail SelectedHistoryDetail
        {
            get { return _selectedHistoryDetail; }
            set { SetValue(ref _selectedHistoryDetail, value); }
        }

        public HistoryVM(IPageService pageService)
        {
            _GoToDetailPage = new Command(_ => GoToDetailPage());

            _pageService = pageService;

            HistoryDetailsList.Add(new HistoryDetail{ Name = "1", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "2", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "3", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "4", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "5", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "6", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "7", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "7", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "8", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail{ Name = "9", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail { Name = "0", Detail = "detail_test99999999" });
            HistoryDetailsList.Add(new HistoryDetail { Name = "11", Detail = "detail_test99999999" });
        }

        private async void GoToDetailPage()
        {
            if (SelectedHistoryDetail == null)
                return;

            await _pageService.PushModalAsync(new HistoryTicketsDetailPage(SelectedHistoryDetail));

            SelectedHistoryDetail = null;
        }
    }
}

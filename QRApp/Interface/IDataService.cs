using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using QRApp.Model;

namespace QRApp.Interface
{
    public interface IDataService
    {
        Task<List<DictEmailAdress>> EmailAdressesList();
        ObservableCollection<HistoryDetail> HistoryDetailsList();
        Task<List<DictLocation>> LocationsList();
        Task<List<DictEquipment>> EquipmentList();
        Task<List<Wiki>> WikiDetailList();

    }
}

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
        ObservableCollection<Location> ListLocations();
        ObservableCollection<Maschine> ListMaschines();
        ObservableCollection<WikiDetail> ListOfWikiDetail();

    }
}

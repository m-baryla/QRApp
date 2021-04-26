using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using QRApp.Model;

namespace QRApp.Interface
{
    public interface IDataService
    {
        ObservableCollection<EmailAdress> EmailAdressesList();
        ObservableCollection<HistoryDetail> HistoryDetailsList();
        ObservableCollection<Location> ListLocations();
        ObservableCollection<Maschine> ListMaschines();
        ObservableCollection<WikiDetail> ListOfWikiDetail();

    }
}

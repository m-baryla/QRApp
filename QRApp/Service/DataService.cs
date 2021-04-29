using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRApp.Interface;
using QRApp.Model;

namespace QRApp.Service
{

    public class DataService : IDataService
    {
        public async Task<List<DictEmailAdress>> EmailAdressesList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://192.168.1.83:8030/api/DictEmailAdresses/");
            var emails = JsonConvert.DeserializeObject<List<DictEmailAdress>>(json);
            return emails;
        }
        public ObservableCollection<HistoryDetail> HistoryDetailsList()
        {
            var historys = new ObservableCollection<HistoryDetail>
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
            return historys;
        }

        public ObservableCollection<Location> ListLocations()
        {
            var locations = new ObservableCollection<Location>
            {
                new Location {LocationName = "Location1"},
                new Location {LocationName = "Location2"},
                new Location {LocationName = "Location3"},
                new Location {LocationName = "Location4"},
                new Location {LocationName = "Location5"},
                new Location {LocationName = "Location6"},
                new Location {LocationName = "Location7"},
                new Location {LocationName = "Location8"},
                new Location {LocationName = "Location9"},
                new Location {LocationName = "Location10"},
                new Location {LocationName = "Location11"}
            };
            return locations;
        }

        public ObservableCollection<Maschine> ListMaschines()
        {
            var maschines = new ObservableCollection<Maschine>
            {
                new Maschine { MaschineName = "Maschine1"},
                new Maschine { MaschineName = "Maschine2"},
                new Maschine { MaschineName = "Maschine3"},
                new Maschine { MaschineName = "Maschine4"},
                new Maschine { MaschineName = "Maschine5"},
                new Maschine { MaschineName = "Maschine6"},
                new Maschine { MaschineName = "Maschine7"},
                new Maschine { MaschineName = "Maschine8"},
                new Maschine { MaschineName = "Maschine9"},
                new Maschine { MaschineName = "Maschine10"},
                new Maschine { MaschineName = "Maschine11"}
            };
            return maschines;
        }
        public ObservableCollection<WikiDetail> ListOfWikiDetail()
        {
            var wikis = new ObservableCollection<WikiDetail>
            {
                new WikiDetail {Name = "aaa1", Detail = "detail_test99999999"},
                new WikiDetail {Name = "bbb2", Detail = "detail_test99999999"},
                new WikiDetail {Name = "ccc3", Detail = "detail_test99999999"},
                new WikiDetail {Name = "ddd4", Detail = "detail_test99999999"},
                new WikiDetail {Name = "abc5", Detail = "detail_test99999999"},
                new WikiDetail {Name = "bca6", Detail = "detail_test99999999"},
                new WikiDetail {Name = "cab7", Detail = "detail_test99999999"},
                new WikiDetail {Name = "qqq", Detail = "detail_test99999999"},
                new WikiDetail {Name = "a8b", Detail = "detail_test99999999"},
                new WikiDetail {Name = "b9a", Detail = "detail_test99999999"},
                new WikiDetail {Name = "c0c", Detail = "detail_test99999999"}
            };
            return wikis;
        }

    }
}

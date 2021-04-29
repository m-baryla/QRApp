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

        public async Task<List<DictLocation>> LocationsList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://192.168.1.83:8030/api/DictLocations/");
            var locations = JsonConvert.DeserializeObject<List<DictLocation>>(json);
            return locations;
        }

        public async Task<List<DictEquipment>> EquipmentList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://192.168.1.83:8030/api/DictEquipments/");
            var equipments = JsonConvert.DeserializeObject<List<DictEquipment>>(json);
            return equipments;
        }
        public async Task<List<Wiki>> WikiDetailList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://192.168.1.83:8030/api/Wikis/");
            var wikis = JsonConvert.DeserializeObject<List<Wiki>>(json);
            return wikis;
        }

    }
}

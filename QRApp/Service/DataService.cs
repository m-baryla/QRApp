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
        public async Task<List<TicketsHistory>> HistoryDetailsList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://192.168.1.83:8030/api/TicketsHistories/TicketsHistoriesDetails/");
            var historys = JsonConvert.DeserializeObject<List<TicketsHistory>>(json);
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
            var json = await httpClient.GetStringAsync("http://192.168.1.83:8030/api/Wikis/GetWikiDetail/");
            var wikis = JsonConvert.DeserializeObject<List<Wiki>>(json);
            return wikis;
        }

    }
}

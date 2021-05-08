using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRApp.Interface;
using QRApp.Model;
using QRApp.View.MainPanel;

namespace QRApp.Service
{

    public class DataService : IDataService
    {
        private const string url = "http://192.168.1.87:8030";
        //private const string url = "https://localhost:44337";
        public async Task<List<DictStatu>> GetStatusList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url + "/api/DictStatus/");
            var status = JsonConvert.DeserializeObject<List<DictStatu>>(json);
            return status;
        }
        public async Task<List<DictEmailAdress>> GetEmailAdressesList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url + "/api/DictEmailAdresses/");
            var emails = JsonConvert.DeserializeObject<List<DictEmailAdress>>(json);
            return emails;
        }
        public async Task<List<Ticket>> GetTicketHistoryDetailsList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url + "/api/Tickets/TicketsHistoriesDetails/");
            var historys = JsonConvert.DeserializeObject<List<Ticket>>(json);
            return historys;
        }

        public async Task<List<DictLocation>> GetLocationsList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url + "/api/DictLocations/");
            var locations = JsonConvert.DeserializeObject<List<DictLocation>>(json);
            return locations;
        }

        public async Task<List<DictEquipment>> GetEquipmentList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url + "/api/DictEquipments/");
            var equipments = JsonConvert.DeserializeObject<List<DictEquipment>>(json);
            return equipments;
        }
        public async Task<List<Wiki>> GetWikiDetailList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url + "/api/Wikis/GetWikiDetail/");
            var wikis = JsonConvert.DeserializeObject<List<Wiki>>(json);
            return wikis;
        }
        public async Task PostNewTicket(Ticket ticketsDetails)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(ticketsDetails);
            StringContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(url + "/api/Tickets/", content);
        }

        public async Task PostNewWiki(Wiki wikiDetails)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(wikiDetails);
            StringContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(url + "/api/Wikis/", content);
        }

        public async Task<bool> LoginAuth(User user)
        {
            try
            {
                if (user.Login != null && user.Password != null)
                {
                    var httpClient = new HttpClient();
                    var auth = string.Format("{0}:{1}", user.Login, Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Password)));
                    var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
                    var result = await httpClient.GetAsync(url + "/api/Users/GetUser/");
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}

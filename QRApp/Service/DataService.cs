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
        public async Task<List<DictTicketType>> GetDictTicketTypesAllActive()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictTicketTypes/GetDictTicketTypesAllActive/");
                var ticType = JsonConvert.DeserializeObject<List<DictTicketType>>(json);
                return ticType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<DictTicketType>> GetDictTicketTypesAllNotActive()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictTicketTypes/GetDictTicketTypesAllNotActive/");
                var ticType = JsonConvert.DeserializeObject<List<DictTicketType>>(json);
                return ticType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<DictTicketType>> GetDictTicketTypesNotActive()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictTicketTypes/GetDictTicketTypesNotActive/");
                var ticType = JsonConvert.DeserializeObject<List<DictTicketType>>(json);
                return ticType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<DictTicketType>> GetDictTicketTypesActive()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictTicketTypes/GetDictTicketTypesActive/");
                var ticType = JsonConvert.DeserializeObject<List<DictTicketType>>(json);
                return ticType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<DictPriority>> GetDictPrioritieList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictPriorities/");
                var priority = JsonConvert.DeserializeObject<List<DictPriority>>(json);
                return priority;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<DictTicketType>> GetDictTicketTypeList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictTicketTypes/");
                var type = JsonConvert.DeserializeObject<List<DictTicketType>>(json);
                return type;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<DictStatu>> GetStatusList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictStatus/");
                var status = JsonConvert.DeserializeObject<List<DictStatu>>(json);
                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<DictEmailAdress>> GetEmailAdressesList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictEmailAdresses/");
                var emails = JsonConvert.DeserializeObject<List<DictEmailAdress>>(json);
                return emails;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<Ticket>> GetTicketHistoryDetailsList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/Tickets/TicketsHistoriesDetails/");
                var historys = JsonConvert.DeserializeObject<List<Ticket>>(json);
                return historys;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<DictLocation>> GetLocationsList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictLocations/");
                var locations = JsonConvert.DeserializeObject<List<DictLocation>>(json);
                return locations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<DictEquipment>> GetEquipmentList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/DictEquipments/");
                var equipments = JsonConvert.DeserializeObject<List<DictEquipment>>(json);
                return equipments;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<Wiki>> GetWikiDetailList()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(Constants.Url + "/api/Wikis/GetWikiDetail/");
                var wikis = JsonConvert.DeserializeObject<List<Wiki>>(json);
                return wikis;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<bool> PostNewTicket(Ticket ticketsDetails)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(ticketsDetails);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.Url + "/api/Tickets/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> PostNewWiki(Wiki wikiDetails)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(wikiDetails);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.Url + "/api/Wikis/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> PutTicket(int id,Ticket ticketsDetails)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(ticketsDetails);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PutAsync(Constants.Url + "/api/Tickets/" + id + "/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> PostNewEmail(DictEmailAdress emailAdress)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(emailAdress);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.Url + "/api/DictEmailAdresses/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> PostNewLocation(DictLocation location)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(location);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.Url + "/api/DictLocations/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> PostNewEquipment(DictEquipment equipment)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(equipment);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.Url + "/api/DictEquipments/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> PostEmailAdressNotify(DictEmailAdress emailAdressNotify)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(emailAdressNotify);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.Url + "/api/DictEmailAdresses/SendEmail/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
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

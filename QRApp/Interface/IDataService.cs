using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using QRApp.Model;

namespace QRApp.Interface
{
    public interface IDataService
    {

        Task<List<T>> GetAsync<T>(HttpClient httpClient, string url);
        Task<bool> PostAsync<T>(HttpClient httpClient, string url, T obj);
        Task<bool> PustAsync<T>(HttpClient httpClient, string url, T obj, int id);

        //Task<List<DictTicketType>> GetDictTicketTypesAllActive(HttpClient httpClient);
        //Task<List<DictTicketType>> GetDictTicketTypesAllNotActive(HttpClient httpClient);
        //Task<List<DictTicketType>> GetDictTicketTypesNotActive(HttpClient httpClient);
        //Task<List<DictTicketType>> GetDictTicketTypesActive(HttpClient httpClient);
        //Task<List<DictPriority>> GetDictPrioritieList(HttpClient httpClient);
        //Task<List<DictTicketType>> GetDictTicketTypeList(HttpClient httpClient);
        //Task<List<DictEmailAdress>> GetEmailAdressesList(HttpClient httpClient);
        //Task<List<DictStatu>> GetStatusList(HttpClient httpClient);
        //Task<List<Ticket>> GetTicketHistoryDetailsList(HttpClient httpClient);        
        //Task<List<DictLocation>> GetLocationsList(HttpClient httpClient);
        //Task<List<DictEquipment>> GetEquipmentList(HttpClient httpClient);
        //Task<List<Wiki>> GetWikiDetailList(HttpClient httpClient);
        //Task<bool> PostNewTicket(Ticket ticketsDetails, HttpClient httpClient);
        //Task<bool> PostNewWiki(Wiki wikiDetails, HttpClient httpClient);
        //Task<bool> PutTicket(int id, Ticket ticketsDetails, HttpClient httpClient);
        //Task<bool> PostNewEmail(DictEmailAdress emailAdress, HttpClient httpClient);
        //Task<bool> PostNewLocation(DictLocation location, HttpClient httpClient);
        //Task<bool> PostNewEquipment(DictEquipment equipment, HttpClient httpClient);
        //Task<bool> PostEmailAdressNotify(DictEmailAdress emailAdressNotify, HttpClient httpClient);


    }
}

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
        Task<List<DictPriority>> GetDictPrioritieList();
        Task<List<DictTicketType>> GetDictTicketTypeList();
        Task<List<DictEmailAdress>> GetEmailAdressesList();
        Task<List<DictStatu>> GetStatusList();
        Task<List<Ticket>> GetTicketHistoryDetailsList();        
        Task<List<DictLocation>> GetLocationsList();
        Task<List<DictEquipment>> GetEquipmentList();
        Task<List<Wiki>> GetWikiDetailList();
        Task<bool> PostNewTicket(Ticket ticketsDetails);
        Task<bool> PostNewWiki(Wiki wikiDetails);
        Task<bool> PutTicket(int id, Ticket ticketsDetails);
        Task<bool> PostNewEmail(DictEmailAdress emailAdress);
        Task<bool> PostNewLocation(DictLocation location);
        Task<bool> PostNewEquipment(DictEquipment equipment);
        Task<bool> PostEmailAdressNotify(DictEmailAdress emailAdressNotify);


    }
}

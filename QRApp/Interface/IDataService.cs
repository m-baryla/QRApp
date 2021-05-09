﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using QRApp.Model;

namespace QRApp.Interface
{
    public interface IDataService
    {
        Task<List<DictEmailAdress>> GetEmailAdressesList();
        Task<List<DictStatu>> GetStatusList();
        Task<List<Ticket>> GetTicketHistoryDetailsList();        
        Task<List<DictLocation>> GetLocationsList();
        Task<List<DictEquipment>> GetEquipmentList();
        Task<List<Wiki>> GetWikiDetailList();
        Task<bool> PostNewTicket(Ticket ticketsDetails);
        Task<bool> PostNewWiki(Wiki wikiDetails);
        Task<bool> LoginAuth(User user);
        Task<bool> PutTicket(int id, Ticket ticketsDetails);
        Task<bool> PostNewEmail(DictEmailAdress emailAdress);
        Task<bool> PostNewAccount(User user);
        Task<bool> PostNewLocation(DictLocation location);
        Task<bool> PostNewEquipment(DictEquipment equipment);
        Task<bool> PostEmailAdressNotify(DictEmailAdress emailAdressNotify);


    }
}

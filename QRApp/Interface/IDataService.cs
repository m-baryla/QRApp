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
        Task<List<Ticket>> GetTicketHistoryDetailsList();        
        Task<List<DictLocation>> GetLocationsList();
        Task<List<DictEquipment>> GetEquipmentList();
        Task<List<Wiki>> GetWikiDetailList();
        Task PostNewTicket(Ticket ticketsDetails);

        //Task PostNewWiki(Wiki wikiDetails);
    }
}

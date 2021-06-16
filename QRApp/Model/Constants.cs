using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace QRApp.Model
{
    public static class Constants
    {
        public static readonly string ClientId = "814fd394-e662-4722-94d0-9fd65fc8ac7b";
        public static readonly string[] Scopes = new string[] { "User.Read" };
        public static readonly string RedirectUri = "msal814fd394-e662-4722-94d0-9fd65fc8ac7b://auth";
        public static readonly string TenantId = "195770a6-80bf-4668-b85f-31a0fea07f7e";
        public static readonly string IosKeychainSecurityGroups = "com.microsoft.aadauthentication";
        public static readonly string Url = "https://qrappapi.azurewebsites.net";

        public static readonly string GetDictTicketTypesAllActive = "/api/DictTicketTypes/GetDictTicketTypesAllActive/";
        public static readonly string GetDictTicketTypesAllNotActive = "/api/DictTicketTypes/GetDictTicketTypesAllNotActive/";
        public static readonly string GetDictTicketTypesNotActive = "/api/DictTicketTypes/GetDictTicketTypesNotActive/";
        public static readonly string GetDictTicketTypesActive = "/api/DictTicketTypes/GetDictTicketTypesActive/";
        public static readonly string GetDictPrioritieList = "/api/DictPriorities/";
        public static readonly string GetDictTicketTypeList = "/api/DictTicketTypes/";
        public static readonly string GetStatusList = "/api/DictStatus/";
        public static readonly string GetEmailAdressesList = "/api/DictEmailAdresses/";
        public static readonly string GetTicketHistoryDetailsList = "/api/Tickets/TicketsHistoriesDetails/";
        public static readonly string GetLocationsList = "/api/DictLocations/";
        public static readonly string GetEquipmentList = "/api/DictEquipments/";
        public static readonly string GetWikiDetailList = "/api/Wikis/GetWikiDetail/";
        public static readonly string PostNewTicket = "/api/Tickets/";
        public static readonly string PostNewWiki = "/api/Wikis/";
        public static readonly string PutTicket = "/api/Tickets/";
        public static readonly string PostNewEmail = "/api/DictEmailAdresses/";
        public static readonly string PostNewLocation = "/api/DictLocations/";
        public static readonly string PostNewEquipment = "/api/DictEquipments/";
        public static readonly string PostEmailAdressNotify = "/api/DictEmailAdresses/SendEmail/";
    }
}

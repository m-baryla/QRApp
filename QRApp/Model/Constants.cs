using System;
using System.Globalization;
using Xamarin.Forms;

namespace QRApp.Model
{
    public static class Constants
    {
        public static readonly string ClientId = "e5b34251-f601-44c3-adbc-5a51a6e0d078";
        //public static readonly string[] Scopes = new string[] { "User.Read", "People.Read" };
        public static readonly string[] Scopes = new string[] { "People.Read" };
        public static readonly string RedirectUri = "msale5b34251-f601-44c3-adbc-5a51a6e0d078://auth";
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
        public static readonly string PostNewEmail = "/api/DictEmailAdresses/";
        public static readonly string PostNewLocation = "/api/DictLocations/";
        public static readonly string PostNewEquipment = "/api/DictEquipments/";
        public static readonly string PostEmailAdressNotify = "/api/EmailSender/SendEmail/";

        public static readonly string PutTicket = "/api/Tickets/";

    }
}

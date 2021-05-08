﻿

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using System.Collections.Generic;
using QRApp.ViewModel;

namespace QRApp.Model
{
    public partial class Ticket : BaseVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public string LocationName { get; set; }
        public string EquipmentName { get; set; }
        public string Status { get; set; }
        public string EmailAdress { get; set; }
    }
}

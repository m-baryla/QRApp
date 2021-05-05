﻿

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using System;

namespace QRApp.Model
{
    public partial class Wiki
    {
        public string LocationName { get; set; }
        public string EquipmentName { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
    }
}

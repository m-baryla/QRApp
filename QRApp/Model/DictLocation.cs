﻿using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QRApp.Model
{
    public partial class DictLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Wiki> Wikis { get; set; }
    }
}
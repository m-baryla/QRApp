﻿using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QRApp.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdPermission { get; set; }

        public virtual DictPermission IdPermissionNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

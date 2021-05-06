

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using System.Collections.Generic;
using QRApp.ViewModel;

namespace QRApp.Model
{
    public partial class Ticket : BaseVM
    {
        public string UserName { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public string LocationName { get; set; }
        public string EquipmentName { get; set; }
        public string Status { get; set; }
        public string EmailAdress { get; set; }
        public bool? IsAnonymous { get; set; }

        private List<DictStatu> _status;
        public List<DictStatu> StatusList { get { return _status; } set { SetValue(ref _status, value); } }

        private DictStatu _selecteDictStatu = null;
        public DictStatu SelecteDictStatu { get { return _selecteDictStatu; } set { SetValue(ref _selecteDictStatu, value); } }
    }
}

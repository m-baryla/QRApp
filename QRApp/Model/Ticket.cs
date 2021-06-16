
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
        public string Priority { get; set; }
        public string TicketType { get; set; }
    }
}

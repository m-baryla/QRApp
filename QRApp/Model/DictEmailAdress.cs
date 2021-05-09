using System.Collections.Generic;


namespace QRApp.Model
{
    public partial class DictEmailAdress
    {
        public int Id { get; set; }
        public string EmailAdressNotify { get; set; }
        public string Subject { get; set; }
        public string Content_part1 { get; set; }
        public string Content_part2 { get; set; }
        public string Content_part3 { get; set; }
    }
}

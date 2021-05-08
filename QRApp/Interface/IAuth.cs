using System;
using System.Collections.Generic;
using System.Text;

namespace QRApp.Interface
{
    public interface IAuth
    {
        int Id { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string Password_1 { get; set; }
        string Password_2 { get; set; }
    }
}

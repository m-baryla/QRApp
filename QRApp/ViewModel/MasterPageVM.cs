using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class MasterPageVM
    {
        public ICommand _TestVoid { get; set; }

        public MasterPageVM()
        {
            _TestVoid = new Command(_ => TestVoid());
        }

        private void TestVoid()
        {

        }
    }
}

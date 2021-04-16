using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using QRApp.Model;
using QRApp.View;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public class AdressEmailVM
    {
        public ObservableCollection<EmailAdress> EmailAdressesList { get; set; } = new ObservableCollection<EmailAdress>();
        public ICommand _AddNewAdressEmail { get; private set; }
        private readonly IPageService _pageService;

        public AdressEmailVM(IPageService pageService)
        {
            _AddNewAdressEmail = new Command(_ => AddNewAdressEmail());
            _pageService = pageService;

            ListOfEmailAdress();
        }

        private void AddNewAdressEmail()
        {
            EmailAdressesList.Add(new EmailAdress { Email = "aaaa@op.pl" });
        }

        public IEnumerable<EmailAdress> ListOfEmailAdress(string searchString = null)
        {
            EmailAdressesList = new ObservableCollection<EmailAdress>
            {
                new EmailAdress { Email = "test@op.pl"},
                new EmailAdress { Email = "test@op.pl"},
                new EmailAdress { Email = "test@op.pl"},
                new EmailAdress { Email = "test@op.pl"},
                new EmailAdress { Email = "aaaa@op.pl"},
                new EmailAdress { Email = "aaaa@op.pl"},
                new EmailAdress { Email = "aaaa@op.pl"},
                new EmailAdress { Email = "aaaa@op.pl"},
                new EmailAdress { Email = "test@op.pl"},
                new EmailAdress { Email = "tesa@op.pl"},
                new EmailAdress { Email = "tesa@op.pl"}
            };

            if (String.IsNullOrWhiteSpace(searchString))
                return EmailAdressesList;

            return EmailAdressesList.Where(c => c.Email.StartsWith(searchString));
        }
    }
}


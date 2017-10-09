using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models.Logics
{
    public class ContactLogic
    {
        public List<Contact> Buscar()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var Contacts = context.Contacts.OrderBy(x => x.Name)
                                        .ToList();

                return Contacts;
            }
        }
    }
}
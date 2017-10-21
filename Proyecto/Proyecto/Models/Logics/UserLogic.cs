using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models.Logics
{
    public class UserLogic
    {
        public List<ApplicationUser> Buscar()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var Contacts = context.Users.OrderBy(x => x.Name)
                                        .ToList();

                return Contacts;
            }
        }
    }
}
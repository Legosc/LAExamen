using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models.Logics
{
    public class ProductLogic
    {
        public List<Product> Buscar(string Name)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var products = context.Products.OrderBy(x => x.Name)
                                        .Where(x => x.Name.Contains(Name))
                                        .Take(10)
                                        .ToList();

                return products;
            }
        }
    }
}
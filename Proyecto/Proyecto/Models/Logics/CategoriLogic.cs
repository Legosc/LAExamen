using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models.Logics
{
    public class CategoriLogic
    {
        public List<Category> Buscar()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var Categories = context.Categories.OrderBy(x => x.Name)
                                        .ToList();

                return Categories;
            }
        }
        public bool VerifCategoria(int IdCat)
        {
            var context = new ApplicationDbContext();
            
            var result = context.Categories.Find(IdCat);
            if (result == null)
            {
                return false;
            }
            else { return true; }
            
        }
    }
}
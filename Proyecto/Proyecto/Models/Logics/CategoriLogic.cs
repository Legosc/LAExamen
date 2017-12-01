using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models.Logics
{
    public class CategoriLogic
    {
       
        public List<Category> Buscar(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var Categories = context.Categories.Where(x => x.Id != id).OrderBy(x => x.Name)
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

        public string CategoryList(List<Category> List)
        {
            string htmlList ="";
            
            foreach (Category x in List)
            {
                htmlList = htmlList + "<ul class='collection'>";
                if (x.ICategory == null) {
                    htmlList = htmlList + "<li class='collection - item' id= '"+ x.Id +"'>"+ x.Name + "</li>";
                }
                else
                {

                }
                htmlList = htmlList + "</ul>";
            }

            return htmlList;
        }
        
    }
   
}
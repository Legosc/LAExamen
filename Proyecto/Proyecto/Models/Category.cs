using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        public int? FatherCategoryID { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
    public  class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FatherCategoryID { get; set; }
        public string FatherCategoryName { get; set; }

        public Category ToModel()
        {
            var Category = new Category();
            Category.Id = this.Id;
            Category.Name = this.Name;
            Category.FatherCategoryID = this.FatherCategoryID;

            return Category;
        }
    }
    
}
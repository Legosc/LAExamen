using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Proyecto.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ICategory")]
        public int? FatherCategoryID { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        [ScriptIgnore]
        public  virtual Category ICategory { get; set; }
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
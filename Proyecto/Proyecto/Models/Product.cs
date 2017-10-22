using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
    #region ViewModels

    public class ProductViewModel
    {
        #region Cabecera
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int Price { get; set; }

        #endregion

        #region Contenido
        public List<ProductVariantViewModel> ProductVariants { get; set; }
        public List<AttributeViewModel> Attributes { get; set; }
        #endregion

        public ProductViewModel()
        {
            ProductVariants = new List<ProductVariantViewModel>();
            Attributes = new List<AttributeViewModel>();
            Refrescar();
        }

        public void Refrescar()
        {
           
        }



    }
    #endregion
}
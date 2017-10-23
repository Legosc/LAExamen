using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Price { get; set; }
        public virtual Product  Product { get; set; }

        public virtual ICollection<VariantAttribute> VariantAttributes { get; set; }
    }


    public partial class ProductVariantViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public bool Retirar { get; set; }

    }
}
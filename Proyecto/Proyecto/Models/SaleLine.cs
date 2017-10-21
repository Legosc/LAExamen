using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class SaleLine
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        [ForeignKey("ProductVariant")]
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public double Aumont { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
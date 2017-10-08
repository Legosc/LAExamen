using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            InvoiceLine = new List<InvoiceLine>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte? Image { get; set; }
        public int Price { get; set; }
        public bool Enabled { get; set; }
        public virtual List<InvoiceLine> InvoiceLine { get; set; }
    }
}
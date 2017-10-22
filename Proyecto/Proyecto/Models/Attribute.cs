using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Attribute
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
        public ICollection<AttributeValue> AttributeValues { get; set; }
    }
    public class AttributeViewModel
    {
      
        public int Id { get; set; }
        public string Description { get; set; }
       
    }
}
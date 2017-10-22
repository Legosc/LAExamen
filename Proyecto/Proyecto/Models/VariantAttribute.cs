using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class VariantAttribute
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductVariant")]
        public int VariantId { get; set; }
        [ForeignKey("Attribute")]
        public int AttributeId { get; set; }
        [ForeignKey("AttributeValue")]
        public int AttributeValueId { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
        public virtual Attribute Attribute { get; set; }
        public virtual AttributeValue AttributeValue { get; set; }


    }
}
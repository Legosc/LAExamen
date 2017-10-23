using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class AttributeValue
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Attributes")]
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public virtual Attribute Attributes { get; set; }

    }
}
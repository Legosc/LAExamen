using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class AttributeValue
    {
        public Guid Id { get; set; }
        [ForeignKey("Attribute")]
        public string AttributeId { get; set; }
        public string Value { get; set; }

        public virtual Attribute Attribute { get; set; }
    }
}
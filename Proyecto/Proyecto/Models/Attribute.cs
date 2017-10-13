using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Attribute
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public ICollection<AttributeValue> AttributeValue { get; set; }
    }
}
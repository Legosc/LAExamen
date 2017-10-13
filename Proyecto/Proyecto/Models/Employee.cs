using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Employee
    {
        public Guid id { get; set; }
        [ForeignKey("Contact")]
        public string UserId { get; set; }
        public bool Actived { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Client
    {
        public Guid id { get; set; }
        [ForeignKey("Contact")]
        public string UserId { get; set; }
        public virtual Contact Contact { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual WishList WishList { get; set; }
    }
}
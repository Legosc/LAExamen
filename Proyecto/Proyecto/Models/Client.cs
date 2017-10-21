using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Contact")]
        public string UserId { get; set; }
        public virtual ApplicationUser Contact { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<WishList> WishListes { get; set; }
    }
}
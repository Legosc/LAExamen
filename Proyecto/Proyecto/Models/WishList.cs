using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Total { get; set; }

        public virtual ICollection<ProductVariant> ProductVariant { get; set; }

    }
}
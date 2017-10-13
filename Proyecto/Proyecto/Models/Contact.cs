using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Contact : IdentityUser
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
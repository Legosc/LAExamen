using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Tienda
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public Sale Sale { get; set; }
        public Client Client { get; set; }
    }
}
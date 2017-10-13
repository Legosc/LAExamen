using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string FatherCategory { get; set; }
       
    }
}
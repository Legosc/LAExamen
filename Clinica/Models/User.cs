using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string password { get; set; }

        public bool enabled { get; set; }
        
    }
 
}
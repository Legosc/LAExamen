using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public bool Actived { get; set; }
        [ForeignKey("Contact")]
        public string UserId { get; set; }
        public virtual ApplicationUser Contact { get; set; }

       
        public virtual ICollection<Sale> Sales { get; set; }
    }
    public class EmployeeViewModel
    {
        public bool Actived { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public EmployeeViewModel()
        {
            
        }
        public Employee ToModel()
        {
            var employe = new Employee();
            employe.UserId = this.UserId;
            employe.Actived = this.Actived;

            return employe;
        }
    }
}
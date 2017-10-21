using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
        public char State { get; set; }
        public DateTime SaleDate { get; set; }
        public double Total { get; set; }


        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<SaleLine> SaleLines { get; set; }
    }
}
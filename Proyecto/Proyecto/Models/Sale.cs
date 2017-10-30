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
        
        public ICollection<SaleLine> SaleLine { get; set; }
        
    }
    public class SaleViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int? EmployeeId { get; set; }
        public TimestampAttribute TimeStamp { get; set; }
        public States State { get; set; }
        public DateTime SaleDate { get; set; }
        public enum States { F, B, P }
        public List<SaleLineLineViewModel> SaleLine { get; set; }
        public decimal Total()
        {
            return SaleLine.Sum(x => x.Amount());
        }

    }
    

}
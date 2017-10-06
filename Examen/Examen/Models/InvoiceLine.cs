using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class InvoiceLine
    {
        [Key]
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Product Product { get; set; }
    }
    #region ViewModels
    public partial class InvoiceLineViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Retirar { get; set; }
        public decimal Amount()
        {
            return Quantity * UnitPrice;
        }
    }
    #endregion
}
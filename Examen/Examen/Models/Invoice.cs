using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Examen.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        public Invoice()
        {
            InvoiceLine = new List<InvoiceLine>();
        }

        public int id { get; set; }

        [Required]
        public int ContactId { get; set; }

        public decimal Total { get; set; }

        public DateTime Creado { get; set; }

        public virtual List<InvoiceLine> InvoiceLine { get; set; }
        public virtual Contact Contact { get; set; }
    }
    #region ViewModels
    public class InvoiceViewModel
    {
        #region Cabecera
        public int ContactId { get; set; }
        public int HeaderProductId { get; set; }
        public string HeaderProductName { get; set; }
        public int HeaderProductQuantity { get; set; }
        public decimal HeaderProductPrice { get; set; }
        #endregion

        #region Contenido
        public List<InvoiceLineViewModel> InvoiceLine { get; set; }
        #endregion

        #region Pie
        public decimal Amount()
        {
            return InvoiceLine.Sum(x => x.Amount());
        }
        public DateTime Creado { get; set; }
        #endregion

        public InvoiceViewModel()
        {
            InvoiceLine = new List<InvoiceLineViewModel>();
            Refrescar();
        }

        public void Refrescar()
        {
            HeaderProductId = 0;
            HeaderProductName = null;
            HeaderProductQuantity = 1;
            HeaderProductPrice = 0;
        }

        public bool SeAgregoUnProductoValido()
        {
            return !(HeaderProductId == 0 || string.IsNullOrEmpty(HeaderProductName) || HeaderProductQuantity == 0 || HeaderProductPrice == 0);
        }

        public bool ExisteEnDetalle(int ProductId)
        {
            return InvoiceLine.Any(x => x.ProductId == ProductId);
        }

        public void RetirarItemDeDetalle()
        {
            if (InvoiceLine.Count > 0)
            {
                var detalleARetirar = InvoiceLine.Where(x => x.Retirar)
                                                        .SingleOrDefault();

                InvoiceLine.Remove(detalleARetirar);
            }
        }

        public void AgregarItemADetalle()
        {
            InvoiceLine.Add(new InvoiceLineViewModel
            {
                ProductId = HeaderProductId,
                ProductName = HeaderProductName,
                UnitPrice = HeaderProductPrice,
                Quantity = HeaderProductQuantity,
            });

            Refrescar();
        }

        public Invoice ToModel()
        {
            var Invoice = new Invoice();
            Invoice.ContactId = this.ContactId;
            Invoice.Creado = DateTime.Now;
            Invoice.Total = this.Amount();

            foreach (var d in InvoiceLine)
            {
                Invoice.InvoiceLine.Add(new InvoiceLine
                {
                    ProductId = d.ProductId,
                    Amount = d.Amount(),
                    UnitPrice = d.UnitPrice,
                    Quantity = d.Quantity
                });
            }

            return Invoice;
        }
    }
    #endregion
}
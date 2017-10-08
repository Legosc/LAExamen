using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Examen.Models.Logics
{
    public class InvoiceLogic
    {
        public bool Registrar(Invoice Invoice)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(Invoice).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Invoice Obtener(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                
                return context.Invoice.Include(x => x.InvoiceLine.Select(y => y.Product))
                                          .Where(x => x.id == id)
                                          .SingleOrDefault();
            }
        }

        public List<Invoice> Listar()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Invoice.OrderByDescending(x => x.Creado)
                                          .ToList();
            }
        }
    }
}
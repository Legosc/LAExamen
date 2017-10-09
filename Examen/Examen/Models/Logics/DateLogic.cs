using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Examen.Models.Logics
{
    public class DateLogic
    {
        public bool Registrar(Date Date)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(Date).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
       
    }
}
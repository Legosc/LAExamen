using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto.Models.Logics
{
    public class EmployeesLogic
    {
        public bool Registrar(Employee Employee)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(Employee).State = EntityState.Added;
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
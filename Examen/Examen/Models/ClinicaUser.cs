using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class ClinicaUser : IdentityUser
    {
        public virtual List<Date> Date { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Examen.Models
{
    public class Date
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  UserId { get; set; }
        [Required]
        public int ContactId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Reservation { get; set; }
        public string Details { get; set; }
        public int Duration { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hour { get; set; }
        public bool IsConfirmed { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual Contact Contact { get; set; }
    }
    #region ViewModel
    public class DateViewModel
    {
        public int ContactId { get; set; }
        public string NameContact { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Reservation { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hour { get; set; }
        [Range(30,480,ErrorMessage ="Debe ser un valor de 30 a 480")]
        public int Duration { get; set; }
        public string Details { get; set; }
        public bool IsConfirmed { get; set; }
        public DateViewModel()
        {
            Refrescar();
        }

        private void Refrescar()
        {
            Reservation = DateTime.Now;
            Hour = DateTime.Now;
        }

        public bool SeAgregoFechaValida()
        {
             int values;
        
            using (var context = new ApplicationDbContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                List<Date> Dates = context.Dates.OrderBy(x => x.Reservation)
                                          .Where(x => x.Reservation.Equals(Reservation))
                                          .ToList();
                values = (from val in Dates
                             where val.Hour <= Hour || val.Hour.AddMinutes(val.Duration) >= Hour
                             select val).Count();


            }
            
            return !(Reservation < DateTime.Now || ContactId == 0 || Duration <= 0 || values > 0 || (Hour < (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,8,0,0)) && Hour > (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0))) );
        }
        public Date ToModel()
        {
            var user = HttpContext.Current.User.Identity.GetUserId();
            var Date = new Date();
            Date.ContactId = this.ContactId;
            Date.UserId = user;
            Date.Details = this.Details;
            Date.Reservation = this.Reservation;
            Date.Duration = this.Duration;
            Date.Hour = this.Hour;
            Date.IsConfirmed = this.IsConfirmed;
            return Date;
        }
    }
    #endregion
}
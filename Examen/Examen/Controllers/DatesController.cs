using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen.Models;
using Examen.Models.Logics;

namespace Examen.Controllers
{
    public class DatesController : Controller
    {
        private ContactLogic cl = new ContactLogic();
        private DateLogic dl = new DateLogic();
        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult BuscarContacto(string nombre)
        {
            return Json(cl.Buscar());
        }
        // GET: Dates
        public ActionResult Index()
        {
            var dates = db.Dates.Include(d => d.Contact).Include(d => d.User);
            return View(dates.ToList());
        }

        // GET: Dates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // GET: Dates/Create
        public ActionResult Create()
        {

            return View(new DateViewModel());
        }

        // POST: Dates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DateViewModel model, string action)
        {
            if (model.SeAgregoFechaValida())
            {
                if (dl.Registrar(model.ToModel()))
                {
                    return Redirect("~/Dates");
                }
            }
            else {
                ModelState.AddModelError("Create", "Esta fecha no es valida o ya no se encuentra disponible");
            }
            
            return View(model);
        }

        // GET: Dates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", date.ContactId);
            ViewBag.UserId = new SelectList(db.IdentityUser, "Id", "Email", date.UserId);
            return View(date);
        }

        // POST: Dates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ContactId,Reservation,Details,Duration,Hour,IsConfirmed")] Date date)
        {
            if (ModelState.IsValid)
            {
                db.Entry(date).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", date.ContactId);
            ViewBag.UserId = new SelectList(db.IdentityUser, "Id", "Email", date.UserId);
            return View(date);
        }

        // GET: Dates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Date date = db.Dates.Find(id);
            db.Dates.Remove(date);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

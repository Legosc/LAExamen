using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using Proyecto.Models.Logics;

namespace Proyecto.Controllers
{
    public class CategoriesController : Controller
    {
        public IEnumerable<CategoryViewModel> categoresvews;
        private CategoriLogic cl = new CategoriLogic();
        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult BuscarCategorias()
        {
            return Json(cl.Buscar());
        }
        public JsonResult VerificaCat(int Idcat)
        {
            return Json(cl.VerifCategoria(Idcat));
        }
        // GET: Categories
        public ActionResult Index()
        {
            List<CategoryViewModel> innerFinal = (from l in db.Categories
                       from r in db.Categories
                       where l.FatherCategoryID == r.Id
                       select new CategoryViewModel { Id = l.Id, Name = l.Name, FatherCategoryID = r.Id, FatherCategoryName = r.Name }).ToList()
                ;
            return View(innerFinal);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {

            return View(new CategoryViewModel());
        }

        // POST: Categories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            if(category.FatherCategoryID != null)
            {
                if (cl.VerifCategoria(category.FatherCategoryID ?? default(int)))
                {
                    if (ModelState.IsValid)
                    {
                        
                        db.Categories.Add(category.ToModel());
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(category.ToModel());
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FatherCategoryID")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

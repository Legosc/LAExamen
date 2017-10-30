using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using System.Data.Entity.Core.Objects;

namespace Proyecto.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            
            return View(new ProductViewModel());
        }
        public  JsonResult AddProductAsync(string Name, int? CategoryId)
        {
            Product product = new Product();
            int guardado;
            if (Name != "")
            {
                product.Name = Name;
                product.CategoryId = CategoryId;
                db.Products.Add(product);
                guardado =  db.SaveChanges();
            }
            return Json(product);
        }
        public JsonResult AddVariant(int Id, int ProductId, int Price)
        {
            
            ProductVariant ProductVariant = new ProductVariant();
            ProductVariant.ProductId = ProductId;
            ProductVariant.Price = Price;
            int guardado;
            
                if (Id == 0)
                {
                    
                    db.Variants.Add(ProductVariant);
                    guardado = db.SaveChanges();
                    return Json(ProductVariant);
                }
                else
                {
                ProductVariant.Id = Id;
                db.Entry(ProductVariant).State = EntityState.Modified;
                db.SaveChanges();
                return Json(ProductVariant);
            }
        }
        public JsonResult FindAttribute(string AttributeName)
        {

            Models.Attribute Attribute = (from a in db.Attributes
                                          select a).ToList().Find(x => x.Description == AttributeName);
            return Json(Attribute);
        }
        public JsonResult AddAttribute(string AttributeName)
        {

            Models.Attribute Attribute = new Models.Attribute();
            Attribute.Description = AttributeName;
            db.Attributes.Add(Attribute);
            db.SaveChanges();
            return Json(Attribute);
        }

        public JsonResult FindValueAttribute(int AttributeId, string AttributeValue)
        {

            AttributeValue Value = (from a in db.AttributeValues
                                    where a.AttributeId == AttributeId
                                    select a).ToList().Find(x => x.Value == AttributeValue);
            if (Value != null)
            {
                return Json(Value.Id);
            }
            return Json(Value);
        }
        public JsonResult AddValueAttribute(int AttributeId, string AttributeValue)
        {

            AttributeValue Value = new AttributeValue();
            Value.AttributeId = AttributeId;
            Value.Value = AttributeValue;
            db.AttributeValues.Add(Value);
            db.SaveChanges();
            return Json(Value);
        }
        public JsonResult AddVarriantAtribute(int AttributeValueId, int VariantId)
        {

            VariantAttribute model = new VariantAttribute();
            model.VariantId = VariantId;
            model.AttributeValueId = AttributeValueId;
            db.VariantAttributes.Add(model);
            db.SaveChanges();
            return Json(model);
        }
        public JsonResult DeleteVariant(int ProductVariantId)
        {
            ProductVariant ProductVariant = db.Variants.Find(ProductVariantId);
            db.Variants.Remove(ProductVariant);
            db.SaveChanges();
            return Json(ProductVariant);
        }

        public JsonResult DeleteAttribute(int VarriantAtributeId)
        {
            VariantAttribute ProductVariant = db.VariantAttributes.Find(VarriantAtributeId);
            db.VariantAttributes.Remove(ProductVariant);
            db.SaveChanges();
            return Json(ProductVariant);
        }
        public JsonResult EditVariant(int Varriant)
        {
            var obj = (from p in db.Variants
                       select new
                       {
                           p.Id,
                           p.ProductId,
                           p.Price,
                           atributos = (from v in db.VariantAttributes
                                        join av in db.AttributeValues on v.AttributeValueId equals av.Id
                                        join aa in db.Attributes on av.AttributeId equals aa.Id
                                        where v.VariantId == p.Id
                                        select new
                                        {
                                            v.Id,
                                            aa.Description,
                                            av.Value
                                        })
                       }).ToList().Find(x => x.Id == Varriant);
            return Json(obj);
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId")] ProductViewModel product, string action)
        {
            if (action == "Create")
            {
                if (product.Id == 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Products.Add(product.ToModel());
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(product.ToModel()).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

            }
            if (action == "Variant")
            {
                ProductVariant ProductVariant = new ProductVariant();
                ProductVariant.ProductId = product.Id;
                ProductVariant.Price = product.Price;
                int guardado;

                if (product.VariantId == 0)
                {
                    db.Variants.Add(ProductVariant);
                    guardado = db.SaveChanges();
                } else
                {
                    ProductVariant.Id = product.VariantId;
                    db.Entry(ProductVariant).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            var categoria = (from c in db.Categories

                             select new { c.Id, c.Name }).ToList().Find(x => x.Id == product.CategoryId);
            product.CategoryName = categoria.Name;
            product.ProductVariants = (from pv in db.Variants
                                       where pv.ProductId == product.Id
                                       join p in db.Products on pv.ProductId equals p.Id into ss
                                       from s in ss.DefaultIfEmpty()
                                       orderby pv.Price
                                       select new ProductVariantViewModel
                                       {
                                           Id = pv.Id,
                                           Price = pv.Price,
                                           ProductName = s == null ? "(No Product)" : s.Name
                                       }).ToList();
            return View(product);
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ProductViewModel model = new ProductViewModel();
            model.Id = product.Id;
            model.Name = product.Name;
            model.CategoryId = product.CategoryId;
            model.ProductVariants = (from pv in db.Variants
                                     where pv.ProductId == id
                                     join p in db.Products on pv.ProductId equals p.Id into ss
                                     from s in ss.DefaultIfEmpty()
                                     orderby pv.Price
                                     select new ProductVariantViewModel
                                     {
                                         Id = pv.Id,
                                         Price = pv.Price,
                                         ProductName = s == null ? "(No Product)" : s.Name
                                     }).ToList();
            var categoria = (from c in db.Categories

                             select new { c.Id, c.Name }).ToList().Find(x => x.Id == product.CategoryId);

            model.CategoryName = categoria.Name;
            return View(model);
        }
        
        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId")] ProductViewModel product, string action)
        {
            if (action == "Create")
            {
                
                    if (ModelState.IsValid)
                    {
                        db.Entry(product.ToModel()).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                

            }
            if (action == "Variant")
            {
                ProductVariant ProductVariant = new ProductVariant();
                ProductVariant.ProductId = product.Id;
                ProductVariant.Price = product.Price;
                int guardado;

                if (product.VariantId == 0)
                {
                    db.Variants.Add(ProductVariant);
                    guardado = db.SaveChanges();
                }
                else
                {
                    ProductVariant.Id = product.VariantId;
                    db.Entry(ProductVariant).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            product.ProductVariants = (from p in db.Variants
                                       where p.ProductId == product.Id
                                       select new ProductVariantViewModel
                                       {
                                           Id = p.Id,
                                           ProductId = p.ProductId,
                                           Price = p.Price
                                       }).ToList();
            return View(product);
        }
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

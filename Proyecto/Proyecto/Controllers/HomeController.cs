using Newtonsoft.Json;
using Proyecto.Models;
using Proyecto.Models.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
   
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CategoriLogic cl = new CategoriLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string ListCategories()
        {
            List<Category> categories = db.Categories.ToList();
            cl.CategoryList(categories);
            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }
    }
}
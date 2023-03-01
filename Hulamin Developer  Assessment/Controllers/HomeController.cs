using Hulamin_Developer__Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hulamin_Developer__Assessment.Controllers
{
    public class HomeController : Controller
    {
        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();
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
        public ActionResult Dashboard()
        {
            ViewBag.CountCategories = db.Categories.ToList().FindAll(x => x.IsDeleted == false).Count;
            ViewBag.Products = db.Products.ToList().FindAll(x => x.IsDeleted == false).Count;
            ViewBag.Suppliers = db.Suppliers.ToList().FindAll(x => x.IsDeleted == false).Count;
            return View();
        }
    }
}
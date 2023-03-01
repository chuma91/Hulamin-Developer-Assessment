using Hulamin_Developer__Assessment.Models;
using Hulamin_Developer__Assessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hulamin_Developer__Assessment.Controllers
{
    public class ProductsController : Controller
    {
        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();
        ProductBusinessLogic productBusiness = new ProductBusinessLogic();
        // GET: Products
        public ActionResult GetAllProducts()
        {
            return View(productBusiness.GetAllProducts());
        }


        //Remove Products
        [HttpPost]
        public ActionResult RemoveProduct(int Id)
        {
            Boolean result = productBusiness.RemoveProcuctById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            Product result = productBusiness.GetProductById(Id);
            TempData["ID"] = Id;

            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(ProductsViewModel productsViewModel)
        {
            Boolean result = productBusiness.UpdateProductById(productsViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers.ToList().Where(x => x.IsDeleted == false), "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().Where(x => x.IsDeleted == false), "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductsViewModel productsViewModel)
        {
            Boolean result = productBusiness.AddNewProduct(productsViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
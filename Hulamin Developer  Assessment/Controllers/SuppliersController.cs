using Hulamin_Developer__Assessment.BusinessLogic;
using Hulamin_Developer__Assessment.ViewModels;
using Hulamin_Developer__Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hulamin_Developer__Assessment.Controllers
{
    public class SuppliersController : Controller
    {
        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();
        SupplierBusinessLogic supplierBusiness = new SupplierBusinessLogic();
        // GET: Products
        public ActionResult GetAllSuppliers()
        {
            return View(supplierBusiness.GetAllSuppliers());
        }

        //Remove Suppliers
        [HttpPost]
        public ActionResult RemoveSupplier(int Id)
        {
            Boolean result = supplierBusiness.RemoveSupplierById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditSupplier(int Id)
        {
            Supplier result = supplierBusiness.GetSupplierById(Id);
            TempData["ID"] = Id;

            return View(result);
        }
        [HttpPost]
        public ActionResult EditSupplier(SupplierViewModel supplierViewModel)
        {
            Boolean result = supplierBusiness.UpdateSupplierById(supplierViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(SupplierViewModel supplierViewModel)
        {
            Boolean result = supplierBusiness.AddNewSupplier(supplierViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
using Hulamin_Developer__Assessment.BusinessLogic;
using Hulamin_Developer__Assessment.Models;
using Hulamin_Developer__Assessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hulamin.Controllers
{
    public class CategoriesController : Controller
    {
        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();
        CategoryBusinessLogic categoryBusiness = new CategoryBusinessLogic();
        // GET: Categories
        public ActionResult GetAllCategories()
        {
            return View(categoryBusiness.GetAllCategories());
        }

        public ActionResult Show(int id)
        {
            byte[] imageData = db.Categories.ToList().FirstOrDefault(x => x.CategoryID == id).Picture;

            if (imageData != null && imageData.Length > 0)
            {
                return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
            }
            return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
        }
        //Remove Categories
        [HttpPost]
        public ActionResult RemoveCategory(int Id)
        {
            Boolean result = categoryBusiness.RemoveCategoryById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditCategory(int Id)
        {
            Category result = categoryBusiness.GetCategoryById(Id);
            TempData["ID"] = Id;

            return View(result);
        }
        [HttpPost]
        public ActionResult EditCategory(CategoriesViewModel categoriesViewModel)
        {
            Boolean result = categoryBusiness.UpdateCategoriesById(categoriesViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoriesViewModel categoriesViewModel)
        {
            Boolean result = categoryBusiness.AddNewCategories(categoriesViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
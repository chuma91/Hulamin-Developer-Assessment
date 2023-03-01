using Hulamin_Developer__Assessment.Models;
using Hulamin_Developer__Assessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hulamin_Developer__Assessment.BusinessLogic
{
    public class CategoryBusinessLogic
    {

        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();
        public List<Category> GetAllCategories()
    {
        List<Category> cat = new List<Category>();
        try
        {
                cat = db.GetAllCategoriesFromDatabase().ToList();
            }
        catch (Exception ex)
        {
            return null;
        }

        return cat;
    }
    public bool RemoveCategoryById(int CategoryId)
    {
        bool result = false;
        try
        {
            var Find = db.Categories.ToList().FirstOrDefault(x => x.CategoryID == CategoryId && x.IsDeleted == false);
            if (Find != null)
            {
                Find.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }
        }
        catch (Exception ex)
        {

        }

        return result;
    }

    public Category GetCategoryById(int CategoryId)
    {
        Category category = new Category();
        try
        {
            category = db.Categories.ToList().FirstOrDefault(x => x.CategoryID == CategoryId && x.IsDeleted == false);
        }
        catch
        {
            return null;
        }
        return category;
    }

    public bool UpdateCategoriesById(CategoriesViewModel categoriesViewModel)
    {
        bool result = false;
        try
        {
            var Find = db.Categories.ToList().FirstOrDefault(x => x.CategoryID == categoriesViewModel.CategoryID && x.IsDeleted == false);
            if (Find != null)
            {
                Find.CategoryName = categoriesViewModel.CategoryName;
                Find.Description = categoriesViewModel.Description;
                db.SaveChanges();
                result = true;
            }
        }
        catch (Exception ex)
        {

        }

        return result;
    }

    public bool AddNewCategories(CategoriesViewModel categoriesViewModel)
    {
        bool result = false;
        try
        {
            Category obj = new Category();
            obj.CategoryName = categoriesViewModel.CategoryName;
            obj.Description = categoriesViewModel.Description;
            obj.IsDeleted = false;

            db.Categories.Add(obj);
            db.SaveChanges();
            result = true;
        }
        catch (Exception ex)
        {

        }

        return result;
    }
    
    }
}
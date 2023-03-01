using System;
using System.Collections.Generic;
using System.Linq;
using Hulamin_Developer__Assessment.Models;
using Hulamin_Developer__Assessment.ViewModels;
namespace Hulamin_Developer__Assessment
{
    public class ProductBusinessLogic
    {
        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();

        public List<Product> GetAllProducts()
        {
            List<Product> pro = new List<Product>();
            try
            {
                pro = db.GetAllProductsFromDatabase().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return pro;
        }

        public bool RemoveProcuctById(int ProductId)
        {
            bool result = false;
            try
            {
                var Find = db.Products.ToList().FirstOrDefault(x => x.ProductID == ProductId && x.IsDeleted == false);
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

        public Product GetProductById(int ProductId)
        {
            Product product = new Product();
            try
            {
                product = db.Products.ToList().FirstOrDefault(x => x.ProductID == ProductId && x.IsDeleted == false);
            }
            catch
            {
                return null;
            }
            return product;
        }

        public bool UpdateProductById(ProductsViewModel productsViewModel)
        {
            bool result = false;
            try
            {
                var Find = db.Products.ToList().FirstOrDefault(x => x.ProductID == productsViewModel.ProductID && x.IsDeleted == false);
                if (Find != null)
                {
                    Find.ProductName = productsViewModel.ProductName;
                    Find.QuantityPerUnit = productsViewModel.QuantityPerUnit;

                    Find.UnitPrice = Convert.ToDecimal(productsViewModel.UnitPrice);
                    Find.UnitsInStock = Convert.ToInt16(productsViewModel.UnitInStock);

                    Find.UnitsOnOrder = Convert.ToInt16(productsViewModel.UnitOnOrder);
                    Find.ReorderLevel = Convert.ToInt16(productsViewModel.ReorderLevel);
                    Find.Discontinued = productsViewModel.Discontinued;

                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool AddNewProduct(ProductsViewModel productsViewModel)
        {
            bool result = false;
            try
            {
                Product obj = new Product();
                obj.ProductName = productsViewModel.ProductName;
                obj.SupplierID = productsViewModel.SuppliersID;
                obj.CategoryID = productsViewModel.CategoryID;
                obj.QuantityPerUnit = productsViewModel.QuantityPerUnit;
                obj.UnitPrice = productsViewModel.UnitPrice;
                obj.UnitsInStock = Convert.ToInt16(productsViewModel.UnitInStock);
                obj.UnitsOnOrder = Convert.ToInt16(productsViewModel.UnitOnOrder);
                obj.Discontinued = productsViewModel.Discontinued;
                obj.ReorderLevel = Convert.ToInt16(productsViewModel.ReorderLevel);
                obj.IsDeleted = false;

                db.Products.Add(obj);
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
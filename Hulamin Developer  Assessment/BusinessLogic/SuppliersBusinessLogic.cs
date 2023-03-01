using Hulamin_Developer__Assessment.Models;
using Hulamin_Developer__Assessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hulamin.BusinessLogic
{
    public class SuppliersBusinessLogic
    {
        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> sup = new List<Supplier>();
            try
            {
                sup = db.GetAllSuppliersFromDatabase().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return sup;
        }

        public bool RemoveSupplierById(int SupplierId)
        {
            bool result = false;
            try
            {
                var Find = db.Suppliers.ToList().FirstOrDefault(x => x.SupplierID == SupplierId && x.IsDeleted == false);
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

        public Supplier GetSupplierById(int SupplierId)
        {
            Supplier supplier = new Supplier();
            try
            {
                supplier = db.Suppliers.ToList().FirstOrDefault(x => x.SupplierID == SupplierId && x.IsDeleted == false);
            }
            catch
            {
                return null;
            }
            return supplier;

        }
        public bool UpdateSupplierById(SupplierViewModel supplierViewModel)
        {
            bool result = false;
            try
            {
                var Find = db.Suppliers.ToList().FirstOrDefault(x => x.SupplierID == supplierViewModel.SupplierID && x.IsDeleted == false);
                if (Find != null)
                {
                    Find.CompanyName = supplierViewModel.CompanyName;
                    Find.ContactName = supplierViewModel.ContactName;

                    Find.ContactTitle = supplierViewModel.ContactTitle;
                    Find.Address = supplierViewModel.Address;
                    Find.City = supplierViewModel.City;
                    Find.Region = supplierViewModel.Region;
                    Find.PostalCode = supplierViewModel.PostalCode;
                    Find.Country = supplierViewModel.Country;
                    Find.Phone = supplierViewModel.Phone;
                    Find.Fax = supplierViewModel.Fax;
                    Find.HomePage = supplierViewModel.HomePage; 

                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool AddNewSupplier(SupplierViewModel supplierViewModel)
        {
            bool result = false;
            try
            {
                Supplier obj = new Supplier();
                obj.CompanyName = supplierViewModel.CompanyName;
                obj.ContactName = supplierViewModel.ContactName;

                obj.ContactTitle = supplierViewModel.ContactTitle;
                obj.Address = supplierViewModel.Address;
                obj.City = supplierViewModel.City;
                obj.Region = supplierViewModel.Region;
                obj.PostalCode = supplierViewModel.PostalCode;
                obj.Country = supplierViewModel.Country;
                obj.Phone = supplierViewModel.Phone;
                obj.Fax = supplierViewModel.Fax;
                obj.HomePage = supplierViewModel.HomePage;


                obj.IsDeleted = false;

                db.Suppliers.Add(obj);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hulamin_Developer__Assessment.ViewModels
{
    public class ProductsViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SuppliersID { get; set; }
        public string SuppliersName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }

        public int UnitOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
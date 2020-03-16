using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShop.Core.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
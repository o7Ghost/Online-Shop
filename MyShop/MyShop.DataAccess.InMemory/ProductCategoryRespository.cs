using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRespository
    {

        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productsCat;

        public ProductCategoryRespository()
        {
            productsCat = cache["productsCat"] as List<ProductCategory>;

            if (productsCat == null)
            {
                productsCat = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productsCat"] = productsCat;
        }

        public void Insert(ProductCategory p)
        {
            productsCat.Add(p);
        }

        public void Update(ProductCategory productCat)
        {
            ProductCategory productToUpDate = productsCat.Find(p => p.Id == productCat.Id);

            if (productToUpDate != null)
            {
                productToUpDate = productCat;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory product = productsCat.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productsCat.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory product = productsCat.Find(p => p.Id == Id);

            if (product != null)
            {
                productsCat.Remove(product);
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }
    }
}

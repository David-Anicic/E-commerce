using EP2_2.DAL.Interfaces;
using EP2_2.Data;
using EP2_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.DAL
{
    public class ProductDAL : IProductDAL
    {
        private readonly ApplicationDbContext _contex;

        public ProductDAL(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public List<Product> GetAllProducts()
        {
            return _contex.Products.Include(x => x.Category).ToList();
        }

        public List<Product> BestBuyProducts()
        {
            return GetAllProducts().OrderByDescending(x => x.NumberOfOrders).ToList();
        }

        public Product GetProductDetailsByProductID(int productID)
        {
            return GetAllProducts().Where(x => x.ProductID == productID).FirstOrDefault();
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            return GetAllProducts().Where(x => x.CategoryID == categoryID).OrderBy(x => x.Name).ToList();
        }

        public List<Product> NewestProducts()
        {
            return GetAllProducts().OrderByDescending(x => x.DateCreate).ToList();
        }

        public List<Product> PreferredProducts()
        {
            return GetAllProducts().Where(x => x.IsPrefered == true).ToList();
        }

        public void CreateProduct(Product product)
        {
            _contex.Products.Add(product);
            _contex.SaveChanges();
        }
    }
}

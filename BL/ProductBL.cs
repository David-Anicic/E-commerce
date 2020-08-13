using EP2_2.BL.Interfaces;
using EP2_2.DAL.Interfaces;
using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.BL
{
    public class ProductBL : IProductBL
    {
        private readonly IProductDAL _iProductDAL;
        public ProductBL(IProductDAL iProductDAL)
        {
            _iProductDAL = iProductDAL;
        }

        public List<Product> BestBuyProducts()
        {
            return _iProductDAL.BestBuyProducts();
        }

        public void CreateProduct(Product product)
        {
            _iProductDAL.CreateProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _iProductDAL.GetAllProducts();
        }

        public Product GetProductDetailsByProductID(int productID)
        {
            return _iProductDAL.GetProductDetailsByProductID(productID);
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            return _iProductDAL.GetProductsByCategory(categoryID);
        }

        public List<Product> NewestProducts()
        {
            return _iProductDAL.NewestProducts();
        }

        public List<Product> PreferredProducts()
        {
            return _iProductDAL.PreferredProducts();
        }

        public List<Product> SearchProducts(List<Product> products, string search)
        {
            search = search.ToLower();
            return products.Where(x => x.Name.ToLower().Contains(search) ||
            x.ShortDescription.ToLower().Contains(search) ||
            x.LongDescription.ToLower().Contains(search) ||
            x.Category.CategoryName.ToLower().Contains(search)).ToList();
        }
    }
}

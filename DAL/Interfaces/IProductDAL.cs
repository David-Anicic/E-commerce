using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.DAL.Interfaces
{
    public interface IProductDAL
    {
        List<Product> GetAllProducts();
        List<Product> PreferredProducts();
        List<Product> NewestProducts();
        List<Product> BestBuyProducts();
        List<Product> GetProductsByCategory(int categoryID);
        Product GetProductDetailsByProductID(int productID);
        void CreateProduct(Product product);
    }
}

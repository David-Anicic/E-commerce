using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.BL.Interfaces
{
    public interface IProductBL
    {
        List<Product> GetAllProducts();
        List<Product> PreferredProducts();
        List<Product> NewestProducts();
        List<Product> BestBuyProducts();
        List<Product> GetProductsByCategory(int categoryID);
        List<Product> SearchProducts(List<Product> products, string search);
        Product GetProductDetailsByProductID(int productID);
        void CreateProduct(Product product);
    }
}

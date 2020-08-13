using EP2_2.BL.Interfaces;
using EP2_2.Models;
using EP2_2.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.UI
{
    public class ProductUI : IProductUI
    {
        private readonly IProductBL _iProductBL;

        public ProductUI(IProductBL iproductBL)
        {
            _iProductBL = iproductBL;
        }

        public List<Product> BestBuyProducts()
        {
            return _iProductBL.BestBuyProducts();
        }

        public void CreateProduct(Product product)
        {
            _iProductBL.CreateProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _iProductBL.GetAllProducts();
        }

        public Product GetProductDetailsByProductID(int productID)
        {
            return _iProductBL.GetProductDetailsByProductID(productID);
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            return _iProductBL.GetProductsByCategory(categoryID);
        }

        public List<Product> NewestProducts()
        {
            return _iProductBL.NewestProducts();
        }

        public List<Product> PreferredProducts()
        {
            return _iProductBL.PreferredProducts();
        }

        public List<Product> SearchProducts(List<Product> products, string search)
        {
            return _iProductBL.SearchProducts(products, search);
        }
    }
}

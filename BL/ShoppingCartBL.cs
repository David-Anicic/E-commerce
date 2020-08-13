using EP2_2.DAL.Interfaces;
using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.BL.Interfaces
{
    public class ShoppingCartBL : IShoppingCartBL
    {
        private IShoppingCartDAL _iShoppingCartDAL;
        private IProductDAL _iProductDAL;

        public ShoppingCartBL(IShoppingCartDAL iShoppingCartDAL,IProductDAL iproductDAL)
        {
            _iShoppingCartDAL = iShoppingCartDAL;
            _iProductDAL = iproductDAL;
        }

        public void AddToCart(int productID, int amount, string shoppingCartID)
        {
            var product = _iProductDAL.GetProductDetailsByProductID(productID);
            _iShoppingCartDAL.AddToCart(product, amount, shoppingCartID);
        }

        public void ClearCart(string shoppingCartID)
        {
            _iShoppingCartDAL.ClearCart(shoppingCartID);
        }

        public decimal GetShopingCartTotal(string ShoppingCartID)
        {
            return _iShoppingCartDAL.GetShopingCartTotal(ShoppingCartID);
        }

        public List<ShoppingCartItem> GetShoppingCartItems(string ShoppingCartID)
        {
            return _iShoppingCartDAL.GetShoppingCartItems(ShoppingCartID);
        }

        public int RemovedFromCart(Product product, string shoppingCartID)
        {
             return _iShoppingCartDAL.RemovedFromCart(product, shoppingCartID);
        }
    }
}

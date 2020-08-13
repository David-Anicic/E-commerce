using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.DAL.Interfaces
{
    public interface IShoppingCartDAL
    {
        void AddToCart(Product product, int amount, string shoppingCartID);
        decimal GetShopingCartTotal(string shoppingCartID);
        List<ShoppingCartItem> GetShoppingCartItems(string shoppingCartID);
        int RemovedFromCart(Product product, string shoppingCartID);
        void ClearCart(string shoppingCartID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.Models;

namespace EP2_2.BL.Interfaces
{
     public interface IShoppingCartBL
    {
        void AddToCart(int productID, int amount, string shoppingCartID);
        decimal GetShopingCartTotal(string shoppingCartID);
        List<ShoppingCartItem> GetShoppingCartItems(string shoppingCartID);
        int RemovedFromCart(Product product, string shoppingCartID);
        void ClearCart(string shoppingCartID);
    }
}

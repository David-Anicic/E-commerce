using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.Models;

namespace EP2_2.UI
{
    public interface IShoppingCartUI
    {
        void AddToCart(int productID, int amount);
        decimal GetShopingCartTotal();
        List<ShoppingCartItem> GetShoppingCartItems();
        int RemovedFromCart(Product product);
        void ClearCart();
       
    }
}

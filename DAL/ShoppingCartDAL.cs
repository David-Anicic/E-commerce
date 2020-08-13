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
    public class ShoppingCartDAL : IShoppingCartDAL
    {
        private ApplicationDbContext _contex;

        public ShoppingCartDAL(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public void AddToCart(Product product, int amount, string ShoppingCartID)
        {
            if (_contex.ShoppingCarts.Where(x => x.ShoppingCartID == ShoppingCartID).Count() == 0)
            {
                ShoppingCart sc = new ShoppingCart();
                sc.ShoppingCartID = ShoppingCartID;
                _contex.ShoppingCarts.Add(sc);
            }

            var shoppingCartItem =
               _contex.ShoppingCartItems.SingleOrDefault(s => s.Product.ProductID == product.ProductID && s.ShoppingCartID == ShoppingCartID);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartID = ShoppingCartID,
                    Product = product,
                    Amount = 1
                };
                _contex.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _contex.SaveChanges();
        }

        public void ClearCart(string shoppingCartID)
        {
            var cartItems = _contex.ShoppingCartItems.Where(cart => cart.ShoppingCartID == shoppingCartID);
            _contex.ShoppingCartItems.RemoveRange(cartItems);
            _contex.SaveChanges();
           
        }

        public decimal GetShopingCartTotal(string ShoppingCartID)
        {
            var total = _contex.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartID)
              .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }

        public List<ShoppingCartItem> GetShoppingCartItems(string ShoppingCartID)
        {
            return _contex.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartID)
                   .Include(s => s.Product)
                   .ToList();
        }

        public int RemovedFromCart(Product product, string ShoppingCartID)
        {
            var shoppingCartItem =
            _contex.ShoppingCartItems.SingleOrDefault(s => s.Product.ProductID == product.ProductID && s.ShoppingCartID == ShoppingCartID);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {

                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;

                }
                else
                {
                    _contex.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _contex.SaveChanges();
            return localAmount;
        }

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.BL.Interfaces;
using EP2_2.Models;
using Microsoft.AspNetCore.Http;

namespace EP2_2.UI
{
    public class ShoppingCartUI : IShoppingCartUI
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IShoppingCartBL _iShoppingCartBL;
        public const string CartSessionKey = "CartId";
        public string ShoppingCartID { get; set; }

        public ShoppingCartUI(IShoppingCartBL IShoppingCartBL, IHttpContextAccessor HttpContextAccessor)
        {
            _iShoppingCartBL = IShoppingCartBL;
            _httpContextAccessor = HttpContextAccessor;

        }

        public string GetCart()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext.User.Identity.Name))
                {
                    _httpContextAccessor.HttpContext.Session.SetString(CartSessionKey, _httpContextAccessor.HttpContext.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    _httpContextAccessor.HttpContext.Session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }
            var ShoppingCartID = _httpContextAccessor.HttpContext.Session.GetString(CartSessionKey);
            return ShoppingCartID;
        }

        public void AddToCart(int productID, int amount)
        {
            ShoppingCartID = GetCart();
            _iShoppingCartBL.AddToCart(productID, amount, ShoppingCartID);
        }

        public decimal GetShopingCartTotal()
        {
            ShoppingCartID = GetCart();
            return _iShoppingCartBL.GetShopingCartTotal(ShoppingCartID);
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            ShoppingCartID = GetCart();
            return _iShoppingCartBL.GetShoppingCartItems(ShoppingCartID);
        }

        public int RemovedFromCart(Product product)
        {
            ShoppingCartID = GetCart();
            return _iShoppingCartBL.RemovedFromCart(product, ShoppingCartID);
        }

        public void ClearCart()
        {
            ShoppingCartID = GetCart();
            _iShoppingCartBL.ClearCart(ShoppingCartID);
        }
    }
}

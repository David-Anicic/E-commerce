using EP2_2.BL;
using EP2_2.BL.Interfaces;
using EP2_2.Models;
using EP2_2.UI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EP2_2.UI
{
    public class OrderUI : IOrderUI
    {
        private readonly IOrderBL _IOrderBL;
        private readonly IShoppingCartUI _IShoppingCartUI;

        public OrderUI(IOrderBL _IOrderBL, IShoppingCartUI _IShoppingCartUI)
        {
            this._IOrderBL = _IOrderBL;
            this._IShoppingCartUI = _IShoppingCartUI;
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return _IOrderBL.GetOrderItems(orderID);
        }

        public List<Order> GetPreviousOrders(string userID, string search)
        {
            return _IOrderBL.GetPreviousOrders(userID,search);
        }

        public void PayLater(string userID)
        {
            var items = _IShoppingCartUI.GetShoppingCartItems();
            _IOrderBL.CreateOrder(userID,items, _IShoppingCartUI.GetShopingCartTotal(), false);
            _IShoppingCartUI.ClearCart();
            
        }

        public void PayNow(string userID)
        {
            var items = _IShoppingCartUI.GetShoppingCartItems();
            var shopingCartTotal = _IShoppingCartUI.GetShopingCartTotal();
            _IOrderBL.CreateOrder(userID, items, shopingCartTotal, true);
            _IShoppingCartUI.ClearCart();
        }
    }
}

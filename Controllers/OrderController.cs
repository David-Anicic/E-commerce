using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EP2_2.Models;
using EP2_2.Models.ViewModels;
using EP2_2.UI;
using EP2_2.UI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EP2_2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderUI _IOrderUI;
        //private readonly IShoppingCartUI _IShoppingCartUI;

        public OrderController(IOrderUI IOrderUI/*, IShoppingCartUI _IshoppingCartUI*/)
        {
            _IOrderUI = IOrderUI;
        }

        public IActionResult PayLater()
        {
            var userID = this.GetUserID();
            if (!string.IsNullOrEmpty(userID))
            {
                _IOrderUI.PayLater(userID);
            }
            else
                return RedirectToAction("LogIn", "Account");

            return RedirectToAction("Index","Home");
        }

        public IActionResult PayNow()
        {
            var userID = this.GetUserID();
            if (!string.IsNullOrEmpty(userID))
            {
                _IOrderUI.PayNow(userID);
            }
            else
                return RedirectToAction("LogIn", "Account");

            return RedirectToAction("Index", "Home");
        }

        public string GetUserID()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public IActionResult PreviousOrders(string search = "")
        {
            string userID = GetUserID();
            var orders = _IOrderUI.GetPreviousOrders(userID, search);
            OrdersListViewModel olVM = new OrdersListViewModel();
            olVM.Orders = orders;
  
            return View(olVM);
        }
        public IActionResult OrderItems(int id, decimal total)
        {
            OrdersListItemsViewModel orderListItems = new OrdersListItemsViewModel();
            orderListItems.OrderItems = _IOrderUI.GetOrderItems(id);
            orderListItems.Total = total;
            return View(orderListItems);
        }

    }
}

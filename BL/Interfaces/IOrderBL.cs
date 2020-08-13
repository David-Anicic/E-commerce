using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.BL
{
    public interface IOrderBL
    {
        void CreateOrder(string userID, List<ShoppingCartItem> items, decimal total, bool payed);
        List<OrderItem> GetOrderItems(int orderID);
        List<Order> GetPreviousOrders(string userID, string search);
    }
}

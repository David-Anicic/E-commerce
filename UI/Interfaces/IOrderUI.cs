using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.UI.Interfaces
{
    public interface IOrderUI
    {
        void PayLater(string userID);
        void PayNow(string userID);
        List<Order> GetPreviousOrders(string userID, string search);
        List<OrderItem> GetOrderItems(int orderID);
    }
}

using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.DAL.Interfaces
{
    public interface IOrderDAL
    {
        ApplicationUser GetUserByID(string userID);
        List<OrderItem> GetOrderItems(int orderID);
        List<Order> GetPreviousOrders(string userID, string search);
        void CreateOrder(string userID, List<OrderItem> items,decimal total, bool payed);
    }
}

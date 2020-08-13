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
    public class OrderDAL : IOrderDAL
    {
        public enum Status : byte { Pending, Shipped, Delivery };
        private readonly ApplicationDbContext _contex;

        public OrderDAL (ApplicationDbContext _contex)
        {
            this._contex = _contex;
        }

        public void CreateOrder(string userID, List<OrderItem> items,decimal total, bool payed)
        {
                    Order order = new Order();
                    order.User = this.GetUserByID(userID);
                    order.Paied = payed;
                    order.OrderPlaced =  DateTime.Now;
                    order.OrderStatus = Status.Pending.ToString();
                    order.OrderItems = items;
                    order.OrderTotal = total;
                    
                    
                    _contex.Orders.Add(order);
                    _contex.SaveChanges();
        }

        public ApplicationUser GetUserByID(string userID)
        {
            return _contex.Users.Where(x => x.Id == userID).FirstOrDefault();
        }

        public List<Order> GetPreviousOrders(string userID, string search)
        {
            IEnumerable<Order> result;
            search = search.ToLower();
            result = _contex.Orders.Include(x=>x.OrderItems).ThenInclude(x => x.Product).Include(x => x.OrderItems).Where(x => x.User.Id == userID);
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.OrderStatus.ToLower().Contains(search) || x.OrderItems.Any(y=>y.Product.Name.ToLower().Contains(search)));
            }

            return result.ToList();
            
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return _contex.OrderItems.Include(x=>x.Product).Where(x => x.Order.OrderID == orderID).ToList();
        }
    }
}

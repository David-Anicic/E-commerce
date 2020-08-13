using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.DAL.Interfaces;
using EP2_2.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace EP2_2.BL
{
    public class OrderBL : IOrderBL
    {

        private readonly IOrderDAL _IOrderDAL;

        public OrderBL(IOrderDAL _IOrderDAL)
        {
            this._IOrderDAL = _IOrderDAL;
        }

        public void CreateOrder(string userID, List<ShoppingCartItem> items,decimal total, bool payed)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach(var item in items)
            {
                orderItems.Add(new OrderItem { Amount = item.Amount, Product = item.Product });
            }
           
           _IOrderDAL.CreateOrder(userID, orderItems,total, payed);
            this.SendEmail(_IOrderDAL.GetUserByID(userID), orderItems, payed);
       
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return _IOrderDAL.GetOrderItems(orderID);
        }

        public List<Order> GetPreviousOrders(string userID, string search)
        {
            return _IOrderDAL.GetPreviousOrders(userID, search);
        }

        public void SendEmail(ApplicationUser user, List<OrderItem> orderItems, bool payed)
        {
            string text = "Hi " + user.UserName + ",\n" ;
            foreach (var item in orderItems)
            {
                text += "Product Name: " + item.Product.Name + " Product Price: " + item.Product.Price + " Amount: " + item.Amount + "\n";
            }
            text += "-------------------------------------------------------\n";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tehno shop", "lanamilj@gmail.com"));
            message.To.Add(new MailboxAddress("User", user.Email));
            message.Subject = "Order Details";
            message.Body = new TextPart("plain")
            {
                Text = text
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("lanamilj@gmail.com", "Password");
                client.Send(message);
                client.Disconnect(true);
            }
            
        }
    }
}

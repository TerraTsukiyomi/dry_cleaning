using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryCleaning.Domain.Abstract;
using DryCleaning.Domain.Entities;

namespace DryCleaning.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.Name = order.Name;
                    dbEntry.Adress = order.Adress;
                    dbEntry.Telephone = order.Telephone;
                    dbEntry.Thing = order.Thing;
                    dbEntry.Category = order.Category;
                    dbEntry.Price = order.Price;
                }
            }
            context.SaveChanges();
        }

        public Order DeleteOrder(int orderID)
        {
            Order dbEntry = context.Orders.Find(orderID);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleaning.Domain.Entities
{
   
 public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Order order, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Order.OrderID == order.OrderID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Order = order,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Order order)
        {
            lineCollection.RemoveAll(l => l.Order.OrderID == order.OrderID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Order.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
    public class CartLine
    {
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}


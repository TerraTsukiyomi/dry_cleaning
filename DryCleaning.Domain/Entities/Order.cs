using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleaning.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public string Thing { get; set; }

        public string Category { get; set; }
        public decimal Price { get; set; }

    }
}

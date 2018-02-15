using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DryCleaning.Domain.Entities;

namespace DryCleaning.WebUI.Models
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DryCleaning.Domain.Abstract;
using DryCleaning.Domain.Entities;
using DryCleaning.WebUI.Models;

namespace DryCleaning.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        public int PageSize = 4;
        public OrderController(IOrderRepository orderRepository)
        {
            this.repository = orderRepository;
        }

        public ViewResult List(int page = 1)
        {
            OrdersListViewModel model = new OrdersListViewModel
            {
                Orders = repository.Orders
                 .OrderBy(p => p.OrderID)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Orders.Count()
                }
            };
            return View(model);
        }
    }
}
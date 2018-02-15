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

        public ViewResult List(string category, int page = 1)
        {
            OrdersListViewModel model = new OrdersListViewModel
            {
                Orders = repository.Orders
                .Where(p => category == null || p.Category == category)
                 .OrderBy(p => p.OrderID)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Orders.Count() :
                    repository.Orders.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
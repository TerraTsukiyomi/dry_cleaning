using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DryCleaning.Domain.Abstract;
using DryCleaning.Domain.Entities;

namespace DryCleaning.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        public OrderController(IOrderRepository orderRepository)
        {
            this.repository = orderRepository;
        }

        public ViewResult List()
        {
            return View(repository.Orders);
        }
    }
}
using DryCleaning.Domain.Abstract;
using DryCleaning.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DryCleaning.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IOrderRepository repository;
        public AdminController(IOrderRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Orders);
        }
        public ViewResult Edit(int orderId)
        {
            Order order = repository.Orders
            .FirstOrDefault(p => p.OrderID == orderId);
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOrder(order);
                TempData["message"] = string.Format("{0} сохранено", order.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(order);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Order());
        }

        [HttpPost]
        public ActionResult Delete(int orderId)
        {
            Order deletedOrder = repository.DeleteOrder(orderId);
            if (deletedOrder != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedOrder.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
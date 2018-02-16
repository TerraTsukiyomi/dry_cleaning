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
    public class CartController : Controller
    {
        private IOrderRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IOrderRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }
        public ViewResult Inde(Cart cart, string returnUrl)
        {
            return View(new CartIndeViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int orderId, string returnUrl)
        {
            Order order = repository.Orders.FirstOrDefault(p => p.OrderID ==
           orderId);
            if (order != null)
            {
                cart.AddItem(order, 1);
            }
            return RedirectToAction("Inde", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int orderId, string
returnUrl)
        {
            Order order = repository.Orders.FirstOrDefault(p => p.OrderID ==
           orderId);
            if (order != null)
            {
                cart.RemoveLine(order);
            }
            return RedirectToAction("Inde", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Пустой!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

    }
}
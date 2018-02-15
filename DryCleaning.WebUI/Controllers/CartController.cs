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
        public CartController(IOrderRepository repo)
        {
            repository = repo;
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

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

    }
}
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

        public ViewResult Inde(string returnUrl)
        {
            return View(new CartIndeViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int orderId, string returnUrl)
        {
            Order order = repository.Orders
                .FirstOrDefault(p => p.OrderID == orderId);
            if (order != null)
            {
                GetCart().AddItem(order, 1);
            }
            return RedirectToAction("Inde", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int orderId, string returnUrl)
        {
            Order order = repository.Orders
            .FirstOrDefault(p => p.OrderID == orderId);
            if (order != null)
            {
                GetCart().RemoveLine(order);
            }
            return RedirectToAction("Inde", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
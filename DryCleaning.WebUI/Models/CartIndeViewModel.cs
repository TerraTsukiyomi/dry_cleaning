using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DryCleaning.Domain.Entities;

namespace DryCleaning.WebUI.Models
{
    public class CartIndeViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
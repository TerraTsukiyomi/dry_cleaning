using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DryCleaning.Domain.Entities
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя, фамили, отчество")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите телефон")]
        public string Telephone { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Пожалуйста, введите вещ")]
        public string Thing { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите вид стирки")]
        public string Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите стоимость")]
        public decimal Price { get; set; }

    }
}

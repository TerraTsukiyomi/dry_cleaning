using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DryCleaning.Domain.Entities
{
        public class ShippingDetails
        {
            [Required(ErrorMessage = "Пожалуйста введите имя клиента")]
            public string Client { get; set; }

            [Required(ErrorMessage = "Пожалуйста введите услугу")]
            public string Service { get; set; }
            public string Clothes { get; set; }
            public string Defect { get; set; }

            [Required(ErrorMessage = "Пожалуйста введите дату принятия заказа")]
            public DateTime Data_in { get; set; }

            [Required(ErrorMessage = "Пожалуйста введите плановую дату выполнения заказа")]
            public DateTime Data_plan { get; set; }
            public DateTime Data_comp { get; set; }

            [Required(ErrorMessage = "Введите стоимость")]
            public string Price { get; set; }
            public bool GiftWrap { get; set; }
    }
    
}

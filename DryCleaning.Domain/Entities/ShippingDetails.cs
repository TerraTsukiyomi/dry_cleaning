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
            [Required(ErrorMessage = "Please enter a name")]
            public string Client { get; set; }

            [Required(ErrorMessage = "Please enter the first address line")]
            public string Service { get; set; }
            public string Clothes { get; set; }
            public string Defect { get; set; }

            [Required(ErrorMessage = "Please enter a city name")]
            public DateTime Data_in { get; set; }

            [Required(ErrorMessage = "Please enter a state name")]
            public DateTime Data_plan { get; set; }
            public DateTime Data_comp { get; set; }

            [Required(ErrorMessage = "Please enter a country name")]
            public string Price { get; set; }
        }
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendApp.Models
{
    public class RestaurantType
    {
        public int RestaurantTypeID { get; set; }

        [StringLength(255)]
        public string? RestaurantTypeName { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
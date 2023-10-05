using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendApp.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        public int RestaurantTypeID { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        public RestaurantType RestaurantType { get; set; }
        public IEnumerable<RestaurantMenu> RestaurantMenus { get; set; }
    }

}
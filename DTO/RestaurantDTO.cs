using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendApp.DTO
{
    public class RestaurantDTO
    {
         public int RestaurantID { get; set; }

        public int RestaurantTypeID { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? RestaurantTypeName { get; set; }

    }
}
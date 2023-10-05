using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendApp.DTO
{
    public class RestaurantDTO
    {
        public int RestaurantTypeID { get; set; }

        public string? RestaurantTypeName { get; set; }

        public int RestaurantID { get; set; }


        public string? Name { get; set; }

        public string? Deskripsi { get; set; }

        public List<RestaurantMenu> RestaurantMenus { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendApp.Models
{
    public class RestaurantMenu
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantMenuID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(255)]
        public string? MenuName { get; set; }   

        public Restaurant Restaurant { get; set; }

    }
}
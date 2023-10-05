using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBackendApp.DTO;
using MyBackendApp.Services;

namespace MyBackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurant _restaurantService;
        public RestaurantsController(IRestaurant restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult<RestaurantGetDTO>> Get()
        {
            var restaurants = await _restaurantService.GetAll();

            var results = restaurants.Select(r => new RestaurantGetDTO
            {
                RestaurantID = r.RestaurantID,
                Name = r.Name
            });

            return Ok(results);
        }
    }
}
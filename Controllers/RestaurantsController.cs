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
        private readonly IConfiguration _configuration;
        public RestaurantsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<RestaurantDTO> Get()
        {
            MysqlRestaurantData mysqlRestaurantData = new MysqlRestaurantData(_configuration);
            var results = mysqlRestaurantData.GetAll();
            return Ok(results);
        }
    }
}
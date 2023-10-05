using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using MyBackendApp.Authorization;
using MyBackendApp.DTO;
using MyBackendApp.Services;

namespace MyBackendApp.Controllers
{
    [Authorize]
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
        public ActionResult Get()
        {
            MysqlRestaurantData mysqlRestaurantData = new MysqlRestaurantData(_configuration);
            var results = mysqlRestaurantData.GetAll();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            MysqlRestaurantData mysqlRestaurantData = new MysqlRestaurantData(_configuration);
            var result = mysqlRestaurantData.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(RestaurantDTO restaurant)
        {
            MysqlRestaurantData mysqlRestaurantData = new MysqlRestaurantData(_configuration);
            try
            {
                var result = mysqlRestaurantData.Create(restaurant);

                return Ok(result);
                //return Ok(restaurant.RestaurantMenus[0].MenuName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, RestaurantDTO restaurant)
        {
            MysqlRestaurantData mysqlRestaurantData = new MysqlRestaurantData(_configuration);
            try
            {
                var result = mysqlRestaurantData.Update(id, restaurant);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            MysqlRestaurantData mysqlRestaurantData = new MysqlRestaurantData(_configuration);
            try
            {
                var result = mysqlRestaurantData.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyBackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private List<string> lstNama;
        public RestaurantsController()
        {
            lstNama = new List<string>()
            {
                "Erick","Rufus","Iroen","Ponco","Rizal"
            };
        }

        [HttpGet]
        public List<string> Get()
        {
            return lstNama;
        }

        [HttpGet("search/{name}")]
        public List<string> GetByName(string name)
        {
            return lstNama.Where(x => x.Contains(name)).ToList();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Nama : {lstNama[id]}";
        }
    }
}
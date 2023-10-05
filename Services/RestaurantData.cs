using Microsoft.EntityFrameworkCore;
using MyBackendApp.Data;
using MyBackendApp.Models;

namespace MyBackendApp.Services
{
    public class RestaurantData : IRestaurant
    {
        private readonly AppDbContext _appDbContext;
        public RestaurantData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<Restaurant> Add(Restaurant obj)
        {
            throw new NotImplementedException();
        }

        public Task<Restaurant> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Restaurant> Get(int id)
        {
            var restaurant = await _appDbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
                throw new Exception("Restaurant not found");
            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            var retaurants = await _appDbContext.Restaurants
                .OrderBy(r => r.Name).ToListAsync();

            return retaurants;
        }

        public Task<Restaurant> Update(Restaurant obj)
        {
            throw new NotImplementedException();
        }
    }
}
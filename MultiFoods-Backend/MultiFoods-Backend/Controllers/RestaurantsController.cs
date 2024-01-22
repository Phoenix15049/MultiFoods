using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiFoods_Backend.Controllers
{
    // RestaurantController.cs

    using Microsoft.AspNetCore.Mvc;
    using MultiFoods_Backend.Models;
    using MultiFoods_Backend.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantRepository _restaurantRepository;

        public RestaurantController(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantsDto>>> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantsDto>> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRestaurant(RestaurantsDto restaurant)
        {
            var restaurantId = await _restaurantRepository.CreateRestaurantAsync(restaurant);
            return Ok(restaurantId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRestaurant(int id, RestaurantsDto restaurant)
        {
            if (id != restaurant.Restaurant_ID)
            {
                return BadRequest();
            }

            var success = await _restaurantRepository.UpdateRestaurantAsync(restaurant);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var success = await _restaurantRepository.DeleteRestaurantAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}

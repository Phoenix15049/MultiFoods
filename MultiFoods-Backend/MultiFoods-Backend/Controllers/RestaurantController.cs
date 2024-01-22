using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiFoods_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MultiFoods_Backend.Models;

    [ApiController]
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantManagerRepository _restaurantManagerRepository;
        private readonly RestaurantRepository _restaurantRepository;

        public RestaurantController(
            RestaurantManagerRepository restaurantManagerRepository,
            RestaurantRepository restaurantRepository)
        {
            _restaurantManagerRepository = restaurantManagerRepository;
            _restaurantRepository = restaurantRepository;
        }

        [HttpPost("register-manager")]
        public IActionResult RegisterManager([FromBody] RestaurantManagerDTO manager)
        {
            _restaurantManagerRepository.RegisterManager(manager);
            return Ok(manager);
        }

        [HttpPost("register-restaurant")]
        public IActionResult RegisterRestaurant([FromBody] RestaurantDTO restaurant)
        {
            _restaurantRepository.RegisterRestaurant(restaurant);
            return Ok(restaurant);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] RestaurantManagerDTO manager)
        {
            var authenticatedManager = _restaurantManagerRepository.AuthenticateManager(manager);

            if (authenticatedManager == null)
                return Unauthorized("Invalid credentials");

            return Ok(authenticatedManager);
        }
    }

}

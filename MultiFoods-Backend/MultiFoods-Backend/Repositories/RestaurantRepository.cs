using Dapper;
using MultiFoods_Backend.Services;

namespace MultiFoods_Backend.Models
{
    public class RestaurantRepository
    {
        private readonly AppDbContext _dbContext;

        public RestaurantRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterRestaurant(RestaurantDTO restaurant)
        {
            using var dbConnection = _dbContext.GetConnection();
            const string query = "INSERT INTO Restaurants (Restaurant_Name, Address, Manager_ID) VALUES (@Restaurant_Name, @Address, @Manager_ID)";
            dbConnection.Execute(query, restaurant);
        }
    }
}

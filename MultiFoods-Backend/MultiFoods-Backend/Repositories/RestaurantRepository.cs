namespace MultiFoods_Backend.Repositories
{
    // RestaurantRepository.cs

    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using MultiFoods_Backend.Models;
    using Npgsql;

    public class RestaurantRepository
    {
        private readonly IDbConnection _dbConnection;

        public RestaurantRepository()
        {
            _dbConnection = new NpgsqlConnection("Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893"); ;
        }

        public async Task<IEnumerable<RestaurantsDto>> GetAllRestaurantsAsync()
        {
            return await _dbConnection.QueryAsync<RestaurantsDto>("SELECT * FROM Restaurants");
        }

        public async Task<RestaurantsDto> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<RestaurantsDto>("SELECT * FROM Restaurants WHERE Restaurant_ID = @RestaurantId", new { RestaurantId = restaurantId });
        }

        public async Task<int> CreateRestaurantAsync(RestaurantsDto restaurant)
        {
            const string query = "INSERT INTO Restaurants (Restaurant_Name, Address, PhoneNumber) VALUES (@Restaurant_Name, @Address, @PhoneNumber) RETURNING Restaurant_ID";
            return await _dbConnection.ExecuteScalarAsync<int>(query, restaurant);
        }

        public async Task<bool> UpdateRestaurantAsync(RestaurantsDto restaurant)
        {
            const string query = "UPDATE Restaurants SET Restaurant_Name = @Restaurant_Name, Address = @Address, PhoneNumber = @PhoneNumber WHERE Restaurant_ID = @Restaurant_ID";
            int affectedRows = await _dbConnection.ExecuteAsync(query, restaurant);
            return affectedRows > 0;
        }

        public async Task<bool> DeleteRestaurantAsync(int restaurantId)
        {
            const string query = "DELETE FROM Restaurants WHERE Restaurant_ID = @RestaurantId";
            int affectedRows = await _dbConnection.ExecuteAsync(query, new { RestaurantId = restaurantId });
            return affectedRows > 0;
        }
    }

}

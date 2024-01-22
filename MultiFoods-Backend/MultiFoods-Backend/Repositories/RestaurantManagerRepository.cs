using Dapper;
using MultiFoods_Backend.Services;

namespace MultiFoods_Backend.Models
{
    public class RestaurantManagerRepository

    {
        private readonly AppDbContext _dbContext;

        public RestaurantManagerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterManager(RestaurantManagerDTO manager)
        {
            using var dbConnection = _dbContext.GetConnection();
            const string query = "INSERT INTO RestaurantManagers (First_Name, Last_Name, Email, Phone, Restaurant_ID) VALUES (@First_Name, @Last_Name, @Email, @Phone, @Restaurant_ID)";
            dbConnection.Execute(query, manager);
        }

        public RestaurantManagerDTO AuthenticateManager(RestaurantManagerDTO manager)
        {
            using var dbConnection = _dbContext.GetConnection();
            const string query = "SELECT * FROM RestaurantManagers WHERE Email = @Email AND Phone = @Phone";
            return dbConnection.QueryFirstOrDefault<RestaurantManagerDTO>(query, manager);
        }

    }
}

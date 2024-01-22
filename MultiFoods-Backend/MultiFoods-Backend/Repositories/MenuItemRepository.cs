using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace MultiFoods_Backend.Models
{
    

    public class MenuItemRepository
    {
        private readonly IDbConnection _dbConnection;

        public MenuItemRepository(string connectionString)
        {
            connectionString = "Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893";
            _dbConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<MenuItemDTO> GetMenuItemsByNames(List<string> itemNames)
        {
            // Using Dapper's Query method to fetch menu items by names
            var menuItems = _dbConnection.Query<MenuItemDTO>(
                "SELECT * FROM MenuItems WHERE Item_Name IN @ItemNames",
                new { ItemNames = itemNames }
            );

            return menuItems;
        }
    }

}

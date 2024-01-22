namespace MultiFoods_Backend.Repositories
{
    // MenuRepository.cs

    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using MultiFoods_Backend.Models;
    using Npgsql;

    public class MenuRepository
    {
        private readonly IDbConnection _dbConnection;

        public MenuRepository()
        {
            _dbConnection = new NpgsqlConnection("Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893"); ;
        }

        // CRUD operations for Menus
        public async Task<IEnumerable<MenusDto>> GetAllMenusAsync()
        {
            return await _dbConnection.QueryAsync<MenusDto>("SELECT * FROM Menus");
        }

        public async Task<MenusDto> GetMenuByIdAsync(int menuId)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<MenusDto>("SELECT * FROM Menus WHERE Menu_ID = @MenuId", new { MenuId = menuId });
        }

        public async Task<int> CreateMenuAsync(MenusDto menu)
        {
            const string query = "INSERT INTO Menus (Restaurant_ID, Menu_Name) VALUES (@Restaurant_ID, @Menu_Name) RETURNING Menu_ID";
            return await _dbConnection.ExecuteScalarAsync<int>(query, menu);
        }

        public async Task<bool> UpdateMenuAsync(MenusDto menu)
        {
            const string query = "UPDATE Menus SET Restaurant_ID = @Restaurant_ID, Menu_Name = @Menu_Name WHERE Menu_ID = @Menu_ID";
            int affectedRows = await _dbConnection.ExecuteAsync(query, menu);
            return affectedRows > 0;
        }

        public async Task<bool> DeleteMenuAsync(int menuId)
        {
            const string query = "DELETE FROM Menus WHERE Menu_ID = @MenuId";
            int affectedRows = await _dbConnection.ExecuteAsync(query, new { MenuId = menuId });
            return affectedRows > 0;
        }

        // CRUD operations for MenuItems
        public async Task<IEnumerable<MenuItemsDto>> GetAllMenuItemsAsync()
        {
            return await _dbConnection.QueryAsync<MenuItemsDto>("SELECT * FROM MenuItems");
        }

        public async Task<MenuItemsDto> GetMenuItemByIdAsync(int menuItemId)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<MenuItemsDto>("SELECT * FROM MenuItems WHERE MenuItem_ID = @MenuItemId", new { MenuItemId = menuItemId });
        }

        public async Task<int> CreateMenuItemAsync(MenuItemsDto menuItem)
        {
            const string query = "INSERT INTO MenuItems (Menu_ID, Item_ID) VALUES (@Menu_ID, @Item_ID) RETURNING MenuItem_ID";
            return await _dbConnection.ExecuteScalarAsync<int>(query, menuItem);
        }

        public async Task<bool> DeleteMenuItemAsync(int menuItemId)
        {
            const string query = "DELETE FROM MenuItems WHERE MenuItem_ID = @MenuItemId";
            int affectedRows = await _dbConnection.ExecuteAsync(query, new { MenuItemId = menuItemId });
            return affectedRows > 0;
        }
    }

}

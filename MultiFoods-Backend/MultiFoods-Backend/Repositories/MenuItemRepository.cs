using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace MultiFoods_Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Npgsql;
    using System.Threading.Tasks;
    using System.Security.AccessControl;

    public class MenuItemRepository
    {
        private readonly string _connectionString = "Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Password=09331318893;Persist Security Info=True";
        public async Task<IEnumerable<MenuItemDTO>> GetAllMenuItems()
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            string sql = "SELECT * FROM MenuItems";
            var menuItems = await dbConnection.QueryAsync<MenuItemDTO>(sql);
            return menuItems;
        }

        public async Task<MenuItemDTO> GetMenuItemById(int menuItemID)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            string sql = "SELECT * FROM MenuItems WHERE MenuItem_ID = @MenuItemID";
            var menuItem = await dbConnection.QueryFirstOrDefaultAsync<MenuItemDTO>(sql, new { MenuItemID = menuItemID });
            return menuItem;
        }

        public async Task<int> CreateMenuItem(MenuItemDTO menuItem)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            string sql = @"INSERT INTO MenuItems (Item_Name, Description, Price, Category_ID, Menu_ID) 
                       VALUES (@Item_Name, @Description, @Price, @Category_ID, @Menu_ID) RETURNING MenuItem_ID";

            int menuItemID = await dbConnection.ExecuteScalarAsync<int>(sql, menuItem);
            return menuItemID;
        }

        public async Task<bool> UpdateMenuItem(MenuItemDTO menuItem)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            string sql = @"UPDATE MenuItems 
                       SET Item_Name = @Item_Name, Description = @Description, Price = @Price, 
                           Category_ID = @Category_ID, Menu_ID = @Menu_ID 
                       WHERE MenuItem_ID = @MenuItem_ID";

            int rowsAffected = await dbConnection.ExecuteAsync(sql, menuItem);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteMenuItem(int menuItemID)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            string sql = "DELETE FROM MenuItems WHERE MenuItem_ID = @MenuItemID";

            int rowsAffected = await dbConnection.ExecuteAsync(sql, new { MenuItemID = menuItemID });
            return rowsAffected > 0;
        }
    }





}

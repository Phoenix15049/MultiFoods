using Dapper;
using MultiFoods_Backend.Models;
using Npgsql;
using System.Data;

namespace MultiFoods_Backend.Repositories
{
    // ItemsRepository.cs

    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;

    public class ItemsRepository
    {
        private readonly IDbConnection _dbConnection;

        public ItemsRepository()
        {
            _dbConnection = new NpgsqlConnection("Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893"); ;
        }

        public async Task<IEnumerable<ItemsDto>> GetAllItemsAsync()
        {
            return await _dbConnection.QueryAsync<ItemsDto>("SELECT * FROM Items");
        }

        public async Task<ItemsDto> GetItemByIdAsync(int itemId)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<ItemsDto>("SELECT * FROM Items WHERE Item_ID = @ItemId", new { ItemId = itemId });
        }

        public async Task<int> CreateItemAsync(ItemsDto item)
        {
            const string query = "INSERT INTO Items (Item_Name, Price, Category_ID) VALUES (@Item_Name, @Price, @Category_ID) RETURNING Item_ID";
            return await _dbConnection.ExecuteScalarAsync<int>(query, item);
        }

        public async Task<bool> UpdateItemAsync(ItemsDto item)
        {
            const string query = "UPDATE Items SET Item_Name = @Item_Name, Price = @Price, Category_ID = @Category_ID WHERE Item_ID = @Item_ID";
            int affectedRows = await _dbConnection.ExecuteAsync(query, item);
            return affectedRows > 0;
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            const string query = "DELETE FROM Items WHERE Item_ID = @ItemId";
            int affectedRows = await _dbConnection.ExecuteAsync(query, new { ItemId = itemId });
            return affectedRows > 0;
        }
    }


}

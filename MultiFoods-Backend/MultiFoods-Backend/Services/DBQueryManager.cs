using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Npgsql;

namespace MultiFoods_Backend.Services
{
    public class DBQueryManager
    {
        private readonly string connectionString = "Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893";

        public async Task<IEnumerable<string>> GetAll(string sqlstring,int index)
        {
            try
            {
                await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();

                var sql = sqlstring;
                await using var cmd = new NpgsqlCommand(sql, connection);

                await using var reader = await cmd.ExecuteReaderAsync();

                var products = new List<string>();

                while (await reader.ReadAsync())
                {
                    // Adjust index based on your column order or use column names directly
                    var productName = reader.GetValue(index).ToString();
                    products.Add(productName);
                }

                return products;
            }
            catch (Exception ex)
            {
                var errors = new List<string>();
                errors.Add(ex.Message);
                return errors;
            }
        }

        
    }
}















//try
//{
//    await using var connection = new NpgsqlConnection(connectionString);
//    await connection.OpenAsync();

//    var sql = "SELECT * FROM products";
//    await using var cmd = new NpgsqlCommand(sql, connection);

//    await using var reader = await cmd.ExecuteReaderAsync();

//    var products = new List<string>();

//    while (await reader.ReadAsync())
//    {
//        // Adjust index based on your column order or use column names directly
//        var productName = reader.GetString(1);
//        products.Add(productName);
//    }

//    return Ok(products);
//}
//catch (Exception ex)
//{
//    return StatusCode(500, $"Error: {ex.Message}");
//}
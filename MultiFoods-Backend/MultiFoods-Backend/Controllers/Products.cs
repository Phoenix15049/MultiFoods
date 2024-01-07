using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Models;
using Npgsql;


namespace MultiFoods_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {

        private readonly string connectionString = "Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893";


        //GET+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetProducts()
        {
            try
            {
                await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();

                var sql = "SELECT * FROM products";
                await using var cmd = new NpgsqlCommand(sql, connection);

                await using var reader = await cmd.ExecuteReaderAsync();

                var products = new List<string>();

                while (await reader.ReadAsync())
                {
                    // Adjust index based on your column order or use column names directly
                    var productName = reader.GetString(1);
                    products.Add(productName);
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }



        //PUT+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductsDTO product)
        {
            try
            {
                await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();

                var sql = "UPDATE products SET product_name = @productName, product_price = @productPrice WHERE product_id = @productId";
                await using var cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@productName", product.product_name);
                cmd.Parameters.AddWithValue("@productPrice", product.product_price);
                cmd.Parameters.AddWithValue("@productId", id);

                var rowsAffected = await cmd.ExecuteNonQueryAsync();

                if (rowsAffected == 0)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        //POST+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] string productName)
        {
            try
            {
                await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();

                var sql = "INSERT INTO products (product_name) VALUES (@productName)";
                await using var cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("productName", productName);

                var rowsAffected = await cmd.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    return Ok("Product created successfully");
                }
                else
                {
                    return BadRequest("Failed to create product");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }



        //DELETE+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();

                var sql = "DELETE FROM products WHERE id = @productId";
                await using var cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("productId", id);

                var rowsAffected = await cmd.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    return Ok("Product deleted successfully");
                }
                else
                {
                    return NotFound("Product not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}

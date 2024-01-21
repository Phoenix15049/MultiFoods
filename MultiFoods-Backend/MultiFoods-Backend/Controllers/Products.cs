using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MultiFoods_Backend.Models;
using MultiFoods_Backend.Services;
using Npgsql;
using System.Security.AccessControl;


namespace MultiFoods_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {


        //private readonly string connectionString = "Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893";

        //public DBQueryManager dbqm = new DBQueryManager();

        ////GET+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //[HttpGet("GetProd/{id}")]
        //public async Task<ActionResult<List<ProductsDTO>>> GetProducts(int id)
        //{

        //    using (var connection = new NpgsqlConnection(connectionString))
        //    {
        //        // Create a query that retrieves all authors" 
        //        var sql = $"SELECT * FROM Products WHERE product_id = {id};";
        //        // Use the Query method to execute the query and return a list of objects
        //        List<ProductsDTO> products = connection.Query<ProductsDTO>(sql).ToList();
        //        return Ok(products);
        //    }

        //}



        ////PUT+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductsDTO product)
        //{
        //    try
        //    {
        //        await using var connection = new NpgsqlConnection(connectionString);
        //        await connection.OpenAsync();

        //        var sql = "UPDATE products SET product_name = @productName, product_price = @productPrice WHERE product_id = @productId";
        //        await using var cmd = new NpgsqlCommand(sql, connection);
        //        cmd.Parameters.AddWithValue("@productName", product.product_name);
        //        cmd.Parameters.AddWithValue("@productPrice", product.product_price);
        //        cmd.Parameters.AddWithValue("@productId", id);

        //        var rowsAffected = await cmd.ExecuteNonQueryAsync();

        //        if (rowsAffected == 0)
        //        {
        //            return NotFound();
        //        }

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error: {ex.Message}");
        //    }
        //}


        ////POST+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //[HttpPost]
        //public async Task<IActionResult> CreateProduct([FromBody] ProductsDTO product)
        //{
        //    try
        //    {
        //        await using var connection = new NpgsqlConnection(connectionString);
        //        await connection.OpenAsync();

        //        var sql = "INSERT INTO products (product_name, product_price) VALUES (@productName, @productPrice)";
        //        await using var cmd = new NpgsqlCommand(sql, connection);
        //        cmd.Parameters.AddWithValue("@productName", product.product_name);
        //        cmd.Parameters.AddWithValue("@productPrice", product.product_price);

        //        var rowsAffected = await cmd.ExecuteNonQueryAsync();

        //        if (rowsAffected == 0)
        //        {
        //            return StatusCode(500, "Error: Product creation failed.");
        //        }

        //        return StatusCode(201, "Product created successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error: {ex.Message}");
        //    }
        //}




        ////DELETE+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    try
        //    {
        //        await using var connection = new NpgsqlConnection(connectionString);
        //        await connection.OpenAsync();

        //        var sql = "DELETE FROM products WHERE product_id = @productId";
        //        await using var cmd = new NpgsqlCommand(sql, connection);
        //        cmd.Parameters.AddWithValue("@productId", id);

        //        var rowsAffected = await cmd.ExecuteNonQueryAsync();

        //        if (rowsAffected == 0)
        //        {
        //            return NotFound();
        //        }

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error: {ex.Message}");
        //    }
        //}


    }
}

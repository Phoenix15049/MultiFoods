using Dapper;
using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Models;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiFoods_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Foods : ControllerBase
    {
        private readonly string connectionString = "Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893";
        [HttpGet]
        public async Task<ActionResult<List<MenuItemRepository>>> GetProducts(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                // Create a query that retrieves all authors" 
                var sql = $"SELECT * FROM Products";
                // Use the Query method to execute the query and return a list of objects
                List<MenuItemRepository> items = connection.Query<MenuItemRepository>(sql).ToList();
                return Ok(items);
            }
        }


        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

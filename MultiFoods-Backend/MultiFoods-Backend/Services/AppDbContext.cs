using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace MultiFoods_Backend.Services
{
    public class AppDbContext
    {
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = "Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893";
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public IDbConnection GetConnection()
        {
            var connection = Connection;
            connection.Open();
            return connection;
        }
    }
}

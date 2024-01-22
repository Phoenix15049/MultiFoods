namespace MultiFoods_Backend.Repositories
{

    // OrdersRepository.cs

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using MultiFoods_Backend.Models;
    using Npgsql;

    public class OrdersRepository
    {
        public readonly IDbConnection _dbConnection;

        public OrdersRepository()
        {
            _dbConnection = new NpgsqlConnection("Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893"); ;
        }


        // Create Order and OrderDetails
        public async Task<int> CreateOrderAsync(OrdersDto order, List<OrderDetailsDto> orderDetails)
        {
            using (var connection = new NpgsqlConnection("Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Persist Security Info=True;Password=09331318893"))  // Replace _connectionString with your actual connection string
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert order
                        const string orderQuery = "INSERT INTO Orders (Customer_ID, Order_Date) VALUES (@Customer_ID, @Order_Date) RETURNING Order_ID";
                        order.Order_ID = await connection.ExecuteScalarAsync<int>(orderQuery, order, transaction);

                        // Insert order details
                        const string orderDetailsQuery = "INSERT INTO OrderDetails (Order_ID, Item_ID, Quantity) VALUES (@Order_ID, @Item_ID, @Quantity)";
                        foreach (var orderDetail in orderDetails)
                        {
                            orderDetail.Order_ID = order.Order_ID;
                            await connection.ExecuteAsync(orderDetailsQuery, orderDetail, transaction);
                        }

                        transaction.Commit();
                        return order.Order_ID;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }


}

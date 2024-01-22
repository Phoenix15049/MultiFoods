using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Npgsql;
namespace MultiFoods_Backend.Models
{
    using Dapper;
    using Npgsql;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateOrder(OrderDTO order, List<OrderItemDTO> orderItems)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert order
                        order.Order_ID = await connection.ExecuteScalarAsync<int>(
                            "INSERT INTO Orders (Customer_ID, OrderDate, TotalAmount) VALUES (@Customer_ID, @OrderDate, @TotalAmount) RETURNING Order_ID",
                            order, transaction);

                        // Insert order items
                        foreach (var orderItem in orderItems)
                        {
                            orderItem.Order_ID = order.Order_ID;
                            await connection.ExecuteAsync(
                                "INSERT INTO OrderItems (Order_ID, MenuItem_ID, Quantity, Subtotal) VALUES (@Order_ID, @MenuItem_ID, @Quantity, @Subtotal)",
                                orderItem, transaction);
                        }

                        transaction.Commit();
                        return order.Order_ID;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }



}

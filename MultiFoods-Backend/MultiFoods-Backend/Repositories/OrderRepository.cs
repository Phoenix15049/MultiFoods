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
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Microsoft.Extensions.Configuration;

    public class OrderRepository
    {
        public async Task<IEnumerable<OrderDTO>> GetOrdersByIds(IEnumerable<int> orderIds)
        {
            using IDbConnection dbConnection = new NpgsqlConnection("Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Password=09331318893;Persist Security Info=True");
            dbConnection.Open();

            // Use Dapper's Query method to fetch multiple orders by their IDs
            string query = "SELECT * FROM Orders WHERE Order_ID IN @OrderIds";
            var orders = await dbConnection.QueryAsync<OrderDTO>(query, new { OrderIds = orderIds });

            // Fetch associated menu items for each order
            await FetchMenuItemsForOrders(dbConnection, orders);

            return orders;
        }

        private async Task FetchMenuItemsForOrders(IDbConnection dbConnection, IEnumerable<OrderDTO> orders)
        {
            foreach (var order in orders)
            {
                string menuItemQuery = "SELECT * FROM OrderItems INNER JOIN MenuItems ON OrderItems.MenuItem_ID = MenuItems.MenuItem_ID WHERE Order_ID = @OrderId";
                var menuItems = await dbConnection.QueryAsync<MenuItemDTO>(menuItemQuery, new { OrderId = order.Order_ID });

                order.MenuItems = menuItems.ToList();
            }
        }


        public async Task<int> CreateOrder(OrderDTO order)
        {
            using IDbConnection dbConnection = new Npgsql.NpgsqlConnection("Port=1382;Host=localhost;Database=MultiFoodsBeta;Username=postgres;Password=09331318893;Persist Security Info=True");
            dbConnection.Open();

            using var transaction = dbConnection.BeginTransaction();

            try
            {
                // Insert order into the Orders table
                string orderInsertSql = @"INSERT INTO Orders (Customer_ID, OrderDate, TotalAmount) 
                                      VALUES (@Customer_ID, @OrderDate, @TotalAmount) RETURNING Order_ID";

                int orderId = await dbConnection.ExecuteScalarAsync<int>(orderInsertSql, new
                {
                    order.Customer_ID,
                    order.OrderDate,
                    order.TotalAmount
                }, transaction);

                // Insert order items into the OrderItems table
                string orderItemInsertSql = @"INSERT INTO OrderItems (Order_ID, MenuItem_ID) 
                                          VALUES (@Order_ID, @MenuItem_ID)";

                foreach (var menuItem in order.MenuItems)
                {
                    await dbConnection.ExecuteAsync(orderItemInsertSql, new
                    {
                        Order_ID = orderId,
                        MenuItem_ID = menuItem.MenuItem_ID
                    }, transaction);
                }

                transaction.Commit();

                return orderId;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }


}

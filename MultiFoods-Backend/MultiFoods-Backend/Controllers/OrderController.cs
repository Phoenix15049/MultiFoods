using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Models;
using MultiFoods_Backend.Repositories;
using System;
using System.Threading.Tasks;
using System;
using System.Linq;
namespace MultiFoods_Backend.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO createOrderDTO)
        {

            try
            {
                if (createOrderDTO == null)
                {
                    return BadRequest("Invalid payload");
                }

                // Check if MenuItems is null or empty
                if (createOrderDTO.MenuItems == null || createOrderDTO.MenuItems.Count == 0)
                {
                    return BadRequest("MenuItems cannot be null or empty");
                }
                // Create OrderDTO
                var order = new OrderDTO
                {
                    Customer_ID = createOrderDTO.Customer_ID,
                    OrderDate = DateTime.Now, // You might want to customize the order date logic
                    TotalAmount = createOrderDTO.MenuItems.Sum(item => item.Price) // Adjust the calculation based on your business logic
                };

                // Create OrderItems
                var orderItems = createOrderDTO.MenuItems.Select(item => new OrderItemDTO
                {
                    MenuItem_ID = item.MenuItem_ID,
                    Quantity = 1, // You might want to customize the quantity logic
                    Subtotal = item.Price // Adjust the calculation based on your business logic
                }).ToList();
                var orderId = await _orderRepository.CreateOrder(order, orderItems);
                return Ok(new { OrderId = orderId });

                //// Create the order
                //var orderId = await _orderRepository.CreateOrder(order, orderItems);
                //return Ok(new { OrderId = orderId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }


}

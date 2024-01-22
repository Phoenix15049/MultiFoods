namespace MultiFoods_Backend.Controllers
{

    // OrdersController.cs

    using Microsoft.AspNetCore.Mvc;
    using MultiFoods_Backend.Models;
    using MultiFoods_Backend.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersRepository _ordersRepository;

        public OrdersController(OrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderInputModel inputModel)
        {
            try
            {
                var orderId = await _ordersRepository.CreateOrderAsync(inputModel.Order, inputModel.OrderDetails);
                return Ok(orderId);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }



}

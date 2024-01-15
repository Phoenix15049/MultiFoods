using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Controllers;
using MultiFoods_Backend.Models;


namespace MFB_UnitTests
{
    public class UnitTest1
    {
        ProductsDTO sample = new ProductsDTO() { product_id = 6, product_name = "string", product_price = 0 };
        
        Products _controller;
        [Fact]
        public async Task GetProducts_ReturnsStatusCode200()
        {
            // Arrange
            var controller = new Products(); 

            // Act
            var result = await controller.GetProducts();

            // Assert
            var statusCodeResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsStatusCode204()
        {
            // Arrange
            var controller = new Products();

            // Act
            var result = await controller.UpdateProduct(10, sample); 

            // Assert
            var statusCodeResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ReturnsStatusCode201()
        {
            // Arrange
            var controller = new Products();

            // Act
            var result = await controller.CreateProduct(new ProductsDTO() { product_id = 253, product_name = "xx", product_price = 4 }); 

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsStatusCode204()
        {
            // Arrange
            var controller = new Products();

            // Act
            var result = await controller.DeleteProduct(27);

            // Assert
            var statusCodeResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, statusCodeResult.StatusCode);
        }


    }
}
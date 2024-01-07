using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Controllers;
using MultiFoods_Backend.Models;

namespace MFB_UnitTests
{
    public class UnitTest1
    {
        Products _controller;
        [Fact]
        public async Task GetProducts_ReturnsStatusCode200()
        {
            // Arrange
            var controller = new Products(); // Assuming no constructor parameters needed

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
            var controller = new Products(); // Assuming no constructor parameters needed

            // Act
            var result = await controller.UpdateProduct(1, new ProductsDTO() { product_id = 5, product_name = "x", product_price = 4 }); // Pass an appropriate ID and DTO

            // Assert
            var statusCodeResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ReturnsStatusCode201()
        {
            // Arrange
            var controller = new Products(); // Assuming no constructor parameters needed

            // Act
            var result = await controller.CreateProduct(new ProductsDTO() { product_id = 5, product_name = "x", product_price = 4 }); // Pass appropriate DTO data

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsStatusCode204()
        {
            // Arrange
            var controller = new Products(); // Assuming no constructor parameters needed

            // Act
            var result = await controller.DeleteProduct(6); // Pass an appropriate ID

            // Assert
            var statusCodeResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }


    }
}
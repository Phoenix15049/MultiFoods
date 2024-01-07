using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Controllers;

namespace MFB_UnitTests
{
    public class UnitTest1
    {
        Products _controller;



        [Fact]
        public void AllTests()
        {
            var result = _controller.GetProducts();
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(5, 5);
        }
    }
}
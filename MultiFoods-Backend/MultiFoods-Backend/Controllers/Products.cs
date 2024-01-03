using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiFoods_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        [HttpGet("Proc")]
        public string Getproducts()
        {
            return "No Product";
        }


    }
}

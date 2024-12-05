using Microsoft.AspNetCore.Mvc;
using EmpApplication.Models;



namespace EmpApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController :ControllerBase
    {

        [HttpGet("OrderQuery")]
        public IActionResult GetOrderQuery([FromQuery] int orderId)
        {
            // Simulate retrieved data (replace with your database logic)
            var order = new
            {
                OrderId = orderId,
                ProductId = 101,
                ProductName = "Laptop",
                Quantity = 2
            };

            return Ok(order);
        }

        [HttpPost("OrderByBody")]
        public IActionResult GetOrderByBody([FromBody] int orderId)
        {
            // Simulate retrieved data (replace with your database logic)
            var order = new
            {
                OrderId = orderId,
                ProductId = 202,
                ProductName = "Smartphone",
                Quantity = 1
            };

            return Ok(order);
        }
    }


   
    
   
    
}

    


using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Dto.Order;

namespace MinsCarsShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Order")]
        public async Task<IActionResult> Order()
        {
            var result = await _orderService.OrderAsync();
            if (result.StatusCode == 200)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}

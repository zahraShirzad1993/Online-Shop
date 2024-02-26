using Microsoft.AspNetCore.Mvc;
using Shop.Domain.DTOs.Order;
using Shop.Domain.Interfaces;

namespace Shop.WebApi.Controllers
{
    public class OrderController : Controller
    {
        #region Constructor
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion


        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderDto order)
        {
            var result = await _orderService.AddOrder(order);

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetOrderDetailById(int id)
        {
            var result = await _orderService.GetOrderDetailById(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using GTSErpSystem.Data;
using GTSErpSystem.Models;
using GTSErpSystem.BLL;
using System.Linq;

namespace GTSErpSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly Class_Orders _ordersService;

        public OrdersController(Class_Orders ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ordersService.GetPurchases());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order_Orders order)
        {
            var id = _ordersService.InsertOrder(order);
            return CreatedAtAction(nameof(Get), new { id = id }, order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = _ordersService.DeleteOrder(id);
            if (res == 0) return NotFound();
            return NoContent();
        }
    }
}

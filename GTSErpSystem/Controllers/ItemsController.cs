using Microsoft.AspNetCore.Mvc;
using GTSErpSystem.Data;
using GTSErpSystem.Models;
using System.Linq;

namespace GTSErpSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly GTSdbContext _db;

        public ItemsController(GTSdbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Item_Items.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _db.Item_Items.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Item_Items item)
        {
            _db.Item_Items.Add(item);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = item.ItemId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Item_Items updated)
        {
            var item = _db.Item_Items.Find(id);
            if (item == null) return NotFound();
            item.Item_code = updated.Item_code;
            item.item_Name = updated.item_Name;
            item.QuantityInStock = updated.QuantityInStock;
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _db.Item_Items.Find(id);
            if (item == null) return NotFound();
            _db.Item_Items.Remove(item);
            _db.SaveChanges();
            return NoContent();
        }
    }
}

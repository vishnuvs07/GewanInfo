using GewanInfo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GewanInfo.Controllers
{
    [Route("api/itemmasters")]
    [ApiController]
    public class ItemMastersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/itemmasters
        [HttpGet]
        public IActionResult GetItemMasters()
        {
            var itemMasters = _context.ItemMaster.ToList();
            return Ok(itemMasters);
        }

        // GET: api/itemmasters/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemMaster(int id)
        {
            var itemMaster = await _context.ItemMaster.FindAsync(id);

            if (itemMaster == null)
            {
                return NotFound();
            }

            return Ok(itemMaster);
        }

        // POST: api/itemmasters
        [HttpPost]
        public async Task<IActionResult> CreateItemMaster(ItemMaster itemMaster)
        {
            try
            {
                _context.ItemMaster.Add(itemMaster);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetItemMaster", new { id = itemMaster.Id }, itemMaster);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }
        }

        // PUT: api/itemmasters/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemMaster(int id, ItemMaster itemMaster)
        {
            if (id != itemMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/itemmasters/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemMaster(int id)
        {
            var itemMaster = await _context.ItemMaster.FindAsync(id);
            if (itemMaster == null)
            {
                return NotFound();
            }

            _context.ItemMaster.Remove(itemMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemMasterExists(int id)
        {
            return _context.ItemMaster.Any(e => e.Id == id);
        }
    }
}

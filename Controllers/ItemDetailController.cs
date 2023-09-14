using GewanInfo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GewanInfo.Controllers
{
    [Route("api/itemdetails")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/itemdetails/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemDetail(int id)
        {
            var itemDetail = await _context.ItemDetail.FindAsync(id);

            if (itemDetail == null)
            {
                return NotFound();
            }

            return Ok(itemDetail);
        }

        // POST: api/itemdetails
        [HttpPost]
        public async Task<IActionResult> CreateItemDetail(ItemDetail itemDetail)
        {
            try
            {
                _context.ItemDetail.Add(itemDetail);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetItemDetail", new { id = itemDetail.Id }, itemDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }
        }

        // PUT: api/itemdetails/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemDetail(int id, ItemDetail itemDetail)
        {
            if (id != itemDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailExists(id))
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

        // DELETE: api/itemdetails/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemDetail(int id)
        {
            var itemDetail = await _context.ItemDetail.FindAsync(id);
            if (itemDetail == null)
            {
                return NotFound();
            }

            _context.ItemDetail.Remove(itemDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemDetailExists(int id)
        {
            return _context.ItemDetail.Any(e => e.Id == id);
        }
    }
}

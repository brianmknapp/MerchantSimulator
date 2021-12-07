using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerchantSimulatorApi.Domain.Entities;
using MerchantSimulatorApi.Infrastructure.Database;

namespace MerchantSimulatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopItem>>> GetShopItems()
        {
            return await _context.ShopItems.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopItem>> GetShopItem(Guid id)
        {
            var shopItem = await _context.ShopItems.FindAsync(id);

            if (shopItem == null)
            {
                return NotFound();
            }

            return shopItem;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopItem(Guid id, ShopItem shopItem)
        {
            if (id != shopItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(shopItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopItem>> PostShopItem(ShopItem shopItem)
        {
            _context.ShopItems.Add(shopItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopItem", new { id = shopItem.Id }, shopItem);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopItem(Guid id)
        {
            var shopItem = await _context.ShopItems.FindAsync(id);
            if (shopItem == null)
            {
                return NotFound();
            }

            _context.ShopItems.Remove(shopItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopItemExists(Guid id)
        {
            return _context.ShopItems.Any(e => e.Id == id);
        }
    }
}

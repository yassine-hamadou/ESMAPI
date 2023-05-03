using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionMineAreaController : ControllerBase
    {
        private readonly EnpDBContext _context;

        public ProductionMineAreaController(EnpDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductionMineArea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionMineArea>>> GetProductionMineAreas()
        {
          if (_context.ProductionMineAreas == null)
          {
              return NotFound();
          }
            return await _context.ProductionMineAreas.ToListAsync();
        }

        // GET: api/ProductionMineArea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionMineArea>> GetProductionMineArea(int id)
        {
          if (_context.ProductionMineAreas == null)
          {
              return NotFound();
          }
            var productionMineArea = await _context.ProductionMineAreas.FindAsync(id);

            if (productionMineArea == null)
            {
                return NotFound();
            }

            return productionMineArea;
        }

        // PUT: api/ProductionMineArea/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionMineArea(int id, ProductionMineArea productionMineArea)
        {
            if (id != productionMineArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionMineArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionMineAreaExists(id))
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

        // POST: api/ProductionMineArea
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductionMineArea>> PostProductionMineArea(ProductionMineArea productionMineArea)
        {
          if (_context.ProductionMineAreas == null)
          {
              return Problem("Entity set 'EnpDBContext.ProductionMineAreas'  is null.");
          }
            _context.ProductionMineAreas.Add(productionMineArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionMineArea", new { id = productionMineArea.Id }, productionMineArea);
        }

        // DELETE: api/ProductionMineArea/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionMineArea(int id)
        {
            if (_context.ProductionMineAreas == null)
            {
                return NotFound();
            }
            var productionMineArea = await _context.ProductionMineAreas.FindAsync(id);
            if (productionMineArea == null)
            {
                return NotFound();
            }

            _context.ProductionMineAreas.Remove(productionMineArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductionMineAreaExists(int id)
        {
            return (_context.ProductionMineAreas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

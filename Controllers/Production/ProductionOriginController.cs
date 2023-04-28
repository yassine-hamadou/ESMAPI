using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionOrigin;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProductionOriginController : BaeApiController<ProductionOriginController>
    {
        private readonly EnpDBContext _context;
        public ProductionOriginController(EnpDBContext context)
        {
            _context = context;
        }

        //get list
        [HttpGet]
        [ProducesResponseType(typeof(ProductionOrigin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ProductionOrigin>> Get()
        {
            return await _context.ProductionOrigins.ToListAsync();
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProductionOrigin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var productionOrigin = await _context.ProductionOrigins.FindAsync(id);
            if (productionOrigin == null)
            {
                return NotFound();
            }
            return Ok(productionOrigin);
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(ProductionOrigin), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProductionOriginPostDto productionOriginPostDto)
        {
            ProductionOrigin productionOrigin = _mapper.Map<ProductionOrigin>(productionOriginPostDto);
            _context.ProductionOrigins.Add(productionOrigin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductionOriginExists(productionOrigin.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = productionOrigin.Id }, productionOrigin);
        }

        // put groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProductionOrigin productionOrigin)
        {
            if (id != productionOrigin.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionOrigin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionOriginExists(id))
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

        // delete groups
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var productionOrigin = await _context.ProductionOrigins.FindAsync(id);
            if (productionOrigin == null)
            {
                return NotFound();
            }
            _context.ProductionOrigins.Remove(productionOrigin);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductionOriginExists(int id)
        {
            return _context.ProductionOrigins.Any(e => e.Id == id);
        }

    }
}

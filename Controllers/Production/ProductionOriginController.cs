using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionOrigin;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProductionOriginController : BaeApiController<ProductionOriginController>
    {
        private readonly EnpDbContext _context;

        public ProductionOriginController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProductionOrigin>> GetProductionDestinations(string tenantId)
        {
            var productionOrigins = _context.ProductionOrigins.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return productionOrigins;
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
            if (ProductionOriginExists(productionOrigin.Name))
            {
                return Conflict();
            }

            _context.ProductionOrigins.Add(productionOrigin);
            await _context.SaveChangesAsync();
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
                if (!ProductionOriginExists(productionOrigin.Name))
                {
                    return NotFound();
                }

                throw;
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

        private bool ProductionOriginExists(string name)
        {
            return _context.ProductionOrigins.Any(e => e.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionDestination;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProductionDestinationController : BaeApiController<ProductionDestinationController>
    {
        private readonly EnpDbContext _context;

        public ProductionDestinationController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProductionDestination>> GetProductionDestinations(string tenantId)
        {
            var productionDestinations =
                _context.ProductionDestinations.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return productionDestinations;
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProductionDestination), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var productionDestination = await _context.ProductionDestinations.FindAsync(id);
            if (productionDestination == null)
            {
                return NotFound();
            }

            return Ok(productionDestination);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductionDestination), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProductionDestinationPostDto productionDestinationPostDto)
        {
            ProductionDestination productionDestination =
                _mapper.Map<ProductionDestination>(productionDestinationPostDto);
            if (ProductionDestinationExists(productionDestination.Name, productionDestination.TenantId))
            {
                return Conflict();
            }

            _context.ProductionDestinations.Add(productionDestination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = productionDestination.Id }, productionDestination);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProductionDestination productionDestination)
        {
            if (id != productionDestination.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionDestination).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionDestinationExists(productionDestination.Name, productionDestination.TenantId))
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

        // delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var productionDestination = await _context.ProductionDestinations.FindAsync(id);
            if (productionDestination == null)
            {
                return NotFound();
            }

            _context.ProductionDestinations.Remove(productionDestination);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductionDestinationExists(string name, string tenantId)
        {
            return _context.ProductionDestinations.Any(e =>
                e.Name.ToLower().Trim() == name.ToLower().Trim() &&
                e.TenantId.ToLower().Trim() == tenantId.ToLower().Trim()
            );
        }
    }
}
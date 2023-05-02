using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionDestination;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProductionDestinationController : BaeApiController<ProductionDestinationController>
    {
        private readonly EnpDBContext _context;
        public ProductionDestinationController(EnpDBContext context)
        {
            _context = context;
        }

        //get list
        [HttpGet]
        [ProducesResponseType(typeof(ProductionDestination), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ProductionDestination>> Get()
        {
            return await _context.ProductionDestinations.ToListAsync();
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
            ProductionDestination productionDestination = _mapper.Map<ProductionDestination>(productionDestinationPostDto);
            _context.ProductionDestinations.Add(productionDestination);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductionDestinationExists(productionDestination.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetById", new { id = productionDestination.Id }, productionDestination);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, ProductionDestination productionDestination)
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
                if (!ProductionDestinationExists(id))
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

        private bool ProductionDestinationExists(int id)
        {
            return _context.ProductionDestinations.Any(e => e.Id == id);
        }
    }
}

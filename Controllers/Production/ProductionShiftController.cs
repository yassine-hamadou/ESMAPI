using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionShift;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProductionShiftController : BaeApiController<ProductionShiftController>
    {
        private readonly EnpDbContext _context;

        public ProductionShiftController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProductionShift>> GetProductionShifts(string tenantId)
        {
            var productionShifts = _context.ProductionShifts.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return productionShifts;
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProductionShift), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var productionShift = await _context.ProductionShifts.FindAsync(id);
            if (productionShift == null)
            {
                return NotFound();
            }

            return Ok(productionShift);
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(ProductionShift), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProductionShiftPostDto productionShiftPostDto)
        {
            ProductionShift productionShift = _mapper.Map<ProductionShift>(productionShiftPostDto);
            if (ProductionShiftExists(productionShift.Name))
            {
                return Conflict();
            }
            _context.ProductionShifts.Add(productionShift);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = productionShift.Id }, productionShift);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProductionShift productionShift)
        {
            if (id != productionShift.Id)
            {
                return BadRequest();
            }


            _context.Entry(productionShift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionShiftExists(productionShift.Name))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // delete compartment
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var productionShiftToDelete = await _context.ProductionShifts.FindAsync(id);
            if (productionShiftToDelete == null) return NotFound();
            _context.ProductionShifts.Remove(productionShiftToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductionShiftExists(string name)
        {
            return _context.ProductionShifts.Any(e => e.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
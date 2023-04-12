using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionShift;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProductionShiftController : BaeApiController<ProductionShiftController>
    {
        private readonly EnpDBContext _context;
        public ProductionShiftController(EnpDBContext context)
        {
            _context = context;
        }

        //get list
        [HttpGet]
        [ProducesResponseType(typeof(ProductionShift), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ProductionShift>> Get()
        {
            return await _context.ProductionShifts.ToListAsync();
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



            _context.ProductionShifts.Add(productionShift);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductionShiftExists(productionShift.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
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
                if (!ProductionShiftExists(id))
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

        private bool ProductionShiftExists(int id)
        {
            return _context.ProductionShifts.Any(e => e.Id == id);
        }
    }
}

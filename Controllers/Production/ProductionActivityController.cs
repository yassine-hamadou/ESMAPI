using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Compartments;
using ServiceManagerApi.Dtos.ProductionActivity;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProductionActivityController : BaeApiController<ProductionActivityController>
    {
        private readonly EnpDbContext _context;
        public ProductionActivityController(EnpDbContext context)
        {
            _context = context;
        }


        //get list
        [HttpGet]
        [ProducesResponseType(typeof(ProductionActivity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ProductionActivity>> Get()
        {
            return await _context.ProductionActivities.ToListAsync();
        }


        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProductionActivity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var productionActivity = await _context.ProductionActivities.FindAsync(id);
            if (productionActivity == null)
            {
                return NotFound();
            }

            return Ok(productionActivity);
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(ProductionActivity), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProductionActivityPostDto productionActivityPostDto)
        {

            ProductionActivity productionActivity = _mapper.Map<ProductionActivity>(productionActivityPostDto);



            _context.ProductionActivities.Add(productionActivity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductionActivityExists(productionActivity.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = productionActivity.Id }, productionActivity);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProductionActivity productionActivity)
        {

            if (id != productionActivity.Id)
            {
                return BadRequest();
            }



            _context.Entry(productionActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionActivityExists(id))
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
            var productionActivityToDelete = await _context.ProductionActivities.FindAsync(id);
            if (productionActivityToDelete == null) return NotFound();
            _context.ProductionActivities.Remove(productionActivityToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductionActivityExists(int id)
        {
            return _context.ProductionActivities.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.LubeBrands;

namespace ServiceManagerApi.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class LubeBrandsController : BaeApiController<LubeBrandsController>
    {
        private EnpDBContext _context;

        public LubeBrandsController(EnpDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(typeof(LubeBrand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<LubeBrand>> Get()
        {
            return await _context.LubeBrands.ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(LubeGrade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var lubeBrand = await _context.LubeBrands.FindAsync(id);
            if (lubeBrand == null)
            {
                return NotFound();
            }

            return Ok(lubeBrand);
        }
        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(LubeBrand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(LubeBrandPostDto lubeBrandPostDto)
        {

            LubeBrand lubeBrand = _mapper.Map<LubeBrand>(lubeBrandPostDto);

            _context.LubeBrands.Add(lubeBrand);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LubeBrandExists(lubeBrand.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = lubeBrand.Id }, lubeBrand);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, LubeBrand lubeBrand)
        {
            
            if (id != lubeBrand.Id)
            {
                return BadRequest();
            }



            _context.Entry(lubeBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LubeBrandExists(id))
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
        
        // patch groups
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch(int id,[FromBody] JsonPatchDocument<LubeBrand> patchLubeBrand)
        {

            var brand = await _context.LubeBrands.FindAsync(id);

            if (brand ==null)
            {
                return BadRequest();
            }
            patchLubeBrand.ApplyTo(brand, ModelState);

            return Ok(brand);
        }

        // delete groups
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var lubeBrandToDelete = await _context.LubeBrands.FindAsync(id);
            if (lubeBrandToDelete == null) return NotFound();
            _context.LubeBrands.Remove(lubeBrandToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LubeBrandExists(int id)
        {
            return _context.LubeBrands.Any(e => e.Id == id);
        }

    }
}

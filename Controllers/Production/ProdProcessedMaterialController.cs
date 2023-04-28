using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProdProcessedMaterial;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProdProcessedMaterialController : BaeApiController<ProdProcessedMaterialController>
    {
        private readonly EnpDBContext _context;
        public ProdProcessedMaterialController(EnpDBContext context)
        {
            _context = context;
        }

        //get list
        [HttpGet]
        [ProducesResponseType(typeof(ProdProcessedMaterial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ProdProcessedMaterial>> Get()
        {
            return await _context.ProdProcessedMaterials.ToListAsync();
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProdProcessedMaterial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var prodProcessedMaterial = await _context.ProdProcessedMaterials.FindAsync(id);
            if (prodProcessedMaterial == null)
            {
                return NotFound();
            }
            return Ok(prodProcessedMaterial);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdProcessedMaterial), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProdProcessedMaterialPostDto prodProcessedMaterialPostDto)
        {
            ProdProcessedMaterial prodProcessedMaterial = _mapper.Map<ProdProcessedMaterial>(prodProcessedMaterialPostDto);
            _context.ProdProcessedMaterials.Add(prodProcessedMaterial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProdProcessedMaterialExists(prodProcessedMaterial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = prodProcessedMaterial.Id }, prodProcessedMaterial);
        }

        // put groups
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProdProcessedMaterial prodProcessedMaterial)
        {
           if (id != prodProcessedMaterial.Id)
            {
                return BadRequest();
            }
            _context.Entry(prodProcessedMaterial).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdProcessedMaterialExists(id))
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
            var prodProcessedMaterial = await _context.ProdProcessedMaterials.FindAsync(id);
            if (prodProcessedMaterial == null)
            {
                return NotFound();
            }
            _context.ProdProcessedMaterials.Remove(prodProcessedMaterial);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProdProcessedMaterialExists(int id)
        {
            return _context.ProdProcessedMaterials.Any(e => e.Id == id);
        }

    }
}

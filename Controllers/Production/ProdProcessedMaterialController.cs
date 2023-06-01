using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProdProcessedMaterial;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProdProcessedMaterialController : BaeApiController<ProdProcessedMaterialController>
    {
        private readonly EnpDbContext _context;

        public ProdProcessedMaterialController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProdProcessedMaterial>> GetPlannedOutputs(string tenantId)
        {
            var prodProcessedMaterials =
                _context.ProdProcessedMaterials.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return prodProcessedMaterials;
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
            ProdProcessedMaterial prodProcessedMaterial =
                _mapper.Map<ProdProcessedMaterial>(prodProcessedMaterialPostDto);
            if (ProdProcessedMaterialExists(prodProcessedMaterial.Name))
            {
                return Conflict();
            }

            _context.ProdProcessedMaterials.Add(prodProcessedMaterial);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = prodProcessedMaterial.Id }, prodProcessedMaterial);
        }

        // put groups
        [HttpPut("{id}")]
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
                if (!ProdProcessedMaterialExists(prodProcessedMaterial.Name))
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
            var prodProcessedMaterial = await _context.ProdProcessedMaterials.FindAsync(id);
            if (prodProcessedMaterial == null)
            {
                return NotFound();
            }

            _context.ProdProcessedMaterials.Remove(prodProcessedMaterial);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProdProcessedMaterialExists(string name)
        {
            return (_context.ProdProcessedMaterials?.Any(e => e.Name.ToLower().Trim() == name.ToLower().Trim())).GetValueOrDefault();
        }
    }
}
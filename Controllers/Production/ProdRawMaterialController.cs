using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProdRawMaterial;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProdRawMaterialController : BaeApiController<ProdRawMaterialController>
    {
        private readonly EnpDbContext _context;

        public ProdRawMaterialController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProdRawMaterial>> GetProdRawMaterials(string tenantId)
        {
            var prodRawMaterials = _context.ProdRawMaterials.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return prodRawMaterials;
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProdRawMaterial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var prodRawMaterial = await _context.ProdRawMaterials.FindAsync(id);
            if (prodRawMaterial == null)
            {
                return NotFound();
            }

            return Ok(prodRawMaterial);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdRawMaterial), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProdRawMaterialPostDto prodRawMaterialPostDto)
        {
            ProdRawMaterial prodRawMaterial = _mapper.Map<ProdRawMaterial>(prodRawMaterialPostDto);
            if (ProdRawMaterialExists(prodRawMaterial.Name, prodRawMaterial.TenantId))
            {
                return Conflict();
            }

            _context.ProdRawMaterials.Add(prodRawMaterial);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = prodRawMaterial.Id }, prodRawMaterial);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProdRawMaterial prodRawMaterial)
        {
            if (id != prodRawMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(prodRawMaterial).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdRawMaterialExists(prodRawMaterial.Name, prodRawMaterial.TenantId))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var prodRawMaterial = await _context.ProdRawMaterials.FindAsync(id);
            if (prodRawMaterial == null)
            {
                return NotFound();
            }

            _context.ProdRawMaterials.Remove(prodRawMaterial);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProdRawMaterialExists(string name, string tenantId)
        {
            return _context.ProdRawMaterials.Any(e =>
                e.Name.ToLower().Trim() == name.ToLower().Trim() &&
                e.TenantId.ToLower().Trim() == tenantId.ToLower().Trim()
            );
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Models;
using ServiceManagerApi.ViewModels;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]

    public class VmfaltsApiController : ControllerBase
    {
        private readonly ServiceManagerContext _context;

        public VmfaltsApiController(ServiceManagerContext context)
        {
            _context = context;
        }

        // GET: api/VmfaltsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaultSmallViewModel>>> GetVmfalts()
        {
            return await _context.Vmfalts
                .Select(x=> new FaultSmallViewModel
                {
                  FaultCode = x.Txfault,
                  FaultDesc = x.Txdesc
                })
                .ToListAsync();
        }

        // GET: api/VmfaltsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vmfalt>> GetVmfalt(string id)
        {
            var vmfalt = await _context.Vmfalts.FindAsync(id);

            if (vmfalt == null)
            {
                return NotFound();
            }

            return vmfalt;
        }

        // PUT: api/VmfaltsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVmfalt(string id, Vmfalt vmfalt)
        {
            if (id != vmfalt.Txfault)
            {
                return BadRequest();
            }

            _context.Entry(vmfalt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VmfaltExists(id))
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

        // POST: api/VmfaltsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vmfalt>> PostVmfalt(Vmfalt vmfalt)
        {
            _context.Vmfalts.Add(vmfalt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VmfaltExists(vmfalt.Txfault))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVmfalt", new { id = vmfalt.Txfault }, vmfalt);
        }

        // DELETE: api/VmfaltsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVmfalt(string id)
        {
            var vmfalt = await _context.Vmfalts.FindAsync(id);
            if (vmfalt == null)
            {
                return NotFound();
            }

            _context.Vmfalts.Remove(vmfalt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VmfaltExists(string id)
        {
            return _context.Vmfalts.Any(e => e.Txfault == id);
        }
    }
}

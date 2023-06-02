using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Models;
using ServiceManagerApi.ViewModels;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class VmemplsApiController : ControllerBase
    {
        private readonly ServiceManagerContext _context;

        public VmemplsApiController(ServiceManagerContext context)
        {
            _context = context;
        }

        // GET: api/VmemplsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSmallViewModel>>> GetVmempls()
        {
            return await _context.Vmempls.
                Select( x=> new EmployeeSmallViewModel 
                {
                  EmplCode = x.Txempl,
                  EmplName = x.Txname
                })
                .ToListAsync();
        }

        // GET: api/VmemplsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vmempl>> GetVmempl(string id)
        {
            var vmempl = await _context.Vmempls.FindAsync(id);

            if (vmempl == null)
            {
                return NotFound();
            }

            return vmempl;
        }

        // PUT: api/VmemplsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVmempl(string id, Vmempl vmempl)
        {
            if (id != vmempl.Txempl)
            {
                return BadRequest();
            }

            _context.Entry(vmempl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VmemplExists(id))
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

        // POST: api/VmemplsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vmempl>> PostVmempl(Vmempl vmempl)
        {
            _context.Vmempls.Add(vmempl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VmemplExists(vmempl.Txempl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVmempl", new { id = vmempl.Txempl }, vmempl);
        }

        // DELETE: api/VmemplsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVmempl(string id)
        {
            var vmempl = await _context.Vmempls.FindAsync(id);
            if (vmempl == null)
            {
                return NotFound();
            }

            _context.Vmempls.Remove(vmempl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VmemplExists(string id)
        {
            return _context.Vmempls.Any(e => e.Txempl == id);
        }
    }
}

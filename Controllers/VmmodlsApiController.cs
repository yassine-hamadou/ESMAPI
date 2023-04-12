using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Models;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VmmodlsApiController : ControllerBase
    {
        private readonly ServiceManagerContext _context;

        public VmmodlsApiController(ServiceManagerContext context)
        {
            _context = context;
        }

        // GET: api/VmmodlsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vmmodl>>> GetVmmodls()
        {
            return await _context.Vmmodls.ToListAsync();
        }

        // GET: api/VmmodlsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vmmodl>> GetVmmodl(string id)
        {
            var vmmodl = await _context.Vmmodls.FindAsync(id);

            if (vmmodl == null)
            {
                return NotFound();
            }

            return vmmodl;
        }

        // PUT: api/VmmodlsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVmmodl(string id, Vmmodl vmmodl)
        {
            if (id != vmmodl.Txmodl)
            {
                return BadRequest();
            }

            _context.Entry(vmmodl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VmmodlExists(id))
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

        // POST: api/VmmodlsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vmmodl>> PostVmmodl(Vmmodl vmmodl)
        {
            _context.Vmmodls.Add(vmmodl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VmmodlExists(vmmodl.Txmodl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVmmodl", new { id = vmmodl.Txmodl }, vmmodl);
        }

        // DELETE: api/VmmodlsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVmmodl(string id)
        {
            var vmmodl = await _context.Vmmodls.FindAsync(id);
            if (vmmodl == null)
            {
                return NotFound();
            }

            _context.Vmmodls.Remove(vmmodl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VmmodlExists(string id)
        {
            return _context.Vmmodls.Any(e => e.Txmodl == id);
        }
    }
}

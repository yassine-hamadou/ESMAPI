using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Models;
using ServiceManagerApi.ViewModels;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VmclasApiController : ControllerBase
    {
        private readonly ServiceManagerContext _context;

        public VmclasApiController(ServiceManagerContext context)
        {
            _context = context;
        }

        // GET: api/Vmclas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassSmallViewModel>>> GetVmclas()
        {
            return await _context.Vmclas
                .Select(x => new ClassSmallViewModel
                {
                    ClassCode = x.Txclass,
                    ClassDesc = x.Txdesc
                })
                .ToListAsync();
        }

        // GET: api/Vmclas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vmcla>> GetVmcla(short id)
        {
            var vmcla = await _context.Vmclas.FindAsync(id);

            if (vmcla == null)
            {
                return NotFound();
            }

            return vmcla;
        }

        // PUT: api/Vmclas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVmcla(short id, Vmcla vmcla)
        {
            if (id != vmcla.Wdtype)
            {
                return BadRequest();
            }

            _context.Entry(vmcla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VmclaExists(id))
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

        // POST: api/Vmclas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vmcla>> PostVmcla(Vmcla vmcla)
        {
            _context.Vmclas.Add(vmcla);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VmclaExists(vmcla.Wdtype))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVmcla", new { id = vmcla.Wdtype }, vmcla);
        }

        // DELETE: api/Vmclas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVmcla(short id)
        {
            var vmcla = await _context.Vmclas.FindAsync(id);
            if (vmcla == null)
            {
                return NotFound();
            }

            _context.Vmclas.Remove(vmcla);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VmclaExists(short id)
        {
            return _context.Vmclas.Any(e => e.Wdtype == id);
        }
    }
}

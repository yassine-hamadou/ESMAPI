using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Models;
using ServiceManagerApi.ViewModels;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IclocsApiController : ControllerBase
    {
        private readonly ServiceManagerContext _context;

        public IclocsApiController(ServiceManagerContext context)
        {
            _context = context;
        }

        // GET: api/IclocsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationSmallViewModel>>> GetIclocs()
        {
            return await _context.Iclocs
                .Select(x=> new LocationSmallViewModel
                {
                 LocationCode = x.Location,
                 LocationDesc = x.Desc
                })
                .ToListAsync();
        }

        // GET: api/IclocsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Icloc>> GetIcloc(string id)
        {
            var icloc = await _context.Iclocs.FindAsync(id);

            if (icloc == null)
            {
                return NotFound();
            }

            return icloc;
        }

        // PUT: api/IclocsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIcloc(string id, Icloc icloc)
        {
            if (id != icloc.Location)
            {
                return BadRequest();
            }

            _context.Entry(icloc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IclocExists(id))
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

        // POST: api/IclocsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Icloc>> PostIcloc(Icloc icloc)
        {
            _context.Iclocs.Add(icloc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IclocExists(icloc.Location))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIcloc", new { id = icloc.Location }, icloc);
        }

        // DELETE: api/IclocsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIcloc(string id)
        {
            var icloc = await _context.Iclocs.FindAsync(id);
            if (icloc == null)
            {
                return NotFound();
            }

            _context.Iclocs.Remove(icloc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IclocExists(string id)
        {
            return _context.Iclocs.Any(e => e.Location == id);
        }
    }
}

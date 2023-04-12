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
    public class IcitemsApiController : ControllerBase
    {
        private readonly ServiceManagerContext _context;

        public IcitemsApiController(ServiceManagerContext context)
        {
            _context = context;
        }

        // GET: api/IclocsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemsViewModel>>> GetIclocs()
        {
            return await _context.Icitems
                .Select(x=> new InventoryItemsViewModel
                {
                 ItemNumber = x.Itemno,
                 Category = x.Category,
                 ItemDescription = x.Desc,
                 AuditUser = x.Audtuser

                })
                .ToListAsync();
        }

        // GET: api/IclocsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Icitem>> GetIcloc(string id)
        {
            var icItem = await _context.Icitems.FindAsync(id);

            if (icItem == null)
            {
                return NotFound();
            }

            return icItem;
        }

        // PUT: api/IclocsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIcloc(string id, Icitem icItem)
        {
            if (id != icItem.Itemno)
            {
                return BadRequest();
            }

            _context.Entry(icItem).State = EntityState.Modified;

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
        public async Task<ActionResult<Icitem>> PostIcloc(Icitem icItem)
        {
            _context.Icitems.Add(icItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IclocExists(icItem.Itemno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIcloc", new { id = icItem.Itemno }, icItem);
        }

        // DELETE: api/IclocsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIcloc(string id)
        {
            var icloc = await _context.Icitems.FindAsync(id);
            if (icloc == null)
            {
                return NotFound();
            }

            _context.Icitems.Remove(icloc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IclocExists(string id)
        {
            return _context.Icitems.Any(e => e.Itemno == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.GroundEngagingTools;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroundEngagingToolsController : BaeApiController<GroundEngagingToolsController>
    {
        private readonly EnpDbContext _context;

        public GroundEngagingToolsController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet("tenant/{tenantId}")]
        public Task<List<GroundEngTool>> GetGroundEngTools(string tenantId)
        {
            var groundEngTools = _context.GroundEngTools.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return groundEngTools;
        }

        // GET: api/GroundEngagingTools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroundEngTool>> GetGroundEngTool(int id)
        {
          if (_context.GroundEngTools == null)
          {
              return NotFound();
          }
          var groundEngTool = await _context.GroundEngTools.Include(tool => tool.Equipment).FirstOrDefaultAsync(tool => tool.Id == id);

            if (groundEngTool == null)
            {
                return NotFound();
            }

            return groundEngTool;
        }

        // PUT: api/GroundEngagingTools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroundEngTool(int id, GroundEngagingToolsPutDto groundEngagingToolsPutDto)
        {
            
            GroundEngTool groundEngTool = _mapper.Map<GroundEngTool>(groundEngagingToolsPutDto);
            if (id != groundEngTool.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(groundEngTool).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroundEngToolExists(id))
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

        // POST: api/GroundEngagingTools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroundEngTool>> PostGroundEngTool(GroundEngagingToolsPostDto groundEngagingToolsPostDto)
        {
          if (_context.GroundEngTools == null)
          {
              return Problem("Entity set 'EnpDBContext.GroundEngTools'  is null.");
          }
            GroundEngTool groundEngTool = _mapper.Map<GroundEngTool>(groundEngagingToolsPostDto);
            _context.GroundEngTools.Add(groundEngTool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroundEngTool", new { id = groundEngTool.Id }, groundEngTool);
        }

        // DELETE: api/GroundEngagingTools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroundEngTool(int id)
        {
            if (_context.GroundEngTools == null)
            {
                return NotFound();
            }
            var groundEngTool = await _context.GroundEngTools.FindAsync(id);
            if (groundEngTool == null)
            {
                return NotFound();
            }

            _context.GroundEngTools.Remove(groundEngTool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroundEngToolExists(int id)
        {
            return (_context.GroundEngTools?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelClassesController : ControllerBase
    {
        private readonly EnpDbContext _context;

        public ModelClassesController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/ModelClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelClass>>> GetModelClasses()
        {
          if (_context.ModelClasses == null)
          {
              return NotFound();
          }
            return await _context.ModelClasses
                    .Include(modelClass => modelClass.Models)
                    .ThenInclude(model => model.Equipment)
                    .ToListAsync();
        }

        // GET: api/ModelClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelClass>> GetModelClass(int id)
        {
          if (_context.ModelClasses == null)
          {
              return NotFound();
          }
            var modelClass = await _context.ModelClasses.FindAsync(id);

            if (modelClass == null)
            {
                return NotFound();
            }

            return modelClass;
        }

        // PUT: api/ModelClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelClass(int id, ModelClass modelClass)
        {
            if (id != modelClass.ModelClassId)
            {
                return BadRequest();
            }

            _context.Entry(modelClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelClassExists(id))
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

        // POST: api/ModelClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelClass>> PostModelClass(ModelClass modelClass)
        {
          if (_context.ModelClasses == null)
          {
              return Problem("Entity set 'EnpDBContext.ModelClasses'  is null.");
          }
            _context.ModelClasses.Add(modelClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelClass", new { id = modelClass.ModelClassId }, modelClass);
        }

        // DELETE: api/ModelClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelClass(int id)
        {
            if (_context.ModelClasses == null)
            {
                return NotFound();
            }
            var modelClass = await _context.ModelClasses.FindAsync(id);
            if (modelClass == null)
            {
                return NotFound();
            }

            _context.ModelClasses.Remove(modelClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelClassExists(int id)
        {
            return (_context.ModelClasses?.Any(e => e.ModelClassId == id)).GetValueOrDefault();
        }
    }
}

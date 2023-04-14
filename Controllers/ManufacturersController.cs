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
    public class ManufacturersController : ControllerBase
    {
        private readonly EnpDBContext _context;

        public ManufacturersController(EnpDBContext context)
        {
            _context = context;
        }

        // GET: api/ManufacturersController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturers()
        {
          if (_context.Manufacturers == null)
          {
              return NotFound();
          }
            return await _context.Manufacturers.Include(manufacturer => manufacturer.Models).ToListAsync();
        }

        // GET: api/ManufacturersController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
        {
          if (_context.Manufacturers == null)
          {
              return NotFound();
          }
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }

        // PUT: api/ManufacturersController/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.ManufacturerId)
            {
                return BadRequest();
            }

            _context.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

        // POST: api/ManufacturersController
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        {
          if (_context.Manufacturers == null)
          {
              return Problem("Entity set 'EnpDBContext.Manufacturers'  is null.");
          }
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturer", new { id = manufacturer.ManufacturerId }, manufacturer);
        }

        // DELETE: api/ManufacturersController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            if (_context.Manufacturers == null)
            {
                return NotFound();
            }
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufacturerExists(int id)
        {
            return (_context.Manufacturers?.Any(e => e.ManufacturerId == id)).GetValueOrDefault();
        }
    }
}

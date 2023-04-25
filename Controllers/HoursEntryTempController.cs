using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.HoursEntriesTemp;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoursEntryTempController : BaeApiController<HoursEntryTempController>
    {
        private readonly EnpDBContext _context;

        public HoursEntryTempController(EnpDBContext context)
        {
            _context = context;
        }

        // GET: api/HoursEntryTemp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoursEntryTemp>>> GetHoursEntryTemps()
        {
          if (_context.HoursEntryTemps == null)
          {
              return NotFound();
          }
            return await _context.HoursEntryTemps.ToListAsync();
        }

        // GET: api/HoursEntryTemp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoursEntryTemp>> GetHoursEntryTemp(int id)
        {
          if (_context.HoursEntryTemps == null)
          {
              return NotFound();
          }
            var hoursEntryTemp = await _context.HoursEntryTemps.FindAsync(id);

            if (hoursEntryTemp == null)
            {
                return NotFound();
            }

            return hoursEntryTemp;
        }

        // PUT: api/HoursEntryTemp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoursEntryTemp(int id, HoursEntryTemp hoursEntryTemp)
        {
            if (id != hoursEntryTemp.Id)
            {
                return BadRequest();
            }

            _context.Entry(hoursEntryTemp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoursEntryTempExists(id))
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

        // POST: api/HoursEntryTemp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoursEntryTemp>> Create(HoursEntriesTempPostDto hoursEntriesTempPostDto)
        {
            HoursEntryTemp hoursEntryTemp = _mapper.Map<HoursEntryTemp>(hoursEntriesTempPostDto);
          if (_context.HoursEntryTemps == null)
          {
              return Problem("Entity set 'EnpDBContext.HoursEntryTemps'  is null.");
          }
            _context.HoursEntryTemps.Add(hoursEntryTemp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoursEntryTemp", new { id = hoursEntryTemp.Id }, hoursEntryTemp);
        }

        // DELETE: api/HoursEntryTemp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoursEntryTemp(int id)
        {
            if (_context.HoursEntryTemps == null)
            {
                return NotFound();
            }
            var hoursEntryTemp = await _context.HoursEntryTemps.FindAsync(id);
            if (hoursEntryTemp == null)
            {
                return NotFound();
            }

            _context.HoursEntryTemps.Remove(hoursEntryTemp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoursEntryTempExists(int id)
        {
            return (_context.HoursEntryTemps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

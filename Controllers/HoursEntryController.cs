using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Compartments;
using ServiceManagerApi.Dtos.HoursEntries;

namespace ServiceManagerApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class HoursEntryController : BaeApiController<HoursEntryController>
    {
        private readonly EnpDBContext _context;
        public HoursEntryController(EnpDBContext context)
        {
            _context = context;
        }


        //get list
        [HttpGet]
        [ProducesResponseType(typeof(HoursEntry), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<HoursEntry>> Get()
        {
            //Return the most recent hours entry for each fleet 
            return await _context.HoursEntries 
                    .GroupBy(entry => entry.FleetId)
                    .Select(group => group.OrderByDescending(entry => entry.Date)
                            .ThenByDescending(i => i.Id).First())
                    .ToListAsync();
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(HoursEntry), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _context.HoursEntries.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // post hourEntry
        [HttpPost]
        [ProducesResponseType(typeof(HoursEntry), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(HoursEntriesPostDto hoursEntriesPostDto)
        {
            HoursEntry hourEntry = _mapper.Map<HoursEntry>(hoursEntriesPostDto);

            _context.HoursEntries.Add(hourEntry);
            try
            {
                // hourEntry.Date = DateTime.Today.AddDays(-1);
                // hourEntry.PreviousReading = 0;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HourEntryExists(hourEntry.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = hourEntry.Id }, hourEntry);
        }

        // updates hourEntry
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, HoursEntriesPutDto hoursEntriesPutDto)
        {

            HoursEntry hourEntry = _mapper.Map<HoursEntry>(hoursEntriesPutDto);
            
            if (id != hourEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(hourEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourEntryExists(id))
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


        // patch hourEntry
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<HoursEntry> patchHourEntry)
        {

            var hourEntry = await _context.HoursEntries.FindAsync(id);

            if (hourEntry == null)
            {
                return BadRequest();
            }

            patchHourEntry.ApplyTo(hourEntry, ModelState);

            await _context.SaveChangesAsync();

            return Ok(hourEntry);
        }


        // delete hourEntry
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var groupToDelete = await _context.HoursEntries.FindAsync(id);
            if (groupToDelete == null) return NotFound();
            _context.HoursEntries.Remove(groupToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool HourEntryExists(int id)
        { 
            return _context.HoursEntries.Any(e => e.Id == id);
        }
    }
}

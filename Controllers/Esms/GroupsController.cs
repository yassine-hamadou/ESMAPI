using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Groups;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : BaeApiController<GroupsController>
    {
        private readonly EnpDbContext _context;

        public GroupsController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Group>> Get()
        {
            return await _context.Groups
                .Include(ser => ser.Items)
                .Include(sec=> sec.Section)
                    .ThenInclude(ser=>ser.Service)
                .ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(Group), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(GroupsPostDto groupsPostDto)
        {
            
            Group group = _mapper.Map<Group>(groupsPostDto);

            _context.Groups.Add(group);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupExists(group.Id))
                {
                    return Conflict();
                }   
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, Group group)
        {

            if (id != group.Id)
            {
                return BadRequest();
            }



            _context.Entry(group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // delete groups
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var groupToDelete = await _context.Groups.FindAsync(id);
            if (groupToDelete == null) return NotFound();
            _context.Groups.Remove(groupToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}


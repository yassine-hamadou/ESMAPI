using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.LubeGrades;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class LubeGradesController : BaeApiController<LubeGradesController>
    {
        private EnpDbContext _context;

        public LubeGradesController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(typeof(LubeGrade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<LubeGrade>> Get()
        {
            return await _context.LubeGrades.ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(LubeGrade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var lubeGrade = await _context.LubeGrades.FindAsync(id);
            if (lubeGrade == null)
            {
                return NotFound();
            }

            return Ok(lubeGrade);
        }

        // post lubeGrades
        [HttpPost]
        [ProducesResponseType(typeof(LubeGrade), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(LubeGradePostDto lubeGradePostDto)
        {

            LubeGrade lubeGrade = _mapper.Map<LubeGrade>(lubeGradePostDto);

            _context.LubeGrades.Add(lubeGrade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LubeGradeExists(lubeGrade.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = lubeGrade.Id }, lubeGrade);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, LubeGrade lubeGrade)
        {

            if (id != lubeGrade.Id)
            {
                return BadRequest();
            }



            _context.Entry(lubeGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LubeGradeExists(id))
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
            var lubeGradeToDelete = await _context.LubeGrades.FindAsync(id);
            if (lubeGradeToDelete == null) return NotFound();
            _context.LubeGrades.Remove(lubeGradeToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LubeGradeExists(int id)
        {
            return _context.LubeGrades.Any(e => e.Id == id);
        }
    }
}

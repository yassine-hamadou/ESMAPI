using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.LubeConfigs;
using ServiceManagerApi.Dtos.LubeGrades;
namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LubeConfigsController : BaeApiController<LubeConfigsController>
    {
        private EnpDBContext _context;

        public LubeConfigsController(EnpDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(typeof(LubeConfig), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<LubeConfig>> Get()
        {
            return await _context.LubeConfigs
                .Include(conf=>conf.Compartment)
                .Include(con=>con.LubeGrades)
                .ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(LubeConfig), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var lubeConfig = await _context.LubeConfigs.FindAsync(id);
            if (lubeConfig == null)
            {
                return NotFound();
            }

            return Ok(lubeConfig);
        }
        // post lubeConfigs
        [HttpPost]
        [ProducesResponseType(typeof(LubeConfig), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(LubeConfigPostDto lubeConfigPostDto)
        {

            LubeConfig lubeConfig = _mapper.Map<LubeConfig>(lubeConfigPostDto);

            _context.LubeConfigs.Add(lubeConfig);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LubeConfigExists(lubeConfig.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = lubeConfig.Id }, lubeConfig);
        }

        // updates LubeConfigs
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, LubeConfig lubeConfig)
        {

            if (id != lubeConfig.Id)
            {
                return BadRequest();
            }



            _context.Entry(lubeConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LubeConfigExists(id))
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

        // delete LubeConfig
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var lubeConfigToDelete = await _context.LubeConfigs.FindAsync(id);
            if (lubeConfigToDelete == null) return NotFound();
            _context.LubeConfigs.Remove(lubeConfigToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LubeConfigExists(int id)
        {
            return _context.LubeConfigs.Any(e => e.Id == id);
        }
    }
}

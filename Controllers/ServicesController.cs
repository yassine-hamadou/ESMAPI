using AspNetCoreHero.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Services;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : BaeApiController<ServicesController>
    {
        private readonly EnpDbContext _context;
        public ServicesController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet("tenant/{tenantId}")]
        [ProducesResponseType(typeof(Service), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<List<Service>> GetServices(string tenantId)
        {
            var services = _context
                .Services
                .Where(serv => serv.TenantId == tenantId)
                .Include(equip => equip.ModelNavigation)
                .ThenInclude(model => model.Equipment)
                .Include(ser => ser.Sections)
                    .ThenInclude(sec => sec.Groups)
                        .ThenInclude(grop => grop.Items)
                        .ThenInclude(grop => grop.ItemValues)
                .ToListAsync();

            return services;
        }


        [HttpGet("id")]
        [ProducesResponseType(typeof(Service), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }


        // post service
        [HttpPost]
        [ProducesResponseType(typeof(Service), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ServicePostDto servicePostDto)
        {

            Service service = _mapper.Map<Service>(servicePostDto);

            _context.Services.Add(service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceExists(service.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
        }


        // updates service
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, Service service)
        {

            if (id != service.Id)
            {
                return BadRequest();
            }



            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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
            var serviceToDelete = await _context.Services.FindAsync(id);
            if (serviceToDelete == null) return NotFound();
            _context.Services.Remove(serviceToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}

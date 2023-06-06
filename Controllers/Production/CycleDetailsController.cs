using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.CycleDetails;

namespace ServiceManagerApi.Controllers.Production
{
  
    public class CycleDetailsController : BaeApiController<CycleDetailsController>
    {
        private readonly EnpDbContext _context;

        public CycleDetailsController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet("tenant/{tenantId}")]
        public Task<List<CycleDetail>> GetCycleDetails(string tenantId)
        {
            var cycleDetails = _context.CycleDetails
                .Where(leav => leav.TenantId == tenantId)
                .Select(c=> new CycleDetail
                {
                    Id = c.Id,
                    CycleDate = c.CycleDate,
                    CycleTime = c.CycleTime,
                    Loader = c.Loader,
                    Hauler = c.Hauler,
                    Loads = c.Loads,
                    Volumes = c.Volumes,
                    Weight = c.Weight,
                    PayloadWeight = c.PayloadWeight,
                    ReportedWeight = c.ReportedWeight,
                    NominalWeight = c.NominalWeight,
                    TimeAtLoader = c.TimeAtLoader,
                    Duration = c.Duration,
                    BatchNumber = c.BatchNumber,
                    TenantId = c.TenantId,  
                    HaulerUnitId = c.HaulerUnitId,
                    LoaderUnitId = c.LoaderUnitId,
                    DestinationId = c.DestinationId,
                    OriginId = c.OriginId,
                    MaterialId = c.MaterialId,
                    ShiftId = c.ShiftId,
                    HaulerNavigation = new HaulerOperator
                    {
                       EmpName = c.HaulerNavigation.EmpName,
                       EmpCode = c.HaulerNavigation.EmpCode
                    },
                    LoaderNavigation = new LoaderOperator
                    {
                        EmpName = c.LoaderNavigation.EmpName,
                        EmpCode = c.LoaderNavigation.EmpCode
                    },
                    HaulerUnit = new ProhaulerUnit
                    {
                        EquipmentId = c.HaulerUnit.EquipmentId
                    },
                    LoaderUnit = new ProloaderUnit
                    {
                        EquipmentId = c.LoaderUnit.EquipmentId
                    },
                    Destination = new ProductionDestination
                    {
                        Name = c.Destination.Name
                    },
                    Origin = new ProductionOrigin
                    {
                        Name = c.Origin.Name
                    },
                    Material = new ProdRawMaterial
                    {
                        Name = c.Material.Name
                    },
                    Shift = new ProductionShift
                    {
                        Name = c.Shift.Name
                    }
                })
                .ToListAsync();

            return cycleDetails;

        }

        // GET: api/CycleDetails/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CycleDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var cycleDetail = await _context.CycleDetails.FindAsync(id);
            if (cycleDetail == null)
            {
                return NotFound();
            }

            return Ok(cycleDetail);
        }


        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<CycleDetail>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(IEnumerable<CycleDetailPostDto> cycleDetailPostDtos)
        {
            /*var cycleDetails = _mapper.Map<IEnumerable<CycleDetail>>(cycleDetailPostDtos);

            _context.CycleDetails.AddRange(cycleDetails);
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            } 
            catch (DbUpdateException)
            {
                if (true)
                {
                    throw new DbUpdateException("Error saving cycle details");
                }
                // Handle the conflict if necessary
            }*/
            
            try
            {
                var cycleDetails = _mapper.Map<IEnumerable<CycleDetail>>(cycleDetailPostDtos);

                // Perform input validation
                var validationResults = new List<ValidationResult>();
                foreach (var cycleDetail in cycleDetails)
                {
                    var validationContext = new ValidationContext(cycleDetail);
                    var isValid = Validator.TryValidateObject(cycleDetail, validationContext, validationResults, true);
                    if (!isValid)
                    {
                        return BadRequest(validationResults);
                    }
                }

                _context.CycleDetails.AddRange(cycleDetails);
                await _context.SaveChangesAsync();

                var createdIds = cycleDetails.Select(cd => cd.Id).ToList();
                return CreatedAtAction(nameof(GetById), new { id = createdIds }, cycleDetails);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details for troubleshooting
                // You may also want to include additional error handling logic as needed

                throw new ApplicationException("Error saving cycle details", ex);
            }

        }


        // PUT: api/CycleDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, CycleDetail cycleDetail)
        {
            
            if (id != cycleDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(cycleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CycleDetailExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/CycleDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        // DELETE: api/CycleDetails/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var cycleDetail = await _context.CycleDetails.FindAsync(id);
            if (cycleDetail == null) return NotFound();
            _context.CycleDetails.Remove(cycleDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CycleDetailExists(int id)
        {
            return _context.CycleDetails.Any(e => e.Id == id);
        }
    }
}

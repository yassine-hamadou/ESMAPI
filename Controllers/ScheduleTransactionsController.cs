using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ScheduleTransactionsDto;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleTransactionsController : BaeApiController<ScheduleTransaction>
    {
        private readonly EnpDbContext _context;

        public ScheduleTransactionsController(EnpDbContext context)
        {
            _context = context;
        }

        

        [HttpGet("tenant/{tenantId}")]
        public Task<List<ScheduleTransaction>> GetScheduleTransactions(string tenantId)
        {
            var scheduleTransactions = _context.ScheduleTransactions.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return scheduleTransactions;
        }

        // GET: api/ScheduleTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleTransaction>> GetScheduleTransaction(int id)
        {
          if (_context.ScheduleTransactions == null)
          {
              return NotFound();
          }
            var scheduleTransaction = await _context.ScheduleTransactions.FindAsync(id);

            if (scheduleTransaction == null)
            {
                return NotFound();
            }

            return scheduleTransaction;
        }

        // PUT: api/ScheduleTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleTransaction(int id, ScheduleTransaction scheduleTransaction)
        {
            if (id != scheduleTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(scheduleTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleTransactionExists(id))
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

        // POST: api/ScheduleTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleTransaction>> Create(ScheduleTransactionsPostDto scheduleTransactionsPostDto)
        {
            ScheduleTransaction scheduleTransaction = _mapper.Map<ScheduleTransaction>(scheduleTransactionsPostDto);   
          if (_context.ScheduleTransactions == null)
          {
              return Problem("Entity set 'EnpDBContext.ScheduleTransactions'  is null.");
          } 
          _context.ScheduleTransactions.Add(scheduleTransaction);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetScheduleTransaction", new { id = scheduleTransaction.Id }, scheduleTransaction);
        }

        // DELETE: api/ScheduleTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleTransaction(int id)
        {
            if (_context.ScheduleTransactions == null)
            {
                return NotFound();
            }
            var scheduleTransaction = await _context.ScheduleTransactions.FindAsync(id);
            if (scheduleTransaction == null)
            {
                return NotFound();
            }

            _context.ScheduleTransactions.Remove(scheduleTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleTransactionExists(int id)
        {
            return (_context.ScheduleTransactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

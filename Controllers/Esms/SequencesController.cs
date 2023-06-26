using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Sequences;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class SequencesController : BaeApiController<SequencesController>
{
  private readonly EnpDbContext _context;

  public SequencesController(EnpDbContext context)
  {
    _context = context;
  }

  // get all sequences for a tenant and a particular equipModel
  // GET: api/Sequences/tenant/{tenantId}/equipModel/{equipModel} and escape the special character '/'
  [HttpGet("tenant/{tenantId}/equipModel/{equipModel}")]
  public async Task<ActionResult<IEnumerable<Sequence>>> GetSequences(string tenantId, string equipModel)
  {
    //where sequence.TenantId == tenantId and equipModel == "D6R"
    var sequences = _context.Sequences
        .Where(sequence => sequence.TenantId == tenantId && sequence.EquipModel == equipModel).ToListAsync();

    if (sequences == null) return NotFound();
    return await sequences;
  }


  // GET: api/Sequences/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Sequence>> GetSequence(int id)
  {
    if (_context.Sequences == null) return NotFound();
    var sequence = await _context.Sequences.FindAsync(id);

    if (sequence == null) return NotFound();

    return sequence;
  }

  // PUT: api/Sequences/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutSequence(int id, Sequence sequence)
  {
    if (id != sequence.Id) return BadRequest();

    _context.Entry(sequence).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!SequenceExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/Sequences
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult> PostSequence(List<SequencePostDto> sequencesDtos)
  {
    if (_context.Sequences == null) return Problem("Entity set 'EnpDbContext.Sequences'  is null.");
    var sequences = _mapper.Map<List<Sequence>>(sequencesDtos);
    _context.Sequences.AddRange(sequences);
    try
    {
      await _context.SaveChangesAsync();
      //return 201 status code with the newly created sequences
      return NoContent();
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }

  // DELETE: api/Sequences/tenant/{tenantId}/equipModel/{equipModel}
  [HttpDelete("tenant/{tenantId}/equipModel/{equipModel}")]
  public async Task<IActionResult> DeleteSequence(string tenantId, string equipModel)
  {
    Console.WriteLine($"DeleteSequence: tenantId: {tenantId}, equipModel: {equipModel}");
    if (_context.Sequences == null) return NotFound();
    var decodedEquipModel = Uri.UnescapeDataString(equipModel);
    var sequences = await _context.Sequences
        .Where(sequence => sequence.TenantId == tenantId && sequence.EquipModel == decodedEquipModel).ToListAsync();

    if (sequences.Count == 0) return NotFound();

    _context.Sequences.RemoveRange(sequences);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool SequenceExists(int id)
  {
    return (_context.Sequences?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}
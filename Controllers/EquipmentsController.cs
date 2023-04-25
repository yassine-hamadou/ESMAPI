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
    public class EquipmentsController : ControllerBase
    {
        private readonly EnpDBContext _context;

        public EquipmentsController(EnpDBContext context)
        {
            _context = context;
        }

        // GET: api/Equipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipment()
        {
          if (_context.Equipment == null)
          {
              return NotFound();
          }
          //explicitly return only the model and not the entire related entities
          var equipment = await _context.Equipment
                  .Include(e => e.Model)  
                  .Select(e => new Equipment
                  {
                          Id = e.Id,
                          ModelId = e.ModelId,
                          EquipmentId = e.EquipmentId,
                          Description = e.Description,
                          SerialNumber = e.SerialNumber,
                          ManufactureDate = e.ManufactureDate,
                          PurchaseDate = e.PurchaseDate,
                          EndOfLifeDate = e.EndOfLifeDate,
                          Facode = e.Facode,
                          Note = e.Note,
                          WarrantyStartDate = e.WarrantyStartDate,
                          WarrantyEndDate = e.WarrantyEndDate,
                          UniversalCode = e.UniversalCode,
                          MeterType = e.MeterType,
                          Model = new Model
                          {
                                  ModelId = e.Model.ModelId,
                                  ManufacturerId = e.Model.ManufacturerId,
                                  ModelClassId = e.Model.ModelClassId,
                                  Name = e.Model.Name,
                                  Code = e.Model.Code,
                                  PictureLink = e.Model.PictureLink,
                                  Manufacturer = new Manufacturer
                                  {
                                          ManufacturerId = e.Model.Manufacturer.ManufacturerId,
                                          Name = e.Model.Manufacturer.Name, 
                                  },
                                  ModelClass = new ModelClass
                                  {
                                          ModelClassId = e.Model.ModelClass.ModelClassId,
                                          Name = e.Model.ModelClass.Name,
                                          Code = e.Model.ModelClass.Code
                                  },  
                          }
                  })
                  .ToListAsync();
            return equipment;
        }

        // GET: api/Equipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(int id)
        {
          if (_context.Equipment == null)
          {
              return NotFound();
          }
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        // PUT: api/Equipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        // POST: api/Equipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
        {
          if (_context.Equipment == null)
          {
              return Problem("Entity set 'EnpDBContext.Equipment'  is null.");
          }
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
        }

        // DELETE: api/Equipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            if (_context.Equipment == null)
            {
                return NotFound();
            }
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentExists(int id)
        {
            return (_context.Equipment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

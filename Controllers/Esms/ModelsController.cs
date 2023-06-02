using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Model;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaeApiController<ModelsController>
    {
        private readonly EnpDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ModelsController(EnpDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        {
          if (_context.Models == null)
          {
              return NotFound();
          }
        return await _context.Models
                .Select(m => new Model
                {
                        ModelId = m.ModelId,
                        ManufacturerId = m.ManufacturerId,
                        ModelClassId = m.ModelClassId,
                        Name = m.Name,
                        Code = m.Code,
                        PictureLink = m.PictureLink,
                        Manufacturer = new Manufacturer()
                        {
                                ManufacturerId = m.Manufacturer.ManufacturerId,
                                Name = m.Manufacturer.Name,
                        },
                        ModelClass = new ModelClass()
                        {
                                ModelClassId = m.ModelClass.ModelClassId,
                                Name = m.ModelClass.Name,
                        } 
                })
                .ToListAsync();
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel(int id)
        {
          if (_context.Models == null)
          {
              return NotFound();
          }
            var model = await _context.Models.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            if (id != model.ModelId)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel([FromForm] ModelCreateDto modelDto)
        {
          if (_context.Models == null)
          {
              return Problem("Entity set 'EnpDBContext.Models'  is null.");
          }
            modelDto.PictureLink = await UploadImage(modelDto.ImageFile);
            var model = _mapper.Map<Model>(modelDto);
            _context.Models.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModel", new { id = model.ModelId }, model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            if (_context.Models == null)
            {
                return NotFound();
            }
            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [NonAction]
        public async Task<string> UploadImage(IFormFile? imageFile)
        {
            var mes = "No file was selected";

            if (imageFile!=null)
            {
                try
                {
                    if (!Directory.Exists(webHostEnvironment.WebRootPath + "\\Uploads\\"))
                    {
                        Directory.CreateDirectory(webHostEnvironment.WebRootPath + "\\Uploads\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create(webHostEnvironment.WebRootPath + "\\Uploads\\" + imageFile.FileName))
                    {
                        await imageFile.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return "\\Uploads\\" + imageFile.FileName;
                    }

                }
                catch (Exception e)
                {

                    return e.ToString();
                }
            }
            return mes;
        }

        private bool ModelExists(int id)
        {
            return (_context.Models?.Any(e => e.ModelId == id)).GetValueOrDefault();
        }
    }
}

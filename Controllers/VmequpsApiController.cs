using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Models;
using ServiceManagerApi.ViewModels;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VmequpsApiController : ControllerBase
    {
        private readonly ServiceManagerContext _context;

        public VmequpsApiController(ServiceManagerContext context)
        {
            _context = context;
        }

        // GET: api/VmequpsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleViewModel>>> GetVmequps()
        {
            var data = await (from equp in _context.Vmequps
                         join model in _context.Vmmodls on equp.Txmodl equals model.Txmodl 
                         join vmclass in _context.Vmclas on model.Txmodlgrp equals vmclass.Txclass

                         select new VehicleViewModel
                         {
                          FleetID = equp.Txequp,
                          ModlName = model.Txmodel,
                          ModlClass = vmclass.Txdesc
                         })
                         .Distinct()
                         .ToListAsync();

            //var data = await  _context.Vmequps
            //    .Join(
            //    _context.Vmmodls,
            //    vmequps => vmequps.Txmodl,
            //    vmmodls => vmmodls.Txmodl,
            //    (vmequps, vmmodls)=> new VehicleViewModel
            //    {
            //    }
            //    )
            //    .Join(
            //    _context.Vmclas,
            //    vmmodls => vmmodls.ClassID,
            //    vmclas =>vmclas.Txclass,
            //    (vmmodls, vmclas) => new VehicleViewModel
            //    {
            //        Audtorg = vmmodls.Audtorg,
            //        Audtuser = vmmodls.Audtuser,
            //        Dtinv = vmmodls.Dtinv,
            //        Dtlastmain = vmmodls.Dtlastmain,
            //        Dtlastserv = vmmodls.Dtlastserv,
            //        Dtwarren = vmmodls.Dtwarren,
            //        Dtwarrst = vmmodls.Dtwarrst,
            //        Mninvcost = vmmodls.Mninvcost,
            //        Mninvprice = vmmodls.Mninvprice,
            //        Swactive = vmmodls.Swactive,
            //        Swtrkmaint = vmmodls.Swtrkmaint,
            //        Swtrkmtr = vmmodls.Swtrkmtr,
            //        Txequp = vmmodls.Txequp,
            //        Txinv = vmmodls.Txinv,
            //        Txmodl = vmmodls.Txmodl,
            //        Txsite = vmmodls.Txsite,
            //        Txunformsn = vmmodls.Txunformsn,
            //        Wdtrkmaint = vmmodls.Wdtrkmaint,
            //        Wdtype = vmmodls.Wdtype,
            //        ModlName = vmmodls.ModlName,
            //        ClassID = vmmodls.ClassID,
            //        ModlClass = vmclas.Txdesc,

            //    }
            //    )
            //    .ToListAsync();

            return data;
           /* return await _context.Vmequps
                .ToListAsync();*/
        }

        // GET: api/VmequpsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vmequp>> GetVmequp(string id)
        {
            var vmequp = await _context.Vmequps.FindAsync(id);

            if (vmequp == null)
            {
                return NotFound();
            }

            return vmequp;
        }

        // PUT: api/VmequpsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVmequp(string id, Vmequp vmequp)
        {
            if (id != vmequp.Txequp)
            {
                return BadRequest();
            }

            _context.Entry(vmequp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VmequpExists(id))
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

        // POST: api/VmequpsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vmequp>> PostVmequp(Vmequp vmequp)
        {
            _context.Vmequps.Add(vmequp);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VmequpExists(vmequp.Txequp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVmequp", new { id = vmequp.Txequp }, vmequp);
        }

        // DELETE: api/VmequpsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVmequp(string id)
        {
            var vmequp = await _context.Vmequps.FindAsync(id);
            if (vmequp == null)
            {
                return NotFound();
            }

            _context.Vmequps.Remove(vmequp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VmequpExists(string id)
        {
            return _context.Vmequps.Any(e => e.Txequp == id);
        }
    }
}

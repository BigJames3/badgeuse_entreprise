using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Pointage.DbContext;
using API_Pointage.Models;

namespace API_Pointage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanPointsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScanPointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ScanPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScanPoint>>> GetScanPoint()
        {
            return await _context.ScanPoints.ToListAsync();
        }

        // GET: api/ScanPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScanPoint>> GetScanPoint(Guid id)
        {
            var scanPoint = await _context.ScanPoints.FindAsync(id);

            if (scanPoint == null)
            {
                return NotFound();
            }

            return scanPoint;
        }

        // PUT: api/ScanPoints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScanPoint(Guid id, ScanPoint scanPoint)
        {
            if (id != scanPoint.ScanPointId)
            {
                return BadRequest();
            }

            _context.Entry(scanPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScanPointExists(id))
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

        // POST: api/ScanPoints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScanPoint>> PostScanPoint(ScanPoint scanPoint)
        {
            _context.ScanPoints.Add(scanPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScanPoint", new { id = scanPoint.ScanPointId }, scanPoint);
        }

        // DELETE: api/ScanPoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScanPoint(Guid id)
        {
            var scanPoint = await _context.ScanPoints.FindAsync(id);
            if (scanPoint == null)
            {
                return NotFound();
            }

            _context.ScanPoints.Remove(scanPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScanPointExists(Guid id)
        {
            return _context.ScanPoints.Any(e => e.ScanPointId == id);
        }
    }
}

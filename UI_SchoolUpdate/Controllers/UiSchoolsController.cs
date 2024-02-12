using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI_SchoolUpdate.Data;
using UI_SchoolUpdate.Models;

namespace UI_SchoolUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UiSchoolsController : ControllerBase
    {
        private readonly UI_SchoolUpdateContext _context;

        public UiSchoolsController(UI_SchoolUpdateContext context)
        {
            _context = context;
        }

        // GET: api/UiSchools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UiSchool>>> GetUiSchool()
        {
          if (_context.UiSchool == null)
          {
              return NotFound();
          }
            return await _context.UiSchool.ToListAsync();
        }

        // GET: api/UiSchools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UiSchool>> GetUiSchool(int id)
        {
          if (_context.UiSchool == null)
          {
              return NotFound();
          }
            var uiSchool = await _context.UiSchool.FindAsync(id);

            if (uiSchool == null)
            {
                return NotFound();
            }

            return uiSchool;
        }

        // PUT: api/UiSchools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUiSchool(int id, UiSchool uiSchool)
        {
            if (id != uiSchool.RollNo)
            {
                return BadRequest();
            }

            _context.Entry(uiSchool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UiSchoolExists(id))
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

        // POST: api/UiSchools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UiSchool>> PostUiSchool(UiSchool uiSchool)
        {
          if (_context.UiSchool == null)
          {
              return Problem("Entity set 'UI_SchoolUpdateContext.UiSchool'  is null.");
          }
            _context.UiSchool.Add(uiSchool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUiSchool", new { id = uiSchool.RollNo }, uiSchool);
        }

        // DELETE: api/UiSchools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUiSchool(int id)
        {
            if (_context.UiSchool == null)
            {
                return NotFound();
            }
            var uiSchool = await _context.UiSchool.FindAsync(id);
            if (uiSchool == null)
            {
                return NotFound();
            }

            _context.UiSchool.Remove(uiSchool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UiSchoolExists(int id)
        {
            return (_context.UiSchool?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}

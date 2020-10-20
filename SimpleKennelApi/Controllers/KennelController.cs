using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleKennelApi.Models;

namespace SimpleKennelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KennelController : ControllerBase
    {
        private readonly SimpleKennelContext _context;

        public KennelController(SimpleKennelContext context)
        {
            _context = context;
        }

        // GET: api/Kennel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kennel>>> GetKennels()
        {
            return await _context.Kennels.ToListAsync();
        }

        // GET: api/Kennel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kennel>> GetKennel(int id)
        {
            var kennel = await _context.Kennels.FindAsync(id);

            if (kennel == null)
            {
                return NotFound();
            }

            return kennel;
        }

        // PUT: api/Kennel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKennel(int id, Kennel kennel)
        {
            if (id != kennel.KennelId)
            {
                return BadRequest();
            }

            _context.Entry(kennel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KennelExists(id))
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

        // POST: api/Kennel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kennel>> PostKennel(Kennel kennel)
        {
            _context.Kennels.Add(kennel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKennel", new { id = kennel.KennelId }, kennel);
        }

        // DELETE: api/Kennel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kennel>> DeleteKennel(int id)
        {
            var kennel = await _context.Kennels.FindAsync(id);
            if (kennel == null)
            {
                return NotFound();
            }

            _context.Kennels.Remove(kennel);
            await _context.SaveChangesAsync();

            return kennel;
        }

        private bool KennelExists(int id)
        {
            return _context.Kennels.Any(e => e.KennelId == id);
        }
    }
}

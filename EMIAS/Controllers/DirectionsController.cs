using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMIAS.Models;

namespace EMIAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionsController : ControllerBase
    {
        private readonly EmiasContext _context;

        public DirectionsController(EmiasContext context)
        {
            _context = context;
        }

        // GET: api/Directions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direction>>> GetDirections()
        {
            return await _context.Directions.ToListAsync();
        }

        // GET: api/Directions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direction>> GetDirection(int? id)
        {
            var direction = await _context.Directions.FindAsync(id);

            if (direction == null)
            {
                return NotFound();
            }

            return direction;
        }

        // PUT: api/Directions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirection(int? id, Direction direction)
        {
            if (id != direction.IdDirection)
            {
                return BadRequest();
            }

            _context.Entry(direction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(id))
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

        // POST: api/Directions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Direction>> PostDirection(Direction direction)
        {
            _context.Directions.Add(direction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirection", new { id = direction.IdDirection }, direction);
        }

        // DELETE: api/Directions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirection(int? id)
        {
            var direction = await _context.Directions.FindAsync(id);
            if (direction == null)
            {
                return NotFound();
            }

            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectionExists(int? id)
        {
            return _context.Directions.Any(e => e.IdDirection == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MacroPlanner.Data;
using MacroPlanner.Entity;

namespace MacroPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardMembersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BoardMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BoardMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardMembers>>> GetBoardMembers()
        {
            return await _context.BoardMembers.ToListAsync();
        }

        // GET: api/BoardMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoardMembers>> GetBoardMembers(int id)
        {
            var boardMembers = await _context.BoardMembers.FindAsync(id);

            if (boardMembers == null)
            {
                return NotFound();
            }

            return boardMembers;
        }

        // PUT: api/BoardMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoardMembers(int id, BoardMembers boardMembers)
        {
            if (id != boardMembers.Id)
            {
                return BadRequest();
            }

            _context.Entry(boardMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardMembersExists(id))
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

        // POST: api/BoardMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BoardMembers>> PostBoardMembers(BoardMembers boardMembers)
        {
            _context.BoardMembers.Add(boardMembers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoardMembers", new { id = boardMembers.Id }, boardMembers);
        }

        // DELETE: api/BoardMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoardMembers(int id)
        {
            var boardMembers = await _context.BoardMembers.FindAsync(id);
            if (boardMembers == null)
            {
                return NotFound();
            }

            _context.BoardMembers.Remove(boardMembers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoardMembersExists(int id)
        {
            return _context.BoardMembers.Any(e => e.Id == id);
        }
    }
}

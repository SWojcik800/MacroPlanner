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
    public class BoardTaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BoardTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BoardTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/BoardTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoardTask>> GetBoardTask(int id)
        {
            var boardTask = await _context.Tasks.FindAsync(id);

            if (boardTask == null)
            {
                return NotFound();
            }

            return boardTask;
        }

        // PUT: api/BoardTask/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoardTask(int id, BoardTask boardTask)
        {
            if (id != boardTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(boardTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardTaskExists(id))
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

        // POST: api/BoardTask
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BoardTask>> PostBoardTask(BoardTask boardTask)
        {
            _context.Tasks.Add(boardTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoardTask", new { id = boardTask.Id }, boardTask);
        }

        // DELETE: api/BoardTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoardTask(int id)
        {
            var boardTask = await _context.Tasks.FindAsync(id);
            if (boardTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(boardTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoardTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}

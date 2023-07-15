using BackendWorks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        private readonly FirstContext _dbContext;
        public FirstController(FirstContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<First>>> GetFirstItems()
        {
            if(_dbContext.Firsts == null)
            {
                return NotFound();
            }
            return await _dbContext.Firsts.ToListAsync();
        }

        [HttpGet("(id)")]
        public async Task<ActionResult<First>> GetFirstItem(int id)
        {
            if (_dbContext.Firsts == null)
            {
                return NotFound();
            }

            var first = await _dbContext.Firsts.FindAsync(id);

            if (first == null)
            {
                return NotFound();
            }

            return first;
        }


        [HttpPost]
        public async Task<ActionResult<First>> PostFirstItem(First first)
        {
            //first.Id = Empty;
            _dbContext.Firsts.Add(first);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(First), new { id = first.Id}, first);
        }

        [HttpPut("(id)")]
        public async Task<IActionResult> PutFirstItem(int id, First first)
        {
            if(id !=first.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(first).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirstItemExist(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirstItem(int id)
        {
            if(_dbContext.Firsts == null)
            {
                return NotFound();
            }

            var first = await _dbContext.Firsts.FindAsync(id);

            if(first == null)
            {
                return NotFound();
            }

            _dbContext.Firsts.Remove(first);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool FirstItemExist(long id)
        {
            return (_dbContext.Firsts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

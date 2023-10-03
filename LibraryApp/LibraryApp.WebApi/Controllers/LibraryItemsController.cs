using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryApp.WebApi.Models;

namespace LibraryApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemsController : ControllerBase
    {
        private readonly LibraryAppDbContext _context;

        public LibraryItemsController(LibraryAppDbContext context)
        {
            _context = context;
        }

        // GET: api/LibraryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryItem>>> GetItems()
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            return await _context.Items.ToListAsync();
        }

        // GET: api/LibraryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryItem>> GetLibraryItem(int id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var libraryItem = await _context.Items.FindAsync(id);

            if (libraryItem == null)
            {
                return NotFound();
            }

            return libraryItem;
        }

        // PUT: api/LibraryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibraryItem(int id, LibraryItem libraryItem)
        {
            if (id != libraryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(libraryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryItemExists(id))
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

        // POST: api/LibraryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibraryItem>> PostLibraryItem(LibraryItem libraryItem)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set 'LibraryAppDbContext.Items'  is null.");
          }
            _context.Items.Add(libraryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibraryItem", new { id = libraryItem.Id }, libraryItem);
        }

        // DELETE: api/LibraryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var libraryItem = await _context.Items.FindAsync(id);
            if (libraryItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(libraryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibraryItemExists(int id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

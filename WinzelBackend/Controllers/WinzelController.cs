using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinzelBackend.Models;

namespace WinzelBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Winzel")]
    public class WinzelController : Controller
    {
        private readonly WinzelContext _context;

        public WinzelController(WinzelContext context)
        {
            _context = context;
            var winzel = new Winzel();
            var author = new WinzelAuthor();
            var title = new WinzelTitle();
            title.Title = "penis";
            var content = new WinzelTextContent();
            content.Content = "leons penis";
            var location = new WinzelLocation();
            winzel.WinzelAuthor = author;
            winzel.WinzelTitle = title;
            winzel.WinzelComments = new List<WinzelComment>();
            winzel.WinzelLocation = location;
            _context.Winzels.Add(winzel);
        }

        // GET: api/Winzel
        [HttpGet]
        public IEnumerable<Winzel> GetWinzels()
        {
            return _context.Winzels;
        }

        // GET: api/Winzel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWinzel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winzel = await _context.Winzels.SingleOrDefaultAsync(m => m.Id == id);

            if (winzel == null)
            {
                return NotFound();
            }

            return Ok(winzel);
        }

        // PUT: api/Winzel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinzel([FromRoute] long id, [FromBody] Winzel winzel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != winzel.Id)
            {
                return BadRequest();
            }

            _context.Entry(winzel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinzelExists(id))
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

        // POST: api/Winzel
        [HttpPost]
        public async Task<IActionResult> PostWinzel([FromBody] Winzel winzel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Winzels.Add(winzel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinzel", new { id = winzel.Id }, winzel);
        }

        // DELETE: api/Winzel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWinzel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winzel = await _context.Winzels.SingleOrDefaultAsync(m => m.Id == id);
            if (winzel == null)
            {
                return NotFound();
            }

            _context.Winzels.Remove(winzel);
            await _context.SaveChangesAsync();

            return Ok(winzel);
        }

        private bool WinzelExists(long id)
        {
            return _context.Winzels.Any(e => e.Id == id);
        }
    }
}
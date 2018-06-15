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
    using Microsoft.AspNetCore.Cors;

    using WinzelBackend.Utilites;

    [Produces("application/json")]
    [Route("api/WinzelNewsFeed")]
    [EnableCors("MyPolicy")]
    public class WinzelNewsFeedController : Controller
    {
        private readonly WinzelContext _context;

        public WinzelNewsFeedController(WinzelContext context)
        {
            _context = context;
            if (this._context.Winzels.Any())
            {
                return;
            }
            CrackHoe.SpreadFakeNewws(context);
        }

        // GET: api/WinzelNewsFeed
        [HttpGet]
        public IEnumerable<WinzelNewsFeed> GetWinzelNewsFeed()
        {
            return _context.WinzelNewsFeed;
        }

        // GET: api/WinzelNewsFeed/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWinzelNewsFeed([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winzelNewsFeed = await _context.WinzelNewsFeed.SingleOrDefaultAsync(m => m.Id == id);

            if (winzelNewsFeed == null)
            {
                return NotFound();
            }

            return Ok(winzelNewsFeed);
        }

        // PUT: api/WinzelNewsFeed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinzelNewsFeed([FromRoute] long id, [FromBody] WinzelNewsFeed winzelNewsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != winzelNewsFeed.Id)
            {
                return BadRequest();
            }

            _context.Entry(winzelNewsFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinzelNewsFeedExists(id))
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

        // POST: api/WinzelNewsFeed
        [HttpPost]
        public async Task<IActionResult> PostWinzelNewsFeed([FromBody] WinzelNewsFeed winzelNewsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WinzelNewsFeed.Add(winzelNewsFeed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinzelNewsFeed", new { id = winzelNewsFeed.Id }, winzelNewsFeed);
        }

        // DELETE: api/WinzelNewsFeed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWinzelNewsFeed([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winzelNewsFeed = await _context.WinzelNewsFeed.SingleOrDefaultAsync(m => m.Id == id);
            if (winzelNewsFeed == null)
            {
                return NotFound();
            }

            _context.WinzelNewsFeed.Remove(winzelNewsFeed);
            await _context.SaveChangesAsync();

            return Ok(winzelNewsFeed);
        }

        private bool WinzelNewsFeedExists(long id)
        {
            return _context.WinzelNewsFeed.Any(e => e.Id == id);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinzelBackend.Models;

namespace WinzelBackend.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Cors;

    using WinzelBackend.Utilites;

    [Produces("application/json")]
    [Route("api/Winzel")]
    [EnableCors("MyPolicy")]

    public class WinzelController : Controller
    {
        private readonly WinzelContext _context;

        public WinzelController(WinzelContext context)
        {
            _context = context;
        }

        // GET: api/Winzel
        [HttpGet]
        public IEnumerable<Winzel> GetWinzels()
        {
            return _context.Winzels.Include(w => w.WinzelComments).Include(w => w.WinzelHashTags).Include(w => w.WinzelGraps);
        }

        // GET: api/Winzel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWinzel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == 0)
            {
                CrackHoe.HaveSex(_context);
            }

            var winzel = await _context.Winzels.Include(w => w.WinzelComments).Include(w => w.WinzelHashTags).Include(w => w.WinzelGraps).SingleOrDefaultAsync(m => m.Id == id);

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
            var comments = winzel.WinzelComments;
            if (comments != null)
            {
                var knownids = this._context.WinzelComments.Select(c => c.Id);
                foreach (var comment in comments)
                {
                    if (knownids.Contains(comment.Id))
                    {
                        _context.Entry(comment).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(comment).State = EntityState.Added;
                    }
                }
            }

            var hashtags = winzel.WinzelHashTags;
            if (hashtags != null)
            {
                var knownids = this._context.WinzelHashTags.Select(c => c.Id);
                foreach (var hashtag in hashtags)
                {
                    if (knownids.Contains(hashtag.Id))
                    {
                        _context.Entry(hashtag).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(hashtag).State = EntityState.Added;
                    }
                }
            }

            var graps = winzel.WinzelGraps;
            if (graps != null)
            {
                var knownids = this._context.Grapes.Select(c => c.Id);
                foreach (var grap in graps)
                {
                    if (knownids.Contains(grap.Id))
                    {
                        _context.Entry(grap).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(grap).State = EntityState.Added;
                    }
                }
            }

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
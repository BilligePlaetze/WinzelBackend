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
    using WinzelBackend.Utilites;

    [Produces("application/json")]
    [Route("api/WinzelComment")]
    public class WinzelCommentController : Controller
    {
        private readonly WinzelContext _context;

        public WinzelCommentController(WinzelContext context)
        {
            _context = context;
            CrackHoe.CommentBitch(this._context);
        }

        // GET: api/WinzelComment
        [HttpGet]
        public IEnumerable<WinzelComment> GetWinzelComments()
        {
            return _context.WinzelComments;
        }

        // GET: api/WinzelComment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWinzelComment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winzelComment = await _context.WinzelComments.SingleOrDefaultAsync(m => m.Id == id);

            if (winzelComment == null)
            {
                return NotFound();
            }

            return Ok(winzelComment);
        }

        // PUT: api/WinzelComment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinzelComment([FromRoute] long id, [FromBody] WinzelComment winzelComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != winzelComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(winzelComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinzelCommentExists(id))
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

        // POST: api/WinzelComment
        [HttpPost]
        public async Task<IActionResult> PostWinzelComment([FromBody] WinzelComment winzelComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WinzelComments.Add(winzelComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinzelComment", new { id = winzelComment.Id }, winzelComment);
        }

        // DELETE: api/WinzelComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWinzelComment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winzelComment = await _context.WinzelComments.SingleOrDefaultAsync(m => m.Id == id);
            if (winzelComment == null)
            {
                return NotFound();
            }

            _context.WinzelComments.Remove(winzelComment);
            await _context.SaveChangesAsync();

            return Ok(winzelComment);
        }

        private bool WinzelCommentExists(long id)
        {
            return _context.WinzelComments.Any(e => e.Id == id);
        }
    }
}
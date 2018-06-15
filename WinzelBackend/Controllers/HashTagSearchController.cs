using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinzelBackend.Models;

namespace WinzelBackend.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Cors;
    using Microsoft.EntityFrameworkCore;

    [Produces("application/json")]
    [Route("api/HashTagSearch")]
    [EnableCors("MyPolicy")]
    public class HashTagSearchController : Controller
    {
        private readonly WinzelContext _context;

        public HashTagSearchController(WinzelContext context)
        {
            _context = context;
        }

        // GET: api/HashTagSearch
        [HttpGet]
        public IEnumerable<Winzel> GetWinzels()
        {
            return _context.Winzels;
        }

        // GET: api/HashTagSearch/5
        [HttpGet("{search}")]
        public async Task<IActionResult> GetSearch([FromRoute] string search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winzels = _context
                .Winzels
                .Include(w => w.WinzelComments)
                .Include(w => w.WinzelHashTags)
                .Include(w => w.WinzelGraps)
                .Where(w => w.WinzelHashTags.Select(h => h.HashTag)
                .Contains(search));

            if (winzels == null)
            {
                return this.Ok();
            }

            return Ok(winzels);
        }
    }
}
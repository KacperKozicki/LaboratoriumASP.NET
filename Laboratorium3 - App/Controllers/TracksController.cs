using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3___App.Controllers
{
    [Route("api/tracks")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TracksController(AppDbContext context)
        {
            _context = context;
        }

        [Route("filter")]
        public IActionResult GetFilteredTrack(string query)
        {
            var result = _context.Tracks
                .Where(o => o.Name.ToUpper().StartsWith(query.ToUpper()))
                .Select(o => new
                {
                    Id = o.Id,
                    Name = o.Name
                }).ToList();

            return Ok(result);
        }

        [Route("{id}")]
        public IActionResult GetTrackById( int id)
        {
            var entity = _context.Tracks
                .Find(id);
            if(entity == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(entity);
            }
        }

        [HttpGet]
        public IActionResult GetAllTracks()
        {
            var genres = _context.Tracks.Select(g => new { g.Id, g.Name }).ToList();
            return Ok(genres);
        }

    }
}

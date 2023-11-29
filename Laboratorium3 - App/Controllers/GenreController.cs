using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3___App.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenreController(AppDbContext context)
        {
            _context = context;
        }

        [Route("filter")]
        public IActionResult GetFilteredGenres(string query)
        {
            var result = _context.Genres
                .Where(o => o.Name.ToUpper().StartsWith(query.ToUpper()))
                .Select(o => new
                {
                    Id = o.Id,
                    Name = o.Name
                }).ToList();

            return Ok(result);
        }

        [Route("{id}")]
        public IActionResult GetGenresById( int id)
        {
            var entity = _context.Genres
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
        public IActionResult GetAllGenres()
        {
            var genres = _context.Genres.Select(g => new { g.Id, g.Name }).ToList();
            return Ok(genres);
        }

    }
}

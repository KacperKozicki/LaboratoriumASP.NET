using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public SearchController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<dynamic>> Get(string query, string filter)
    {
        query = query?.ToLower() ?? ""; // Ensure query is lowercase

        switch (filter.ToLower())
        {
            case "songs":
                var songData = _dbContext.Tracks
                    .Include(t => t.Album)
                    .ThenInclude(a => a.Genre)
                    .Select(t => new {
                        id = t.Id,
                        name = t.Name,
                        genre = t.Album.Genre.Name,
                        bandOrArtist = t.Album.BandOrArtist,
                        duration = t.Duration,
                        albumName = t.Album.Name
                    })
                    .Where(t => t.name.ToLower().Contains(query))
                    .ToList();
                return Ok(songData);


            case "playlists":
                var playlistData = _dbContext.Playlists
                    .Include(p => p.PlaylistTracks)
                    .Select(p => new {
                        id = p.Id,
                        name = p.Name,
                        isPublic = p.IsPublic,
                        author = _dbContext.Users.FirstOrDefault(u => u.Id == p.UserId).UserName, // Assuming UserId is available in Playlist
                        trackCount = p.PlaylistTracks.Count
                    })
                    .Where(p => p.name.ToLower().Contains(query))
                    .ToList();
                return Ok(playlistData);

            case "albums":
                var albumData = _dbContext.Albums
                    .Select(a => new {
                        id = a.Id,
                        name = a.Name,
                        bandOrArtist = a.BandOrArtist,
                        tracklist = a.Tracklist.Select(t => t.Name).ToList() // Assuming 'Tracks' is a collection of track entities
                    })
                    .Where(a => a.name.ToLower().Contains(query))
                    .ToList();
                return Ok(albumData);

            default:
                var allSongs = _dbContext.Tracks
                    .Where(t => t.Name.ToLower().Contains(query))
                    .Select(t => new { category = "Piosenka", name = t.Name, author = t.Album.BandOrArtist })
                    .ToList();
                var allPlaylists = _dbContext.Playlists
                    .Where(p => p.Name.ToLower().Contains(query))
                    .Select(p => new { category = "Playlista", name = p.Name, author = _dbContext.Users.FirstOrDefault(u => u.Id == p.UserId).UserName }) // Assuming UserId is available in Playlist
                    .ToList();
                var allAlbums = _dbContext.Albums
                    .Where(a => a.Name.ToLower().Contains(query))
                    .Select(a => new { category = "Album", name = a.Name, author = a.BandOrArtist })
                    .ToList();

                var combinedResults = allSongs.Concat(allPlaylists).Concat(allAlbums);
                return Ok(combinedResults);
        }
    }
}

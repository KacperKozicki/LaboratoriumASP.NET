using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Laboratorium3___App.Models;



[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<IdentityUser> UserManager;

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
                var currentUser = User.Identity.Name;// uzyskaj ID aktualnie zalogowanego użytkownika
                var userId = _dbContext.Users
              .Where(u => u.UserName == currentUser)
              .Select(u => u.Id)
              .FirstOrDefault();

                var playlistData = _dbContext.Playlists
    .Include(p => p.PlaylistTracks)
    .Where(p => p.Name.ToLower().Contains(query) && (p.IsPublic || p.UserId == userId))
    .ToList() // Przenieś ToList() tutaj, aby pobrać dane z bazy
    .Select(p => new PlaylistResult
    {
        Id = p.Id,
        Name = p.Name + (!p.IsPublic && p.UserId == userId ? "&nbsp;<em class='small'>(tylko ty widzisz tę pozycję)</em>" : ""),
        IsPublic = p.IsPublic,
        Author = _dbContext.Users.Where(u => u.Id == p.UserId).Select(u => u.UserName).FirstOrDefault() ?? "Nieznany",
        TrackCount = p.PlaylistTracks.Count,
        VisibilityNote = !p.IsPublic && p.UserId == userId ? "&nbsp;<em class='small'>(tylko ty widzisz tę pozycję)</em>" : ""
    });



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
                    .Select(t => new { category = "Piosenka",id=t.Id, name = t.Name, author = t.Album.BandOrArtist })
                    .ToList();
                var allPlaylists = _dbContext.Playlists
                    .Where(p => p.Name.ToLower().Contains(query))
                    .Where(p => p.IsPublic)
                    .Select(p => new { category = "Playlista",id=p.Id, name = p.Name, author = _dbContext.Users.FirstOrDefault(u => u.Id == p.UserId).UserName }) // Assuming UserId is available in Playlist
                    .ToList();
                var allAlbums = _dbContext.Albums
                    .Where(a => a.Name.ToLower().Contains(query))
                    .Select(a => new { category = "Album", id = a.Id, name = a.Name, author = a.BandOrArtist })
                    .ToList();

                var combinedResults = allSongs.Concat(allPlaylists).Concat(allAlbums);
                return Ok(combinedResults);
        }
    }
    

}

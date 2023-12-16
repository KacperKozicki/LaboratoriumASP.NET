using Microsoft.AspNetCore.Mvc;
using Laboratorium3___App.Models;
using Data;
using Microsoft.EntityFrameworkCore;

// Kontroler dla utworów
public class TrackController : Controller
{
    private readonly AppDbContext _dbContext;

    public TrackController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Details(int id, int? playlistId)
    {
        var track = _dbContext.Tracks
            .Include(t => t.Album)
            .ThenInclude(a => a.Genre)
            .FirstOrDefault(t => t.Id == id);

        if (track == null)
        {
            return NotFound();
        }

        var artistTracks = _dbContext.Tracks
            .Where(t => t.Album.BandOrArtist == track.Album.BandOrArtist && t.Id != id)
            .Include(t => t.Album)
            .ThenInclude(a => a.Genre)
            .ToList();

        var model = new TrackDetailsViewModel // Upewnij się, że klasa TrackDetailsViewModel zawiera właściwość List<TrackViewModel>
        {
            Id = track.Id,
            Name = track.Name,
            Genre = track.Album.Genre.Name,
            BandOrArtist = track.Album.BandOrArtist,
            Duration = track.Duration,
            AlbumName = track.Album.Name,
            OtherTracksByArtist = artistTracks.Select(t => new TrackDetailsViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Genre = t.Album.Genre.Name,
                BandOrArtist = t.Album.BandOrArtist,
                Duration = t.Duration,
                AlbumName = t.Album.Name
            }).ToList()
        };

        ViewBag.PlaylistId = playlistId;
        return View(model);
    }


    // Akcja wyświetlająca szczegóły utworu
    //public IActionResult Details(int id, int playlistId)
    //{
    //    var track = _dbContext.Tracks
    //        .Include(t => t.Album) // Załaduj powiązane albumy
    //        .ThenInclude(a => a.Genre)
    //        .FirstOrDefault(t => t.Id == id);

    //    if (track == null)
    //    {
    //        return NotFound();
    //    }



    //    var model = new TrackDetailsViewModel
    //    {
    //        Id = track.Id,
    //        Name = track.Name,
    //        Genre = track.Album.Genre.Name,
    //        BandOrArtist = track.Album.BandOrArtist,
    //        Duration = track.Duration,
    //        AlbumName = track.Album.Name
    //    };
    //    ViewBag.PlaylistId = playlistId;
    //    return View(model);
    //}
}

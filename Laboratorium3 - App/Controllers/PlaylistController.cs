using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Collections.Generic;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Laboratorium3___App.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly AppDbContext _dbContext;

        public PlaylistController(IPlaylistService playlistService, AppDbContext dbContext)
        {
            _playlistService = playlistService;
            _dbContext = dbContext;
        }





        public IActionResult Index()
        {
            var playlistEntities = _dbContext.Playlists
                                             .Include(p => p.PlaylistTracks)
                                             .ThenInclude(pt => pt.Track)
                                             .Include(p => p.PlaylistTags)
                                             .ThenInclude(pt => pt.Tag)
                                             .ToList();

            var playlistModels = playlistEntities.Select(p => PlaylistMapper.FromEntity(p, _dbContext)).ToList(); // Konwersja na List<Playlist>

            return View(playlistModels); // Przekazanie modelu do widoku
        }




        public IActionResult IndexPaging([FromQuery] int? page = 1, [FromQuery] int? size = 5)
        {
            return View(_playlistService.FindPage((int)page, (int)size));
        }


        [HttpGet]
        public IActionResult Create()
        {
            Playlist model = new Playlist();
            model.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Playlist model)
        {
            if (ModelState.IsValid)
            {
                // Weryfikuj, czy wszystkie TrackNames istnieją w tabeli tracks
                foreach (var trackName in model.TrackNames)
                {
                    if (!_playlistService.TrackExists(trackName))
                    {
                        ModelState.AddModelError("TrackNames", $"Utwór '{trackName}' nie istnieje.");
                        return View(model);
                    }
                   
                }

                // Kontynuuj przetwarzanie modelu...
                var trackIds = _dbContext.Tracks
                    .Where(t => model.TrackNames.Contains(t.Name))
                    .Select(t => t.Id)
                    .ToList();

                model.TrackIds = trackIds;

                // Dodaj playlistę do bazy danych
                _playlistService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        


        //[HttpPost]
        //public IActionResult Create(Playlist model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _playlistService.Add(model);
        //        return RedirectToAction("Index");
        //    }
        //    return View(); // ponowne wyświetlenie formualrza po dodaniu jeśli są błędy
        //}

        [HttpGet]
        public IActionResult CreateApi()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateApi(Playlist model)
        {
            if (ModelState.IsValid && _playlistService.ValidateGenreId(model.GenreId))
            {
                _playlistService.Add(model);
                return RedirectToAction("Index");
            }

           

            return View(model);
        }

       

        [HttpGet]
        public IActionResult Update(int id)
        {
           

            Playlist albums = _playlistService.FindById(id);
            if (albums == null)
            {
                return NotFound();
            }

            albums.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();

            return View(albums);
        }

        [HttpPost]
        public IActionResult Update(Playlist model)
        {
            model.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            if (ModelState.IsValid)

            {
                _playlistService.Update(model); // przypisanie nowych danych
                return RedirectToAction("Index");
            }

            return View(model);      
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Playlist albums = _playlistService.FindById(id);
            if (albums == null)
            {
                return NotFound();
            }
            return View(albums);
        }

        [HttpPost]
        public IActionResult Delete(Playlist model)
        {
            _playlistService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // Pobieranie playlisty wraz z powiązanymi utworami
            Playlist playlist = _playlistService.FindByIdWithTracks(id);

            if (playlist == null)
            {
                return NotFound();
            }

            // Ustawianie nazwy gatunku
            var genre = _playlistService.FindAllGenres().FirstOrDefault(g => g.Id == playlist.GenreId);
            playlist.GenreName = genre?.Name;

            // Ładowanie tagów
            playlist.TagNames = _playlistService.GetTagsForPlaylist(id);

            return View(playlist);
        }


    }
}

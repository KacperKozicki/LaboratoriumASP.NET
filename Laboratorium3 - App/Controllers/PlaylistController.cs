﻿using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Collections.Generic;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium3___App.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public PlaylistController(IPlaylistService playlistService, AppDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _playlistService = playlistService;
            _dbContext = dbContext;
            _userManager = userManager;
        }




        public IActionResult Index([FromQuery] int? page = 1, [FromQuery] int? size = 5)
        {
            string currentUserId = _userManager.GetUserId(User);
            var playlistEntities = _dbContext.Playlists
                                             .Where(p => p.UserId == currentUserId)
                                             .Include(p => p.PlaylistTracks)
                                             .ThenInclude(pt => pt.Track)
                                             .Skip((page.Value - 1) * size.Value)
                                             .Take(size.Value)
                                             .ToList();

            var playlistModels = playlistEntities.Select(pe => PlaylistMapper.FromEntity(pe)).ToList();

            var totalItems = _dbContext.Playlists.Count(p => p.UserId == currentUserId);
            var viewModel = PagingPlaylistList<Playlist>.Create(playlistModels, totalItems, page.Value, size.Value);

            return View(viewModel);
        }



        //public IActionResult Index()
        //{
        //    var playlistEntities = _dbContext.Playlists
        //                                     .Include(p => p.PlaylistTracks)
        //                                     .ThenInclude(pt => pt.Track)
        //                                     .Include(p => p.PlaylistTags)
        //                                     .ThenInclude(pt => pt.Tag)
        //                                     .ToList();

        //    var playlistModels = playlistEntities.Select(p => PlaylistMapper.FromEntity(p, _dbContext)).ToList(); // Konwersja na List<Playlist>

        //    return View(playlistModels); // Przekazanie modelu do widoku
        //}




        public IActionResult IndexPaging([FromQuery] int? page = 1, [FromQuery] int? size = 5)
        {
            return View(_playlistService.FindPage((int)page, (int)size));
        }



        //[HttpGet]
        //public IActionResult Create()
        //{
        //    Playlist model = new Playlist();
        //    model.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
        //    {
        //        Text = eo.Name,
        //        Value = eo.Id.ToString(),
        //    }).ToList();

        //    model.Tags = _playlistService.FindAllTags().Select(tag => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        //    {
        //        Text = tag.Name,
        //        Value = tag.Id.ToString(),
        //    }).ToList();

        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Create(Playlist model)
        //{
        //    if (ModelState.IsValid && _playlistService.ValidateGenreId(model.GenreId))
        //    {
        //        // Weryfikuj, czy wszystkie TrackNames istnieją w tabeli tracks
        //        foreach (var trackName in model.TrackNames)
        //        {
        //            if (!_playlistService.TrackExists(trackName))
        //            {
        //                ModelState.AddModelError("TrackNames", $"Utwór '{trackName}' nie istnieje.");
        //                return View(model);
        //            }

        //        }

        //        // Kontynuuj przetwarzanie modelu...
        //        var trackIds = _dbContext.Tracks
        //            .Where(t => model.TrackNames.Contains(t.Name))
        //            .Select(t => t.Id)
        //            .ToList();

        //        model.TrackIds = trackIds;
        //        //var tagIds = _dbContext.Tags
        //        //    .Where(t => model.TagIds.Contains(t.Id))
        //        //    .Select(t => t.Id)
        //        //    .ToList();

        //        //model.TagIds = tagIds;

        //        // Dodaj playlistę do bazy danych
        //        _playlistService.Add(model);
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}



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

        [AuthorizeRoles("ADMIN,ARTIST,USER", "Nie masz odpowiednich uprawnień do zarządzania playlistami")]
        [HttpGet]
        public IActionResult Create()
        {
            Playlist model = new Playlist();
            model.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();

            model.Tags = _playlistService.FindAllTags().Select(tag => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = tag.Name,
                Value = tag.Id.ToString(),
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Playlist model)
        {
            if (ModelState.IsValid && _playlistService.ValidateGenreId(model.GenreId))
            {
                // Sprawdzanie, czy playlista o tej nazwie już istnieje
                if (_playlistService.PlaylistNameExists(model.Name))
                {
                    ModelState.AddModelError("Name", "Istnieje już playlista o takiej nazwie.");
                }

                // Weryfikuj, czy wszystkie TrackNames istnieją w tabeli tracks
                foreach (var trackName in model.TrackNames)
                {
                    if (!_playlistService.TrackExists(trackName))
                    {
                        ModelState.AddModelError("TrackNames", $"Utwór '{trackName}' nie istnieje.");
                    }
                }

                if (ModelState.IsValid)
                {
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
            }

            // Jeśli doszło do błędu walidacji lub istnieją inne błędy, pobierz ponownie tagi i gatunki i zwróć widok.
            model.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();

            model.Tags = _playlistService.FindAllTags().Select(tag => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = tag.Name,
                Value = tag.Id.ToString(),
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var playlist = _playlistService.FindByIdWithTracks(id);
            if (playlist == null)
            {
                return NotFound();
            }

            playlist.Genres = _playlistService.FindAllGenres().Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString(),
                Selected = e.Id == playlist.GenreId
            }).ToList();

            playlist.Tags = _playlistService.FindAllTags().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString(),
                Selected = playlist.TagIds.Contains(t.Id)
            }).ToList();

            return View(playlist);
        }


        [HttpPost]
        public IActionResult Update(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _playlistService.Update(playlist);
                return RedirectToAction("Index");
            }

            // Jeśli ModelState nie jest poprawny, załaduj ponownie listy gatunków i tagów.
            playlist.Genres = _playlistService.FindAllGenres().Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString(),
                Selected = e.Id == playlist.GenreId
            }).ToList();

            playlist.Tags = _playlistService.FindAllTags().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString(),
                Selected = playlist.TagIds.Contains(t.Id)
            }).ToList();

            return View(playlist);
        }



        //[HttpGet]
        //public IActionResult Update(int id)
        //{


        //    Playlist albums = _playlistService.FindById(id);
        //    if (albums == null)
        //    {
        //        return NotFound();
        //    }

        //    albums.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        //    {
        //        Text = eo.Name,
        //        Value = eo.Id.ToString(),
        //    }).ToList();

        //    return View(albums);
        //}

        //[HttpPost]
        //public IActionResult Update(Playlist model)
        //{
        //    model.Genres = _playlistService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        //    {
        //        Text = eo.Name,
        //        Value = eo.Id.ToString(),
        //    }).ToList();
        //    if (ModelState.IsValid)

        //    {
        //        _playlistService.Update(model); // przypisanie nowych danych
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}


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

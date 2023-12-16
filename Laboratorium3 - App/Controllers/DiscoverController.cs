using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Collections.Generic;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Laboratorium3___App.Controllers
{
    public class DiscoverController : Controller
    {
        private readonly AppDbContext _dbContext;


        public DiscoverController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        //public IActionResult Index([FromQuery] int? page = 1, [FromQuery] int? size = 5)
        //{
        //    var playlistEntities = _dbContext.Playlists
        //                                     .Include(p => p.PlaylistTracks)
        //                                     .ThenInclude(pt => pt.Track)
        //                                     .Skip((page.Value - 1) * size.Value)
        //                                     .Take(size.Value)
        //                                     .ToList();

        //    var playlistModels = playlistEntities.Select(pe => PlaylistMapper.FromEntity(pe)).ToList();

        //    var totalItems = _dbContext.Playlists.Count();
        //    var viewModel = PagingPlaylistList<Playlist>.Create(playlistModels, totalItems, page.Value, size.Value);

        //    return View(viewModel);
        //}


        public IActionResult Index()
        {
            return View();
        }




    }
    }

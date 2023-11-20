using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Collections.Generic; 


namespace Laboratorium3___App.Controllers
{
    public class AlbumController : Controller
    {
       private readonly IAlbumService _albumService;

       public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IActionResult Index()
        {
            List<Album> albums = _albumService.FindAll();
            return View(albums);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Album model = new Album();
            model.Genres = _albumService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Album model)
        {
            if (ModelState.IsValid)
            {
                _albumService.Add(model);
                return RedirectToAction("Index");
            }
            return View(); // ponowne wyświetlenie formualrza po dodaniu jeśli są błędy
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
           

            Album albums = _albumService.FindById(id);
            if (albums == null)
            {
                return NotFound();
            }

            albums.Genres = _albumService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();

            return View(albums);
        }

        [HttpPost]
        public IActionResult Update(Album model)
        {
            model.Genres = _albumService.FindAllGenres().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            if (ModelState.IsValid)

            {
                _albumService.Update(model); // przypisanie nowych danych
                return RedirectToAction("Index");
            }

            return View(model);      
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Album albums = _albumService.FindById(id);
            if (albums == null)
            {
                return NotFound();
            }
            return View(albums);
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _albumService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            Album albums = _albumService.FindById(id);

            if (albums == null)
            {
                return NotFound();
            }

            var organization = _albumService.FindAllGenres()
                .FirstOrDefault(eo => eo.Id == albums.GenreId);

            albums.GenreName = organization?.Name; // Ustaw nazwę organizacji

            return View(albums);


            //Album albums = _albumService.FindById(id);
            //if (albums == null)
            //{
            //    return NotFound();
            //}
            //return View(albums);
        }

    }
}

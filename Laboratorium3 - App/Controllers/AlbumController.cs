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
            return View();
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
            return View(albums);
        }

        [HttpPost]
        public IActionResult Update(Album model)
        {
            if (ModelState.IsValid)
            {
                _albumService.Update(model);       //przypisanie nowych danych
                return RedirectToAction("Index");
            }
            return View();
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
            return View(albums);
        }

    }
}

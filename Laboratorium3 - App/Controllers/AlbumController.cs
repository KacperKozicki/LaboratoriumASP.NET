using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Collections.Generic; 


namespace Laboratorium3___App.Controllers
{
    public class AlbumController : Controller
    {

        static readonly Dictionary<int, Album> _albums = new Dictionary<int, Album>();
        int id = 1;

        public IActionResult Index()
        {
            var albums = _albums.Values.ToList(); 
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
                do
                {
                    model.Id = id++;
                } while (_albums.ContainsKey(model.Id));

                model.Tracklist = model.Tracklist.Where(item => !string.IsNullOrWhiteSpace(item)).ToList();
                
                _albums.Add(model.Id, model);

                return RedirectToAction("Index");

            }
            return View(); 

           
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_albums[id]);
        }

        [HttpPost]
        public IActionResult Update(Album model)
        {
            if (ModelState.IsValid)
            {
                _albums[model.Id] = model;       //przypisanie nowych danych
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_albums[id]);
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _albums.Remove(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_albums[id]);
        }

    }
}

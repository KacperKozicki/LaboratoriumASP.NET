﻿using Laboratorium2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(BirthModel model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            return View(model);
        }

       
    }
}

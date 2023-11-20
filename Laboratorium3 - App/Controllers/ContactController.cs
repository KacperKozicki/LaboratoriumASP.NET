using Microsoft.AspNetCore.Mvc;
using Laboratorium3___App.Models;

namespace Laboratorium3___App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }



        //static readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact> ();


        public IActionResult Index()
        {
            List<Contact> contacts = _contactService.FindAll();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.Organizations=_contactService.FindAllOrganizations().Select(eo=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text=eo.Name,
                Value=eo.Id.ToString(),
            }).ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid)
            {
                _contactService.Add( model);
                //dodanie modelu do aplikacji (zapamiętać dane)
                return RedirectToAction("Index");

            }
            return View(); // ponowne wyświetlenie formualrza po dodaniu jeśli są błędy
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Contact contact = _contactService.FindById(id);

            if (contact == null)
            {
                return NotFound();
            }

            contact.Organizations = _contactService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();

            return View(contact);
        }


        [HttpPost]
        public IActionResult Update(Contact model)
        {
            model.Organizations = _contactService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            if (ModelState.IsValid)
            
            {
                _contactService.Update(model); // przypisanie nowych danych
                return RedirectToAction("Index");
            }

           

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id) 
        {
            Contact contact = _contactService.FindById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Contact contact = _contactService.FindById(id);

            if (contact == null)
            {
                return NotFound();
            }

            var organization = _contactService.FindAllOrganizations()
                .FirstOrDefault(eo => eo.Id == contact.OrganizationId);

            contact.OrganizationName = organization?.Name; // Ustaw nazwę organizacji

            return View(contact);
        }


    }
}

using BxlForm.Tools.Connections.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMvc.Models.Data;
using TestMvc.Models.Forms;
using TestMvc.Models.Services;

namespace TestMvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;

        private readonly CategoryService _categoryService;

        public ContactController(ContactService contactservice, CategoryService categoryService)
        {
            _contactService = contactservice;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_contactService.Get());
        }

        public IActionResult Details(int id)
        {
            return View(_contactService.Get(id));
        }
        public IActionResult Create()
        {
            CreateContactForm contactForm = new CreateContactForm();

            contactForm.Categories = GetCategories();
            return View(contactForm);
        }

        [HttpPost]
        public IActionResult Create(CreateContactForm contactForm)
        {
            if (!ModelState.IsValid)
            {
                contactForm.Categories = GetCategories();
                return View(contactForm);
            }

            Contact contact = new Contact { LastName = contactForm.LastName, FirstName = contactForm.FirstName, Email = contactForm.Email, CategoryId = contactForm.CategoryId };
            _contactService.Insert(contact);

            return RedirectToAction("Index");
        }

        private IList<SelectListItem> GetCategories(int? id = null)
        {
            IEnumerable<Category> categories = _categoryService.Get();
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem("Select a category", "0"));
            items.AddRange(categories.Select(c => new SelectListItem(c.Name, c.Id.ToString()) { Selected = (id.HasValue && c.Id == id.Value) }));
            return items;
        }
    }
}

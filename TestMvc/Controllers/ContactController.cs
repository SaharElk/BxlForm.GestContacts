using BxlForm.Tools.Connections.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMvc.Models.Data;
using TestMvc.Models.Services;

namespace TestMvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(string LastName, string FirstName, string Email, int CategoryId)
        {
            if (LastName is not null && FirstName is not null && Email is not null && CategoryId != 0)
            {
                Contact contact = new Contact { LastName = LastName, FirstName = FirstName, Email = Email, CategoryId = CategoryId };
                _contactService.Insert(contact);
            }

            return RedirectToAction("Index");
        }
    }
}

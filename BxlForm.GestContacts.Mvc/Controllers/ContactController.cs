using GR = BxlForm.GestContacts.Models.Global.Repositories;
using GS = BxlForm.GestContacts.Models.Global.Services;
using BxlForm.GestContacts.Models.Client.Data;
using BxlForm.GestContacts.Models.Client.Repositories;
using BxlForm.GestContacts.Models.Client.Services;
using BxlForm.Tools.Connections.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.GestContacts.Mvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            Connection connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestContacts;Integrated Security=True;");

            GR.IContactsRepository globalContactsRepository = new GS.ContactsService(connection);
            IContactsRepository contactsRepository = new ContactsService(globalContactsRepository);

            IEnumerable<Contact> contacts = contactsRepository.Get();
            return View(contacts);
        }
    }
}

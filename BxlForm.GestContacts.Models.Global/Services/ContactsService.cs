using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BxlForm.GestContacts.Models.Global.Data;
using BxlForm.GestContacts.Models.Global.Mappers;
using BxlForm.Tools.Connections.Database;

namespace BxlForm.GestContacts.Models.Global.Services
{
    public class ContactsService
    {
        private readonly Connection _connection;

        public ContactsService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId] FROM [Contact];", false);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId] FROM [Contact] WHERE [CategoryId] = @CategoryId;", false);
            command.AddParameter("CategoryId", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId] FROM [Contact] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

        public bool Insert(Contact contact)
        {
            Command command = new Command("BFSP_AddContact", true);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Update(int id, Contact contact)
        {
            Command command = new Command("BFSP_UpdateContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("BFSP_DeleteContact", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}

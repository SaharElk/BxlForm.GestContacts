using BxlForm.GestContacts.Models.Global.Data;
using BxlForm.GestContacts.Models.Global.Mappers;
using BxlForm.Tools.Connections.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BxlForm.GestContacts.Models.Global.Services
{
    public class CategoriesService
    {
        private readonly Connection _connection;

        public CategoriesService(Connection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Category> Get()
        {
            Command command = new Command("SELECT [Id], [Name] FROM [Category];", false);            
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public Category Get(int id)
        {
            Command command = new Command("SELECT [Id], [Name] FROM [Category] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToCategory()).SingleOrDefault();
        }

        public bool Insert(Category category)
        {
            Command command = new Command("BFSP_AddCategory", true);
            command.AddParameter("Name", category.Name);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}

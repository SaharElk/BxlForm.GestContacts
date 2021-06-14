using BxlForm.Tools.Connections.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMvc.Models.Data;
using TestMvc.Models.Mappers;

namespace TestMvc.Models.Services
{
    public class ContactService
    {

        private readonly Connection _connection;

        public ContactService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId] FROM [Contact];", false);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId] FROM [Contact] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

    }
}

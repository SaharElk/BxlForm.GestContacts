using BxlForm.Tools.Connections.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMvc.Models.Data;
using TestMvc.Models.Mappers;

namespace TestMvc.Models.Services
{
    public class CategoryService
    {
        private readonly Connection _connection;

        public CategoryService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("SELECT Id, Name FROM Category;", false);
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }
    }
}

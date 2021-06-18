using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestMvc.Models.Data;

namespace TestMvc.Models.Mappers
{
    internal static class DataRecord
    {

        internal static Contact ToContact(this IDataRecord record)
        {
            return new Contact()
            {
                Id = (int) record["Id"],
                LastName = (string) record["LastName"],
                FirstName = (string)record["FirstName"],
                Email = (string)record["Email"],
                CategoryId = (int)record["CategoryId"]
            };
        }

        internal static Category ToCategory(this IDataRecord record)
        {
            return new Category()
            {
                Id = (int)record["id"],
                Name = (string)record["Name"]
            };
        }
    }
}

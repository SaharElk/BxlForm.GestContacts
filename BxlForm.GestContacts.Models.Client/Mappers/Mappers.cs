using G = BxlForm.GestContacts.Models.Global.Data;
using BxlForm.GestContacts.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BxlForm.GestContacts.Models.Client.Mappers
{
    internal static class Mappers
    {
        internal static Contact ToClient(this G.Contact entity)
        {
            return new Contact(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.CategoryId);
        }

        internal static G.Contact ToGlobal(this Contact entity)
        {
            return new G.Contact()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                CategoryId = entity.CategoryId
            };
        }

        internal static Category ToClient(this G.Category entity)
        {
            return new Category(entity.Id, entity.Name);
        }

        internal static G.Category ToGlobal(this Category entity)
        {
            return new G.Category()
            {
                Id = entity.Id,
                Name = entity.Name                
            };
        }
    }
}

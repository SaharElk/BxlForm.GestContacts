using BxlForm.GestContacts.Models.Client.Data;
using System.Collections.Generic;

namespace BxlForm.GestContacts.Models.Client.Repositories
{
    public interface IContactsRepository
    {
        bool Delete(int id);
        IEnumerable<Contact> Get();
        Contact Get(int id);
        IEnumerable<Contact> GetByCategory(int id);
        bool Insert(Contact contact);
        bool Update(int id, Contact contact);
    }
}
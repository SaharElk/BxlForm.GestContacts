using BxlForm.GestContacts.Models.Global.Data;
using System.Collections.Generic;

namespace BxlForm.GestContacts.Models.Global.Repositories
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
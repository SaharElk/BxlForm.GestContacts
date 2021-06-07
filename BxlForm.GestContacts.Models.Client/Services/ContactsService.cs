using System.Collections.Generic;
using System.Linq;
using BxlForm.GestContacts.Models.Client.Data;
using BxlForm.GestContacts.Models.Client.Mappers;
using BxlForm.GestContacts.Models.Client.Repositories;
using GlobalIContactsRepository = BxlForm.GestContacts.Models.Global.Repositories.IContactsRepository;

namespace BxlForm.GestContacts.Models.Client.Services
{
    public class ContactsService : IContactsRepository
    {
        private readonly GlobalIContactsRepository _contactsRepository;

        public ContactsService(GlobalIContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public IEnumerable<Contact> Get()
        {
            return _contactsRepository.Get().Select(c => c.ToClient());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            return _contactsRepository.GetByCategory(id).Select(c => c.ToClient());
        }

        public Contact Get(int id)
        {
            return _contactsRepository.Get(id)?.ToClient();
        }

        public bool Insert(Contact contact)
        {
            return _contactsRepository.Insert(contact.ToGlobal());
        }

        public bool Update(int id, Contact contact)
        {
            return _contactsRepository.Update(id, contact.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _contactsRepository.Delete(id);
        }
    }
}

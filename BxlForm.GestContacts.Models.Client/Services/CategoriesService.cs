using BxlForm.GestContacts.Models.Client.Data;
using BxlForm.GestContacts.Models.Client.Mappers;
using BxlForm.GestContacts.Models.Client.Repositories;
using GlobalICategoriesRepository = BxlForm.GestContacts.Models.Global.Repositories.ICategoriesRepository;
using System.Collections.Generic;
using System.Linq;

namespace BxlForm.GestContacts.Models.Client.Services
{
    public class CategoriesService : ICategoriesRepository
    {
        private readonly GlobalICategoriesRepository _categoriesRepository;

        public CategoriesService(GlobalICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public IEnumerable<Category> Get()
        {
            return _categoriesRepository.Get().Select(c => c.ToClient());
        }

        public Category Get(int id)
        {
            return _categoriesRepository.Get(id)?.ToClient();
        }

        public bool Insert(Category category)
        {
            return _categoriesRepository.Insert(category.ToGlobal());
        }
    }
}

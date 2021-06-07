using BxlForm.GestContacts.Models.Client.Data;
using System.Collections.Generic;

namespace BxlForm.GestContacts.Models.Client.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        bool Insert(Category category);
    }
}
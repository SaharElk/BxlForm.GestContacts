using BxlForm.GestContacts.Models.Global.Data;
using System.Collections.Generic;

namespace BxlForm.GestContacts.Models.Global.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        bool Insert(Category category);
    }
}
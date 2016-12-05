using DataModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface ICategoryDataAccessProvider
    {
        Category AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(long categoryId);
        Category GetCategory(long categoryId);
        List<Category> GetCategories(Func<Category, bool> predicate, bool withChildren);
    }
}

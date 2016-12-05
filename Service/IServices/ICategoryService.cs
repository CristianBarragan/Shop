using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface ICategoryService
    {
        CategoryDTO addCategory(CategoryDTO category);
        void updateCategory(CategoryDTO category);
        void deleteCategory(long categoryId);
        CategoryDTO getCategory(long categoryId);
        List<CategoryDTO> getCategories();
    }
}

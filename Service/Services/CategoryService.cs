using DomainModel;
using DtoEntities;
using Service.IMappers;
using Service.IServices;
using Shop.WebApi.Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        IProductDataAccessProvider productDataAccessProvider;
        ICategoryDataAccessProvider categoryDataAccessProvider;
        ICategoryMapper categoryMapper;
        IProductMapper productMapper;

        public CategoryService(ICategoryDataAccessProvider categoryDataAccessProvider, IProductDataAccessProvider productDataAccessProvider,
                               ICategoryMapper categoryMapper,
                               IProductMapper productMapper)
        {
            this.categoryDataAccessProvider = categoryDataAccessProvider;
            this.productDataAccessProvider = productDataAccessProvider;
            this.categoryMapper = categoryMapper;
            this.productMapper = productMapper;
        }

        public CategoryDTO addCategory(CategoryDTO category)
        {
            if (categoryDataAccessProvider.GetCategories(c => c.Name == category.Name, false).Any())
                throw new BusinessException("Category name already exists");
            else if (categoryDataAccessProvider.GetCategories(c => c.CategoryId == category.CategoryId, false).Any())
                throw new BusinessException("Category id already exists");
            return categoryMapper.getDTO(categoryDataAccessProvider.AddCategory(categoryMapper.getEntity(category)));
        }

        public void deleteCategory(long categoryId)
        {
            categoryDataAccessProvider.DeleteCategory(categoryId);
        }

        public List<CategoryDTO> getCategories()
        {
            return categoryMapper.getDTOs(categoryDataAccessProvider.GetCategories(x => true,true));
        }

        public CategoryDTO getCategory(long categoryId)
        {
            return categoryMapper.getDTO(categoryDataAccessProvider.GetCategory(categoryId));
        }

        public void updateCategory(CategoryDTO category)
        {
            categoryDataAccessProvider.UpdateCategory(categoryMapper.getEntity(category));
        }
    }
}

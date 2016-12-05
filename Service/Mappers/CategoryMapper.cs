using DataModelEntities;
using DtoEntities;
using Service.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {

        public CategoryMapper() {}

        public CategoryDTO getDTO(Category entity)
        {
            CategoryDTO category = new CategoryDTO();
            category.CategoryId = entity.CategoryId;
            category.Name = entity.Name;
            category.Timestamp = entity.Timestamp;
            return category;
        }

        public List<CategoryDTO> getDTOs(List<Category> entities)
        {
            List<CategoryDTO> category = new List<CategoryDTO>();
            entities.ForEach(c => category.Add(getDTO(c)));
            return category;
        }

        public Category getEntity(CategoryDTO dto)
        {
            Category category = new Category();
            category.CategoryId = dto.CategoryId;
            category.Name = dto.Name;
            category.Timestamp = dto.Timestamp;
            return category;
        }

        public List<Category> getEntities(List<CategoryDTO> dtos)
        {
            throw new NotImplementedException();
        }
    }
}

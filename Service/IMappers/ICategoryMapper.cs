using DataModelEntities;
using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IMappers
{
    public interface ICategoryMapper
    {
        CategoryDTO getDTO(Category entity);
        Category getEntity(CategoryDTO dto);
        List<CategoryDTO> getDTOs(List<Category> entities);
        List<Category> getEntities(List<CategoryDTO> dtos);
    }
}

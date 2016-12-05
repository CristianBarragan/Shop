using DataModelEntities;
using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IMappers
{
    public interface IProductMapper
    {
        ProductDTO getDTO(Product entity);
        Product getEntity(ProductDTO dto, Category child);
        List<ProductDTO> getDTOs(List<Product> entities);
        List<Product> getEntities(List<ProductDTO> dtos, Category father);
    }
}

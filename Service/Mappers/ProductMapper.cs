using DataModelEntities;
using DtoEntities;
using Service.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public ProductMapper() {}

        public ProductDTO getDTO(Product product)
        {
            ProductDTO dto = new ProductDTO();
            dto.ProductId = product.ProductId;
            dto.Name = product.Name;
            dto.Price = product.Price;
            dto.Timestamp = product.Timestamp;
            dto.CategoryId = product.CategoryId;
            return dto;
        }

        public Product getEntity(ProductDTO dto, Category child)
        {
            Product product = new Product();
            product.ProductId = dto.ProductId;
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Timestamp = dto.Timestamp;
            product.CategoryId = child.CategoryId;
            product.Category = child;
            return product;
        }

        public List<ProductDTO> getDTOs(List<Product> products)
        {
            List<ProductDTO> dtos = new List<ProductDTO>();
            products.ForEach(p => dtos.Add(getDTO(p)));
            return dtos;
        }

        public List<Product> getEntities(List<ProductDTO> dtos, Category category)
        {
            List<Product> products = new List<Product>();
            dtos.ForEach(p => products.Add(getEntity(p, category)));
            return products;
        }
    }
}

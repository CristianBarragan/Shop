using DomainModel;
using DtoEntities;
using Service.IMappers;
using Service.IServices;
using Shop.WebApi.Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        IProductDataAccessProvider productDataAccessProvider;
        ICategoryDataAccessProvider categoryDataAccessProvider;
        IProductMapper mapper;

        public ProductService(IProductDataAccessProvider productDataAccessProvider, ICategoryDataAccessProvider categoryDataAccessProvider,
                              IProductMapper mapper)
        {
            this.productDataAccessProvider = productDataAccessProvider;
            this.categoryDataAccessProvider = categoryDataAccessProvider;
            this.mapper = mapper;
        }

        public ProductDTO addProduct(ProductDTO product)
        {
            if (productDataAccessProvider.GetProducts(p => p.ProductId == product.ProductId, false).Any())
                throw new BusinessException("Product id already exists");
            else if (productDataAccessProvider.GetProducts(p => p.Name == product.Name, false).Any())
                throw new BusinessException("Product name already exists");
            else
                return mapper.getDTO(productDataAccessProvider.AddProduct(mapper.getEntity(product, categoryDataAccessProvider.GetCategory(product.CategoryId))));
        }

        public void updateProduct(ProductDTO product)
        {
            productDataAccessProvider.UpdateProduct(mapper.getEntity(product, categoryDataAccessProvider.GetCategory(product.CategoryId)));
        }

        public void deleteProduct(long productId)
        {
            productDataAccessProvider.DeleteProduct(productId);
        }

        public ProductDTO getProduct(long ProductId)
        {
            return mapper.getDTO(productDataAccessProvider.GetProduct(ProductId));
        }

        public List<ProductDTO> getProducts()
        {
            return mapper.getDTOs(productDataAccessProvider.GetProducts(x=> true, true));
        }
    }
}

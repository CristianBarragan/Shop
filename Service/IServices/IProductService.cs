using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IProductService
    {
        ProductDTO addProduct(ProductDTO product);
        void updateProduct(ProductDTO product);
        void deleteProduct(long productId);
        ProductDTO getProduct(long ProductId);
        List<ProductDTO> getProducts();
    }
}

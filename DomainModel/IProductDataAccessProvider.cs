using DataModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IProductDataAccessProvider
    {
        Product AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long productId);
        Product GetProduct(long ProductId);
        List<Product> GetProducts(Func<Product, bool> predicate, bool category);
    }
}

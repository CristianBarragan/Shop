using DataModelEntities;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServer.DomainContext
{
    public class ProductDataAccessProvider : IProductDataAccessProvider
    {
        private readonly DomainModelContext context;
        private readonly ILogger logger;

        public ProductDataAccessProvider(DomainModelContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            logger = loggerFactory.CreateLogger("DataAccessMSQL");
        }

        public Product AddProduct(Product product)
        {
            if (product.Category != null && product.CategoryId == 0)
            {
                context.Categories.Add(product.Category);
            }

            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(long productId)
        {
            var entity = context.Products.First(t => t.ProductId == productId);
            context.Products.Remove(entity);
            context.SaveChanges();
        }

        public Product GetProduct(long productId)
        {
            return context.Products.Include(x => x.Category).First(t => t.ProductId == productId);
        }

        public List<Product> GetProducts(Func<Product, bool> predicate, bool category)
        {
            // Using the shadow property EF.Property<DateTime>(dataEventRecord)
            if(category)
                return context.Products.Include(x => x.Category).Where(predicate).ToList();
            else
                return context.Products.Where(predicate).ToList();
        }
    }
}

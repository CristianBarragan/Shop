using DataModelEntities;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SqlServer.DomainContext
{
    public class CategoryDataAccessProvider : ICategoryDataAccessProvider
    {
        private readonly DomainModelContext context;
        private readonly ILogger logger;

        public CategoryDataAccessProvider(DomainModelContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            logger = loggerFactory.CreateLogger("DataAccessMSQL");
        }

        public Category AddCategory(Category Category)
        {
            context.Categories.Add(Category);
            context.SaveChanges();
            return Category;
        }

        public void UpdateCategory(Category Category)
        {
            context.Categories.Update(Category);
            context.SaveChanges();
        }

        public void DeleteCategory(long CategoryId)
        {
            var entity = context.Categories.First(t => t.CategoryId == CategoryId);
            context.Categories.Remove(entity);
            context.SaveChanges();
        }

        public Category GetCategory(long categoryId)
        {
            return context.Categories.Include(c => c.Products).First(t => t.CategoryId == categoryId);
        }

        public List<Category> GetCategories(Func<Category, bool> predicate, bool withChildren)
        {
            if (withChildren)
                return context.Categories.Include(s => s.Products).Where(predicate).ToList();
            else
                return context.Categories.Where(predicate).ToList();
        }
    }
}

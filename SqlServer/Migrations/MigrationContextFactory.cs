using DataModelEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SqlServer.DomainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServer.Migrations
{
    public class MigrationContextFactory : IDbContextFactory<DomainModelContext>
    {
        public DomainModelContext Create(DbContextFactoryOptions options)
        {
            string sqlConnectionString = @"data source=ASUS1\ADMIN;initial catalog=ShopCore;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            var optionsBuilder = new DbContextOptionsBuilder<DomainModelContext>();
            optionsBuilder.UseSqlServer(sqlConnectionString, b => b.MigrationsAssembly("SqlServer"));
            var context = new DomainModelContext(optionsBuilder.Options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            InitData(context);

            return context;
        }

        private void InitData(DomainModelContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Woman"},
                    new Category { Name = "Man" },
                    new Category { Name = "Kids" }
                };

                categories.ForEach(c => context.Categories.Add(c));
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Product1", Quantity = 2, CategoryId = 1, Price=(decimal)1.1, Timestamp = DateTime.Today },
                    new Product { Name = "Product2", Quantity = 5, CategoryId = 2, Price=(decimal)1.2, Timestamp = DateTime.Today },
                    new Product { Name = "Product3", Quantity = 6, CategoryId = 3, Price=(decimal)1.3, Timestamp = DateTime.Today }
                };

                products.ForEach(p => context.Products.Add(p));
                context.SaveChanges();
            }
        }
    }
}

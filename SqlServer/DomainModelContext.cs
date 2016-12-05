using DataModelEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServer.DomainContext
{
    public class DomainModelContext : DbContext
    {
        public DomainModelContext(DbContextOptions<DomainModelContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(m => m.ProductId);
            builder.Entity<Category>().HasKey(m => m.CategoryId);
            builder.Entity<Promotion>().HasKey(m => m.PromotionId);
            builder.Entity<Order>().HasKey(m => m.OrderId);
            builder.Entity<OrderDetail>().HasKey(m => m.OrderDetailId);
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateProperty<Category>();
            updateProperty<Product>();
            updateProperty<Promotion>();
            updateProperty<Order>();
            updateProperty<OrderDetail>();
            return base.SaveChanges();
        }

        private void updateProperty<T>() where T : class
        {
            var modified =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        }
    }
}

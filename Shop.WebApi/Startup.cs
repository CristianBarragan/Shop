using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shop.WebApi.Handling;
using DtoEntities;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Formatters.Json.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using SqlServer.DomainContext;
using Autofac;
using Service.Services;
using Service.IServices;
using DomainModel;
using Service.Mappers;
using Service.IMappers;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Shop.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddApplicationPart((typeof(ProductDTO).GetTypeInfo().Assembly))
                .AddControllersAsServices();
            services.TryAddSingleton<JsonResultExecutor>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            // init database for localization
            var sqlConnectionString = Configuration["DbStringLocalizer:ConnectionString"];

            services.AddDbContext<DomainModelContext>(options =>
                options.UseSqlServer(sqlConnectionString, b => b.MigrationsAssembly(typeof(DomainModelContext).GetTypeInfo().FullName))
            );

            // Add framework services.
            services.AddMvc();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ProductService>().As<IProductService>();
            containerBuilder.RegisterType<ProductDataAccessProvider>().As<IProductDataAccessProvider>();
            containerBuilder.RegisterType<ProductMapper>().As<IProductMapper>();
            containerBuilder.RegisterType<CategoryDataAccessProvider>().As<ICategoryDataAccessProvider>();
            containerBuilder.RegisterType<CategoryService>().As<ICategoryService>();
            containerBuilder.RegisterType<CategoryMapper>().As<ICategoryMapper>();
            containerBuilder.RegisterType<OrderService>().As<IOrderService>();
            containerBuilder.RegisterType<OrderDataAccessProvider>().As<IOrderDataAccessProvider>();
            containerBuilder.RegisterType<OrderService>().As<IOrderService>();
            containerBuilder.RegisterType<OrderMapper>().As<IOrderMapper>();
            containerBuilder.RegisterType<OrderDetailService>().As<IOrderDetailService>();
            containerBuilder.RegisterType<OrderDetailDataAccessProvider>().As<IOrderDetailDataAccessProvider>();
            containerBuilder.RegisterType<OrderDetailMapper>().As<IOrderDetailMapper>();
            containerBuilder.RegisterType<OrderService>().As<IOrderService>();
            containerBuilder.RegisterType<OrderDataAccessProvider>().As<IOrderDataAccessProvider>();
            containerBuilder.RegisterType<OrderMapper>().As<IOrderMapper>();
            containerBuilder.RegisterType<PromotionService>().As<IPromotionService>();
            containerBuilder.RegisterType<PromotionDataAccessProvider>().As<IPromotionDataAccessProvider>();
            containerBuilder.RegisterType<PromotionMapper>().As<IPromotionMapper>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("Startup");
            logger.LogWarning("Hi!");

            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                //loggerFactory.AddDebug();
                loggerFactory.AddDebug(LogLevel.Debug);

                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var angularRoutes = new[] {
                "/home",
                "/product",
                "/category",
            };

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.HasValue && null != angularRoutes.FirstOrDefault(
                    (ar) => context.Request.Path.Value.StartsWith(ar, StringComparison.OrdinalIgnoreCase)))
                {
                    context.Request.Path = new PathString("/");
                }

                await next();
            });
            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapWebApiRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}

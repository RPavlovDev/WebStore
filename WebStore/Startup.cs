using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Infrastructure.Services;
using WebStore.Infrastructure.Services.Interfaces;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddTransient<WebStoreDbInitializer>();
            services.AddTransient<IEmployeesData, InMemoryEmployeesData>();
            services.AddTransient<IProductData, InDbProductData>();
            services.AddTransient<IPrinter, StoragePrinter>();
            services.AddTransient<IMessageStorage, MessageStorege>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDbInitializer db)
        {
            db.Initialize();
            var printer = app.ApplicationServices.GetRequiredService<IPrinter>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Greeting", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }

        interface IPrinter
        {
            void Print(string message);
        }

        class StoragePrinter : IPrinter
        {
            private readonly IMessageStorage _Storage;

            public StoragePrinter(IMessageStorage Storage)
            {
                _Storage = Storage;
            }
            public void Print(string message)
            {
                _Storage.Add(message);
            }
        }

        interface IMessageStorage
        {
            void Add(string message);

            IEnumerable<(DateTime Time, string Message)> GetAll();
        }

        class MessageStorege : IMessageStorage
        {
            private readonly List<(DateTime Time, string Message)> _Messages = new();
            public void Add(string message)
            {
                _Messages.Add((DateTime.Now, message));
            }

            public IEnumerable<(DateTime Time, string Message)> GetAll()
            {
                return _Messages;
            }
        }
    }
}

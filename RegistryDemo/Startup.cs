using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RegistryDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RegistryDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string dbPath = Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine();
            Console.WriteLine("dbPath = " + dbPath);
            services.AddDbContext<SqliteDBContext>(options =>
                options.UseSqlite(dbPath));
        //    services.AddDbContext<SqliteDBContext>(Configuration.GetConnectionString("Default"));    //            AddEntityFrameworkSqlite(Configuration.GetConnectionString(""));
            services.AddControllers();
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RegistryDemo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RegistryDemo v1"));
            }

            //      app.UseHttpsRedirection();   // TODO resort this when https is working well.

            string dirPath = _env.ContentRootPath;
            var fileProvider = _env.ContentRootFileProvider;
            var filePath = Path.Combine("TestData.json");
            var fileInfo = fileProvider.GetFileInfo(filePath);
            var fileStream = fileInfo.CreateReadStream();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "registryquery",
                    pattern: "{controller=RegistryTest}/{action=Index}/{id?}");
            });
        }
    }
}

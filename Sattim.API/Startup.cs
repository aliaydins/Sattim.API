using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sattim.Business.Abstract;
using Sattim.Business.Concrete;
using Sattim.DataAccess.Abstract;
using Newtonsoft.Json.Linq;
using Sattim.DataAccess.Concrete;
using Sattim.Entities;

namespace Sattim.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOfferService, OfferManager>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IPictureService, PictureManager>();
            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseStaticFiles();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

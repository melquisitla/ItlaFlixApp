using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Services;
using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ItlaFlixApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Context
            services.AddDbContext<ItlaContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("ItlaContext")));
            //Repositories
            services.AddScoped<IRentRepository, RentRepositories>();
            services.AddScoped<IRolRepository, RolRepositories>();
            //App Services
            services. AddTransient<IRentService, RentService>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ItlaFlixApp.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItlaFlixApp.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

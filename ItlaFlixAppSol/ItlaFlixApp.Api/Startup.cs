using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItlaFlixApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Services;

namespace ItlaFlixApp.API
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
           services.AddScoped<IMovieRepository, MovieRepositories>();
           services.AddScoped<IGenderRepository, GenderRepositories>();
            //App services
            services.AddTransient<IMovieServices, MovieService>();
            services.AddTransient<IGenderServices, GenderService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ItlaFlixApp.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItlaFlixApp.API v1"));
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

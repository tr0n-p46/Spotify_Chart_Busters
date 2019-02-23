using System;
using System.Text;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using WebAPI.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DataConnection");
            
            services.AddDbContext<SpotifyDBContext>(options => options.UseMySQL(connectionString));

            services.AddScoped<IChartbustersRepository, ChartbustersRepository>();

            services.AddAutoMapper(am => am.AddProfile(new MappingProfile()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddOptions();

            services.AddCors();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors();
        }
    }
}

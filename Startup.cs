﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankWebApi.Services.Contexts;
using bankWebApi.Services.Implements;
using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql;

namespace bankwebapi
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
            services.AddMvc();
            services.AddDbContext<bankDatabaseContext>(o => {
                o.UseMySql(
                    "Server=localhost;Port=3306;Database=bankDatabase;Uid=dev;Pwd=mikolaj"
                );
            });
            services.AddScoped<IBankDataProvider, BankDataProvider>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=LogIn}/{id?}"
                );
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}

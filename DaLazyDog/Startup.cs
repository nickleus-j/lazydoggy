﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Lazydog.mysql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DaLazyDog.Resources;
using Microsoft.Extensions.Logging;
using DaLazyDog.Models;
using Lazydog.Model.Repo;
using Microsoft.Extensions.Hosting;

namespace DaLazyDog
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddControllersWithViews();
            //services.AddRazorPages();
            #region CultureLocalizer register
            services.AddSingleton<CultureLocalizer>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization(o => o.ResourcesPath = "Resources")
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResources));
                });
            #endregion

            services.Add(new ServiceDescriptor(typeof(IDbRepoInstantiator), new DbRepoInstantiator(Configuration["DefaultConnection"])));

            services.Configure<RequestLocalizationOptions>(options =>{
                    var supportedCultures = new List<CultureInfo>

                        {

                            new CultureInfo("en-US"),
                            new CultureInfo("es")
                        };
                    options.DefaultRequestCulture = new RequestCulture("en-US");

                    options.SupportedCultures = supportedCultures;

                    options.SupportedUICultures = supportedCultures;

                });
        }
        //private void configureErrorHandling(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        //{
        //    app.UseStatusCodePagesWithRedirects("/Home/Error?code={0}");
        //    if (env.IsDevelopment())
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        logger.LogInformation("Dev mode!");
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //        app.UseHsts();
        //    }

        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        //{
        //    configureErrorHandling(app, env, logger);
        //    //app.UseCookiePolicy();
        //    var supportedCultures = new[]
        //    {
        //        new CultureInfo("en-US"),
        //        new CultureInfo("es"),
        //    };
        //    app.UseRequestLocalization(new RequestLocalizationOptions
        //    {
        //        DefaultRequestCulture = new RequestCulture("en-US"),
        //        // Formatting numbers, dates, etc.
        //        SupportedCultures = supportedCultures,
        //        // UI strings that we have localized.
        //        SupportedUICultures = supportedCultures
        //    });
        //    app.UseHttpsRedirection();
        //    app.UseStaticFiles();

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapRazorPages();
        //    });
        //    logger.LogInformation("App started");
        //}
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using AutoMapper;
using Cengo.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using Cengo.AdvertisementApp.Business.Helpers;
using Cengo.AdvertisementApp.UI.Mappings.AutoMapper;
using Cengo.AdvertisementApp.UI.Models;
using Cengo.AdvertisementApp.UI.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Cengo.AdvertisementApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "YildizBilisim";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan = TimeSpan.FromDays(20);
        opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
        opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
        opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");
    });

            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

            var profiles = ProfileHelper.GetProfiles();

            profiles.Add(new UserCreateModelProfile());

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                name: "girisyap",
                pattern: "/GiriþYap",
                defaults: new { controller = "Home", action = "SignIn" }
            );
            });
        }
    }
}

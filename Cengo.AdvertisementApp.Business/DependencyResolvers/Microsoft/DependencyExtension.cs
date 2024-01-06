using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.Business.Services;
using Cengo.AdvertisementApp.Business.ValidationRules.AdvertisementValidations;
using Cengo.AdvertisementApp.Business.ValidationRules.AdvertissementAppUserValidations;
using Cengo.AdvertisementApp.Business.ValidationRules.AppUserValidations;
using Cengo.AdvertisementApp.Business.ValidationRules.GenderValidations;
using Cengo.AdvertisementApp.Business.ValidationRules.ProvidedServiceValidations;
using Cengo.AdvertisementApp.DataAccess.Contexts;
using Cengo.AdvertisementApp.DataAccess.UnitOfWork;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Dtos.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cengo.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

            services.AddScoped<IProvidedServiceManager, ProvidedServiceManager>();
            services.AddScoped<IAdvertisementManager, AdvertisementManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IGenderManager, GenderManager>();
            services.AddScoped<IAdvertisementAppUserManager, AdvertisementAppUserManager>();

        }
    }
}

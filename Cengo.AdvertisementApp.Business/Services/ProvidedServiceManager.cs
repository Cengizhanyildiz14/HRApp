using AutoMapper;
using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.DataAccess.UnitOfWork;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Dtos.Interfaces;
using Cengo.AdvertisementApp.Entities;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.Services
{
    public class ProvidedServiceManager : Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceManager
    {
        public ProvidedServiceManager(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator, IUow uow)
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }

    }
}

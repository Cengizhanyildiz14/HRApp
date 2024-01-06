using AutoMapper;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Dtos.Interfaces;
using Cengo.AdvertisementApp.Entities;

namespace Cengo.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedService, ProvidedServiceCreateDto>().ReverseMap();
            CreateMap<ProvidedService, ProvidedServiceListDto>().ReverseMap();
            CreateMap<ProvidedService, ProvidedServiceUpdateDto>().ReverseMap();
        }
    }
}

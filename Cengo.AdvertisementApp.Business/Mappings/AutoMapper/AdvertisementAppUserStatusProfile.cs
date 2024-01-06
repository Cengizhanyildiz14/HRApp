using AutoMapper;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;

namespace Cengo.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementAppUserStatusProfile : Profile
    {
        public AdvertisementAppUserStatusProfile()
        {
            CreateMap<AdvertisementAppUserStatus, AdvertisementAppUserStatusListDto>().ReverseMap();
        }
    }
}

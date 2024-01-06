using AutoMapper;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;

namespace Cengo.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppRoleProfile : Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
        }
    }
}

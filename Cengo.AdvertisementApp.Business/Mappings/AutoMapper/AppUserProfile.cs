using AutoMapper;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;

namespace Cengo.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
        }
    }
}

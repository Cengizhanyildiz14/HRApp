using AutoMapper;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.UI.Models;

namespace Cengo.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}

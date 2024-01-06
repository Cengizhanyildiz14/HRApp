using AutoMapper;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;

namespace Cengo.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class MilitaryStatusProfile : Profile
    {
        public MilitaryStatusProfile()
        {
            CreateMap<MilitaryStatus, MilitaryStatusListDto>().ReverseMap();
        }
    }
}

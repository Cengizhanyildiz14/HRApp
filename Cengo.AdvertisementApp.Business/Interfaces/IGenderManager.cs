using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;

namespace Cengo.AdvertisementApp.Business.Interfaces
{
    public interface IGenderManager : IService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}

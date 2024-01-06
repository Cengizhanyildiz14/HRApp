using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Dtos.Interfaces;
using Cengo.AdvertisementApp.Entities;

namespace Cengo.AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceManager : IService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>
    {
    }
}

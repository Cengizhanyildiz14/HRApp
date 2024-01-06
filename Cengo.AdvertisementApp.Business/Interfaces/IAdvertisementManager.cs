using Cengo.AdvertisementApp.Common.Interfaces;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementManager : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}

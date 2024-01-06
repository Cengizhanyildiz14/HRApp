using Cengo.AdvertisementApp.Common.Enums;
using Cengo.AdvertisementApp.Common.Interfaces;
using Cengo.AdvertisementApp.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserManager
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}

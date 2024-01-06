using Cengo.AdvertisementApp.Common.Interfaces;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.Business.Interfaces
{
    public interface IAppUserManager : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
    }
}

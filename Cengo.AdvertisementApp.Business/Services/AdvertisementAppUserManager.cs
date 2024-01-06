using AutoMapper;
using Cengo.AdvertisementApp.Business.Extensions;
using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.Common;
using Cengo.AdvertisementApp.Common.Enums;
using Cengo.AdvertisementApp.Common.Interfaces;
using Cengo.AdvertisementApp.Common.Response;
using Cengo.AdvertisementApp.DataAccess.UnitOfWork;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserManager : IAdvertisementAppUserManager
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserManager(IUow uow, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
        {
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepostitory<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);

                if (control == null)
                {
                    var createdAdvertisemenAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepostitory<AdvertisementAppUser>().CreateAsync(createdAdvertisemenAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                else
                {
                    List<CustomValidationError> errors = new List<CustomValidationError> { new() { ErrorMessage = "Mevcut Bir Başvurunuz Bulunmakta", PropertyName = "" } };
                    return new Response<AdvertisementAppUserCreateDto>(dto, errors);
                }
            }

            else
            {
                return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
            }
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepostitory<AdvertisementAppUser>().GetQuery();

            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus)
                .Include(x => x.AppUser).ThenInclude(x => x.Gender).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();

            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepostitory<AdvertisementAppUser>().GetQuery();

            var entity = await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChangesAsync();
        }
    }
}

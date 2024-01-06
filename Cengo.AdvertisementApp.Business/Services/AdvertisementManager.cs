using AutoMapper;
using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.Common.Interfaces;
using Cengo.AdvertisementApp.Common.Response;
using Cengo.AdvertisementApp.DataAccess.UnitOfWork;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.Business.Services
{
    public class AdvertisementManager : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementManager
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementManager(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
            var data = await _uow.GetRepostitory<Advertisement>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);
        }
    }
}

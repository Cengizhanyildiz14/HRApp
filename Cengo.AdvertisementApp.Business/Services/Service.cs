using AutoMapper;
using Cengo.AdvertisementApp.Business.Extensions;
using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.Common.Interfaces;
using Cengo.AdvertisementApp.Common.Response;
using Cengo.AdvertisementApp.DataAccess.UnitOfWork;
using Cengo.AdvertisementApp.Dtos.Interfaces;
using Cengo.AdvertisementApp.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
         where UpdateDto : class, IUpdateDto, new()
         where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createValidator, IValidator<UpdateDto> updateValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createValidator;
            _updateDtoValidator = updateValidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepostitory<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success, dto);
            }
            return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            {
                var data = await _uow.GetRepostitory<T>().GetAllAsync();
                var dto = _mapper.Map<List<ListDto>>(data);
                return new Response<List<ListDto>>(ResponseType.Success, dto);
            }
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepostitory<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response<IDto>(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");
            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepostitory<T>().FindAsync(id);
            if (data == null)
                return new Response(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");
            _uow.GetRepostitory<T>().Remove(data);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _uow.GetRepostitory<T>().FindAsync(dto.Id);
                if (unchangedData == null)
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} idsine sahip data bulunamadı");
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepostitory<T>().Update(entity, unchangedData);
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            return new Response<UpdateDto>(dto, result.ConvertToCustomValidationError());
        }
    }
}

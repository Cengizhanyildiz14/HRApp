using AutoMapper;
using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.DataAccess.UnitOfWork;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.Entities;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.Services
{
    public class GenderManager : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderManager
    {
        public GenderManager(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow)
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    }
}

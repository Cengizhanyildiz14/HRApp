using Cengo.AdvertisementApp.Dtos;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.AdvertisementValidations
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}

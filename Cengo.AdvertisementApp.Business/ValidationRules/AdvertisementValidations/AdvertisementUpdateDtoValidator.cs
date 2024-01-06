using Cengo.AdvertisementApp.Dtos;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.AdvertisementValidations
{
    public class AdvertisementUpdateDtoValidator : AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}

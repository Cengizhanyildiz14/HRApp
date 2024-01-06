using Cengo.AdvertisementApp.Dtos;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.GenderValidations
{
    public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}

using Cengo.AdvertisementApp.Dtos;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.GenderValidations
{
    public class GenderCreateDtoValidator : AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}

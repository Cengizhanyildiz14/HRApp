using Cengo.AdvertisementApp.Dtos;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.ProvidedServiceValidations
{
    public class ProvidedServiceUpdateDtoValidator : AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();

        }
    }
}

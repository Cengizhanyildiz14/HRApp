using Cengo.AdvertisementApp.Dtos.Interfaces;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.ProvidedServiceValidations
{
    public class ProvidedServiceCreateDtoValidator : AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}

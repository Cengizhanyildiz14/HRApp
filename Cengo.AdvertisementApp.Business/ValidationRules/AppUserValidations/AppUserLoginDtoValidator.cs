using Cengo.AdvertisementApp.Dtos;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.AppUserValidations
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
        }
    }
}

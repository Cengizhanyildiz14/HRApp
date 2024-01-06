using Cengo.AdvertisementApp.Common.Enums;
using Cengo.AdvertisementApp.Dtos;
using FluentValidation;

namespace Cengo.AdvertisementApp.Business.ValidationRules.AdvertissementAppUserValidations
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty().WithMessage("Bir Cv Dosyası Seçiniz");
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Tecil Tarihi Boş Bırakılamaz");
        }
    }
}

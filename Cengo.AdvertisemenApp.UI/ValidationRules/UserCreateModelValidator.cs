﻿using Cengo.AdvertisementApp.UI.Models;
using FluentValidation;

namespace Cengo.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola min 3 karakter olmalıdır");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı boş olamaz");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı Adı min 3 karakter olmalıdır");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("kullanıcı adı, adınızı içeremez.").When(x => x.Username != null && x.Firstname != null);

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.");


        }

        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}

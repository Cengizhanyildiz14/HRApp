using AutoMapper;
using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.Common.Enums;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.UI.Extension;
using Cengo.AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderManager _genderManager;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AccountController(IGenderManager genderManager, IValidator<UserCreateModel> userCreateModelValidator, IAppUserManager appUserManager, IMapper mapper)
        {
            _genderManager = genderManager;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderManager.GetAllAsync();
            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserManager.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderManager.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserManager.CheckUserAsync(dto);
            if (result.ResponseType == Common.Response.ResponseType.Success)
            {
                var roleResult = await _appUserManager.GetRolesByUserIdAsync(result.Data.Id);
                // ilgili kullanıcının rollerini çekmemiz.
                var claims = new List<Claim>();

                if (roleResult.ResponseType == Common.Response.ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }

                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);
            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
    CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}

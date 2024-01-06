using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.Common.Enums;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserManager _userManager;
        private readonly IAdvertisementAppUserManager _advertisementAppUserManager;

        public AdvertisementController(IAppUserManager userManager, IAdvertisementAppUserManager advertisementAppUserManager)
        {
            _userManager = userManager;
            _advertisementAppUserManager = advertisementAppUserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _userManager.GetByIdAsync<AppUserListDto>(userId);

            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));

            var list = new List<MilitaryStatusListDto>();

            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new AdvertisementAppUserCreateModel
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            });
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();
            if (model.CvFile != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvFile.CopyToAsync(stream);
                dto.CvPath = path;
            }

            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AdvertisementId = model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate = model.EndDate;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;

            var response = await _advertisementAppUserManager.CreateAsync(dto);
            if (response.ResponseType == Common.Response.ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _userManager.GetByIdAsync<AppUserListDto>(userId);

                ViewBag.GenderId = userResponse.Data.GenderId;

                var items = Enum.GetValues(typeof(MilitaryStatusType));

                var list = new List<MilitaryStatusListDto>();

                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                    });
                }

                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                return View(model);
            }
            else
            {
                return RedirectToAction("HumanResource", "home");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementAppUserManager.GetList(AdvertisementAppUserStatusType.Başvurdu);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            await _advertisementAppUserManager.SetStatusAsync(advertisementAppUserId, type);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovedList()
        {
            var list = await _advertisementAppUserManager.GetList(AdvertisementAppUserStatusType.Mülakat);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _advertisementAppUserManager.GetList(AdvertisementAppUserStatusType.Olumsuz);
            return View(list);
        }
    }
}

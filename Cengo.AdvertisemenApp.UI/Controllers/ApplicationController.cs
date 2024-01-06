using Cengo.AdvertisementApp.Business.Interfaces;
using Cengo.AdvertisementApp.DataAccess.UnitOfWork;
using Cengo.AdvertisementApp.Dtos;
using Cengo.AdvertisementApp.UI.Extension;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.UI.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementManager _advertisementManager;
        private readonly IUow _uow;

        public ApplicationController(IAdvertisementManager advertisementManager)
        {
            _advertisementManager = advertisementManager;
        }

        public async Task<IActionResult> List()
        {
            var response = await _advertisementManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            return View(new AdvertisementCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateDto dto)
        {
            var response = await _advertisementManager.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _advertisementManager.GetByIdAsync<AdvertisementUpdateDto>(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdvertisementUpdateDto dto)
        {
            var response = await _advertisementManager.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _advertisementManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }
    }
}

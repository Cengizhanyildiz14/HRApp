using Cengo.AdvertisementApp.Dtos.Interfaces;

namespace Cengo.AdvertisementApp.Dtos
{
    public class AppUserLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

using Cengo.AdvertisementApp.Dtos.Interfaces;

namespace Cengo.AdvertisementApp.Dtos
{
    public class AppRoleListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}

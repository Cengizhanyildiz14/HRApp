using Cengo.AdvertisementApp.Dtos.Interfaces;

namespace Cengo.AdvertisementApp.Dtos.AppRoleDtos
{
    public class AppRoleUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}

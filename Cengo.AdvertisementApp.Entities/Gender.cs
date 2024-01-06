using System.Collections.Generic;

namespace Cengo.AdvertisementApp.Entities
{
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}

using AutoMapper;
using Cengo.AdvertisementApp.Business.Mappings.AutoMapper;
using System.Collections.Generic;

namespace Cengo.AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {

            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile(),
            };
        }
    }
}

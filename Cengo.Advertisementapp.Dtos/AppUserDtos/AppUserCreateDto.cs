﻿using Cengo.AdvertisementApp.Dtos.Interfaces;

namespace Cengo.AdvertisementApp.Dtos
{
    public class AppUserCreateDto : IDto
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }

    }
}

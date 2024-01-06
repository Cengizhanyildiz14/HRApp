﻿using Cengo.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cengo.AdvertisementApp.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
            builder.HasData(new AppRole[]
           {
                new()
                {
                    Definition="Admin",
                    Id=1,
                },
                new()
                {
                    Definition= "Member",
                    Id=2
                }
           });
        }
    }
}

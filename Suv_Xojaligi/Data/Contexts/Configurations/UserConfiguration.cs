using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Suv_Xojaligi.Data.Entities;

namespace Suv_Xojaligi.Data.Contexts.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{

    public UserConfiguration()
    {
        //_userManager = userManager;
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        var user = new User
        {
            Id = Guid.Parse("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
            UserName = "Oybek",
            NormalizedUserName = "Oybek".ToUpper(),
            Email = "oybek@gmail.com",
            NormalizedEmail = "oybek@gmail.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEFO6ftiV/u05Xiv1Lorpej0W6LEmFqXnGUKSe6VaVecjWdxevE/+3Rn0o/QwxZOXfQ==",//Shamsiddin@123,
            ConcurrencyStamp = "4d7805a0-d8d8-4faa-aac5-1dcea562fa21",
            FirstName = "Qodirov",
            LastName = "Oybek"
        };
        //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, "Ay#@ere123");
        builder.HasData(user);
    }
}

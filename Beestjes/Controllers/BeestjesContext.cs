using Beestjes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beestjes.Controllers;

public class BeestjesContext : IdentityDbContext<BeestjeUser>
{
    public BeestjesContext(DbContextOptions<BeestjesContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        string ACCOUNT_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        var appUser = new BeestjeUser()
        {
            Id = ACCOUNT_ID,
            EmailConfirmed = true,
            UserName = "Konijntje",
            NormalizedUserName = "KONIJNTJE"
        };

        //set user password
        PasswordHasher<BeestjeUser> ph = new PasswordHasher<BeestjeUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, "Konijn123!");

        //seed user
        builder.Entity<BeestjeUser>().HasData(appUser);
    }
}

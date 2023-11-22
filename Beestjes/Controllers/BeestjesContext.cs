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

public DbSet<Beestjes.Models.Beestje> Beestje { get; set; } = default!;
}
using Beestjes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Beestjes.Controllers;

public class BeestjesContext : IdentityDbContext<BeestjeUser>
{
    
}
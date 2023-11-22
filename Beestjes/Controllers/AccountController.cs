using Beestjes.Models;
using Beestjes.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Beestjes.Controllers;

public class AccountController : Controller
{

    private UserManager<BeestjeUser> _userManager;
    private SignInManager<BeestjeUser> _signInManager;

    public AccountController(UserManager<BeestjeUser> userManager, SignInManager<BeestjeUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AccountLoginModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(
            model.Email,
            model.Password, 
            true, 
            false);

        if (result.Succeeded)
        {
            return Redirect("/");
        }
        else
        {
            return View();
        }
    }
    
}
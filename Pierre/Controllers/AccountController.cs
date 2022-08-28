using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Pierre.Models;
using Pierre.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Pierre.Controllers
{
  [AllowAnonymous]
  public class AccountController : Controller
  {
    private readonly PierreContext _db;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly 
    SignInManager<ApplicationUser> _signInManager;

    //constructor:
    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierreContext db)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
    }

    //routes:
    public ActionResult Index()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
      return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Registration Failed.";
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Unable to Login.";
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }

  }
}
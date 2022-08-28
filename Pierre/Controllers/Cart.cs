using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Pierre.Models;
using Microsoft.Extensions.Logging;

namespace Pierre.Controllers
{
  public class CartController : Controller
  {
    private readonly PierreContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<CartController> _logger;

    public CartController(UserManager<ApplicationUser> userManager, PierreContext db, ILogger<CartController> logger)
    {
      _userManager = userManager;
      _db = db;
      _logger = logger;
    }

    public async Task<ActionResult> Index()
    {

      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      var Cart = _db.ApplicationUsers
        .Include(user=> user.JoinCart)
        .ThenInclude(join=>join.FlavorTreat)

        .FirstOrDefault(user=>user.Id == currentUser.Id);
      return View(Cart);
    }
    // public ActionResult AddFlavorTreatPrice(int id)
    // {
    //   var joinItem = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == id);
    //   _logger.LogInformation(id.ToString());
    //   return View(joinItem);
    // }

    // [HttpPost]
    // public ActionResult AddFlavorTreatPrice(FlavorTreat flavorTreat)
    // {
      
    //   _db.Entry(flavorTreat).State = EntityState.Modified;
    //   _db.SaveChanges();

    //   _logger.LogInformation(flavorTreat.Price.ToString());

    //   return RedirectToAction("Index", "Home");
    // }
  }
}
